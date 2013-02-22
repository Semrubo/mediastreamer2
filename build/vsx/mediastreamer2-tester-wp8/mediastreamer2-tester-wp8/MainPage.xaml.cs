﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using mediastreamer2_tester_wp8.Resources;

namespace mediastreamer2_tester_wp8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            List<UnitTestSuiteName> source = new List<UnitTestSuiteName>();
            source.Add(new UnitTestSuiteName("ALL"));
            source.Add(new UnitTestSuiteName("dtmfgen"));

            Tests.ItemsSource = source;
            Tests.SelectionChanged += tests_selectionChanged;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void tests_selectionChanged(object sender, EventArgs e)
        {
            UnitTestSuiteName test = (sender as LongListSelector).SelectedItem as UnitTestSuiteName;
            NavigationService.Navigate(new Uri("/TestResultPage.xaml?SuiteName=" + test.Name + "&Verbose=" + Verbose.IsChecked.GetValueOrDefault(), UriKind.Relative));
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

    public class UnitTestSuiteName
    {
        public string Name
        {
            get;
            set;
        }

        public UnitTestSuiteName(string name)
        {
            this.Name = name;
        }
    }
}