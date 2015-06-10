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
    public class AddValueM : PageBase
    {
        #region Private Members

        /// <summary>
        /// Prywatny obiekt przechowujący menu wyświetlane w module dodawania wysokości wkładu.
        /// </summary>
        private ApplicationBar _bar;

        /// <summary>
        /// Prywatna zmienna przechowująca główny obaszar roboczy z listą wszystkich uczestników.
        /// </summary>
        private IAppPage _workPage;

        #endregion

        public override Control Content
        {
            get
            {
                var page = new AddValuePage() { DataContext = new AddValueVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return _bar; } }

        /// <summary>
        /// Zwraca uczestnika.
        /// </summary>
        public SelectedMember Member { get; private set; }

        /// <summary>
        /// Zwraca lub ustawia metodę wywoływaną w chwili użycia przycisku zatwierdzającego w menu z poziomu GUI.
        /// </summary>
        public Action GetValueInfo { get; set; }

        /// <summary>
        /// Tworzy model modułu odpowiedzialnego za wprowadzanie wysokości wkładu.
        /// </summary>
        /// <param name="previousPage">Poprzednia strona aplikacji (wybieranie użytkownika).</param>
        /// <param name="workPage">Główna strona robocza z listą wszystkich uczestników.</param>
        /// <param name="member">Uczestnik wybrany na poprzedniej stronie.</param>
        public AddValueM(IAppPage previousPage, IAppPage workPage, SelectedMember member)
            : base(previousPage)
        {
            _bar = CreateBar();
            _workPage = workPage;

            Member = member;
        }

        /// <summary>
        /// Przechodzi do głównego okna roboczego z listą wszystkich dodanych użytkowników jednocześnie dodając nowego uczestnika.
        /// </summary>
        /// <param name="value">Wysokość wkładu uczestnika.</param>
        public void GoToWorkPage(double value)
        {
            if (_workPage is WorkM)
            {
                MemberInfo info = new MemberInfo(
                    Member.Name,
                    value,
                    ToolsKit.GetColor(),
                    Member.Avatar,
                    Member.AdditionalInfo != null ? Member.AdditionalInfo.PhoneNumber : string.Empty);

                ((WorkM)_workPage).AddNewMember(info);
            }

            GoToPage(_workPage);
        }

        #region Private Methods

        /// <summary>
        /// Tworzy menu modułu dodawania wysokości wkładu uczestnika.
        /// </summary>
        /// <returns></returns>
        private ApplicationBar CreateBar()
        {
            IMenuIconsSet icons = ToolsKit.GetMenuIconsSet();

            var bar = new ApplicationBar();
            bar.Buttons.Add(CreateSelectValueButton(icons));

            return bar;
        }

        /// <summary>
        /// Tworzy przycisk menu do zatwierdzania wyboru nowego uczestnika zrzuty.
        /// </summary>
        /// <param name="icons">Obiekt odpowiedzialny za tworzenie schematów ikon.</param>
        /// <returns></returns>
        private ApplicationBarIconButton CreateSelectValueButton(IMenuIconsSet icons)
        {
            ApplicationBarIconButton button = new ApplicationBarIconButton(new Uri(icons.CheckIcon, UriKind.Relative));
            button.Text = AppResources.strConfirmValue;
            button.Click += selectValueButton_Click;

            return button;
        }

        #endregion

        #region Events

        private void selectValueButton_Click(object sender, EventArgs e)
        {
            if (GetValueInfo != null)
                GetValueInfo();
        }

        #endregion
    }
}
