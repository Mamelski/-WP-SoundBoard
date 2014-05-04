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

namespace SoundBoard
{
    public partial class RecordAudio : PhoneApplicationPage
    {
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
            //ApplicationBar.IsVisible = false;
        }

        void recordAudioAppBar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}