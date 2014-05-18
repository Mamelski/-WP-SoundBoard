using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SoundBoard.Resources;
using Coding4Fun.Toolkit.Audio;
using Coding4Fun.Toolkit.Audio.Helpers;
using System.IO;
using System.IO.IsolatedStorage;
using Coding4Fun.Toolkit.Controls;
using SoundBoard.ViewModels;
using Newtonsoft.Json;

namespace SoundBoard
{
    public partial class RecordAudio : PhoneApplicationPage
    {
        private MicrophoneRecorder recorder = new MicrophoneRecorder();

        private IsolatedStorageFileStream audioStream;

        private string tempFileName = "tempWave.wav";

        public RecordAudio()
        {
            InitializeComponent();

            BuildLocalizedApplicationBar();
        }

        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton recordAudioAppBar =
                new ApplicationBarIconButton();

            recordAudioAppBar.IconUri = new Uri("/Assets/Appbar/save.png", UriKind.Relative);
            recordAudioAppBar.Text = AppResources.AppBarSave;

            recordAudioAppBar.Click += recordAudioAppBar_Click;

            ApplicationBar.Buttons.Add(recordAudioAppBar);
            ApplicationBar.IsVisible = false;
        }

        void recordAudioAppBar_Click(object sender, EventArgs e)
        {
            InputPrompt fileName = new InputPrompt();

            fileName.Title = "Kocham Cię <3";
            fileName.Message = "Druzd Misiu jaki dźwięk z siebie wydałaś";

            fileName.Completed += fileNameCompleted;

            fileName.Show();
        }

        void fileNameCompleted(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.PopUpResult == PopUpResult.Ok)
            {
                // stworzenei SoundData
                SoundData soundData = new SoundData();
                soundData.FilePath = string.Format("/customAudio/{0}.wav", DateTime.Now.ToFileTime());
                soundData.Title = e.Result;

                // Zapiswyanie pliku
                using(IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication()){
                    if (!isoStore.DirectoryExists("/customAudio/"))
                    {
                        isoStore.CreateDirectory("/customAudio/");
                    }

                    isoStore.MoveFile(tempFileName, soundData.FilePath);
                }

                var data = JsonConvert.SerializeObject(App.ViewModel.CustomSounds);

                IsolatedStorageSettings.ApplicationSettings[SoundModel.CustomSoundKey] = data;
                IsolatedStorageSettings.ApplicationSettings.Save();

                App.ViewModel.CustomSounds.Items.Add(soundData);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                // create a sound data object
                // save wav file into directory
                // add sounddata object to App.ViewModel.Customsounds
                // Save list of Custom sounds
                //
            }
        }

        private void RecordAudioChecked(object sender, RoutedEventArgs e)
        {
            PlayAudio.IsEnabled = false;
            ApplicationBar.IsVisible = false;
            RotateCircle.Begin();
            recorder.Start();
        }

        private void RecordAudioUnchecked(object sender, RoutedEventArgs e)
        {
            recorder.Stop();
            saveTempAudio(recorder.Buffer);
            PlayAudio.IsEnabled = true;
            ApplicationBar.IsVisible = true;
            RotateCircle.Stop();
        }

        private void saveTempAudio(MemoryStream buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("Attempting a save an empty sound buffer");
            }

            // Clean out the Audioplayer's hold on our audioStream
            if (audioStream != null)
            {
                AudioPlayer.Stop();
                AudioPlayer.Source = null;

                audioStream.Dispose();
            }
            var bytes = buffer.GetWavAsByteArray(recorder.SampleRate);

            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication()){
                if (isoStore.FileExists(tempFileName))
                {
                    isoStore.DeleteFile(tempFileName);
                }

                tempFileName = string.Format("{0}.wav", DateTime.Now.ToFileTime());
                
                audioStream = isoStore.CreateFile(tempFileName);
                audioStream.Write(bytes, 0, bytes.Length);

                AudioPlayer.SetSource(audioStream);
            }
        }

        private void PlayAudioClick(object sender, RoutedEventArgs e)
        {
            AudioPlayer.Play();
        }

    }
}