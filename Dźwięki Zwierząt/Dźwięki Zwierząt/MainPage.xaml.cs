using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Dźwięki_Zwierząt.Resources;
using System.Windows.Media;

namespace Dźwięki_Zwierząt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Button myButton = new Button();
            myButton.Name = "MiałButton";
            myButton.Height = 100;
            //myButton.Height = 200;
            //myButton.Width = 200;
            myButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            //myButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            myButton.Background = new SolidColorBrush(Colors.Red);
            myButton.Content = "Miał";
            ContentPanel.Children.Add(myButton);

            //myButton.Margin = new Thickness(210, 0, 0, 0);

            myButton.Click += PlayAudioButton_Click;
        }

        private void PlayAudioButton_Click(object sender, RoutedEventArgs e)
        {
            KwakMediaElement.Play();   
        }


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}