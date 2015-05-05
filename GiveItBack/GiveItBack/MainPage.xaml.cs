using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GiveItBack.Resources;
using GiveItBack.ViewModel;

namespace GiveItBack
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            // TODO: Odwołać się do modelu i jeżeli możliwe jest wywołanie back to spoko - w przeciwym wypadku zamknąć aplikację.            

            // Sytuacja, w której trzeba np. schować klawiaturę.
            // base.OnBackKeyPress(e);

            e.Cancel = true;

            if (DataContext is AppVM)
            {
                var model = DataContext as AppVM;
                if (model.CurrentPage.PreviousPage != null)
                    model.CurrentPage.Back();
                else
                    Application.Current.Terminate();
            }
        }
    }
}
