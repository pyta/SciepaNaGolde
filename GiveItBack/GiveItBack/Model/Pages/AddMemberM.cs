﻿using System;
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
using Tools;

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

        /// <summary>
        /// Zwraca lub ustawia falgę informującą o formie wprowadzania nowego uczestnika.
        /// </summary>
        public bool AddFromContacts { get; set; }

        /// <summary>
        /// Zwraca lub ustawia nazwę wprowadzoną przez użytkownika. Jeżeli aktywna jest flaga <see cref="AddFromContacts"/> to pole to służy jako filtr do
        /// przeszukiwania kontaktów zapisanych w telefonie. W przeciwym przypadku nazwa ta bezpośrednio przenosi się nazwę nowego uczestnika zrzutki.
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// Zwraca lub ustawia obiekt przechowujący informacje o aktualnie wybranej pozycji, jeżeli użyto opcji przeszukiwania kontaktów.
        /// </summary>
        public SelectedMember SelectedMember { get; set; }

        public AddMemberM(IAppPage previousPage)
            : base(previousPage)
        {
            _bar = CreateBar();

            AddFromContacts = true;
        }

        #region Private Methods

        private ApplicationBar CreateBar()
        {
            // TODO: Utworzyć menu do zatwierdzania nowego uczestnika zrzuteczki.
            
            var bar = new ApplicationBar();

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.WorkBarAddMember;
            appBarButton.Click += appBarButton_Click;
            bar.Buttons.Add(appBarButton);

            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            bar.MenuItems.Add(appBarMenuItem);

            return bar;
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
            // TODO: Przejście do okna z kwotą.

            if (AddFromContacts)
            {
                
            }
            else
            {
                SelectedMember = new SelectedMember() { Name = MemberName };
            }

            GoToPage(new AddValueM(this, PreviousPage, SelectedMember));
        }

        #endregion
    }
}
