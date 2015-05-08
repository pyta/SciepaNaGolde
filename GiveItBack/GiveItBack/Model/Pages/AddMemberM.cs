using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.Resources;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;

namespace GiveItBack.Model.Pages
{
    public class AddMemberM : PageBase
    {
        #region Private Members

        private ApplicationBar _bar;

        #endregion

        public override Control Content
        {
            get
            {
                var page = new AddMemberPage() { DataContext = new AddMemberVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return _bar; ; } }

        public AddMemberM(IAppPage previousPage)
            : base(previousPage)
        {
            _bar = CreateBar();
        }

        #region Private Methods

        private ApplicationBar CreateBar()
        {
            // TODO: Utworzyć menu do zatwierdzania nowego uczestnika zrzuteczki.

            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            var bar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            bar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            bar.MenuItems.Add(appBarMenuItem);

            return bar;
        }

        #endregion
    }
}
