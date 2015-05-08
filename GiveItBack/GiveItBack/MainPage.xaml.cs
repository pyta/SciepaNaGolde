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
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
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
