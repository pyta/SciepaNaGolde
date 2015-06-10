using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common;
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

        /// <summary>
        /// Prywatny obiekt przechowujący menu wyświetlane w module dodawania nowego uczestnika.
        /// </summary>
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
        /// Zwraca lub ustawia metodę wywoływaną w chwili użycia przycisku zatwierdzania uczestnika w menu z poziomu GUI.
        /// </summary>
        public Action GetSelectedMember { get; set; }

        /// <summary>
        /// Tworzy model modułu odpowiedzialnego za wprowadzanie nazwy nowego uczestnika.
        /// </summary>
        /// <param name="previousPage">Poprzednia strona aplikacji.</param>
        public AddMemberM(IAppPage previousPage)
            : base(previousPage)
        {
            _bar = CreateBar();
        }

        /// <summary>
        /// Przechodzi do okna z możliwością wprowadzenia wkładu wybranego uczestnika.
        /// </summary>
        /// <param name="member">Wspomniany wcześniej, wybrany użytkownik.</param>
        public void GoToValuePage(SelectedMember member)
        {
            GoToPage(new AddValueM(this, PreviousPage, member));
        }

        #region Private Methods

        /// <summary>
        /// Tworzy menu modułu dodawania nowego uczestnika.
        /// </summary>
        /// <returns></returns>
        private ApplicationBar CreateBar()
        {
            IMenuIconsSet icons = ToolsKit.GetMenuIconsSet();

            var bar = new ApplicationBar();
            bar.Buttons.Add(CreateSelectMemberButton(icons));

            return bar;
        }

        /// <summary>
        /// Tworzy przycisk menu do zatwierdzania wyboru nowego uczestnika zrzuty.
        /// </summary>
        /// <param name="icons">Obiekt odpowiedzialny za tworzenie schematów ikon.</param>
        /// <returns></returns>
        private ApplicationBarIconButton CreateSelectMemberButton(IMenuIconsSet icons)
        {
            ApplicationBarIconButton button = new ApplicationBarIconButton(new Uri(icons.AddIcon, UriKind.Relative));
            button.Text = AppResources.strWorkBarSelectMember;
            button.Click += selectMemberButton_Click;

            return button;
        }

        #endregion

        #region Events

        private void selectMemberButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedMember != null)
                GetSelectedMember();
        }

        #endregion
    }
}
