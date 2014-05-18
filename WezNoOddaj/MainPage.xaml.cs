using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Imaging;

using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;

using WezNoOddajLib.Members;
using WezNoOddaj.Screens;
using WezNoOddaj.Members;
using WezNoOddaj.Members.Helpers;

namespace WezNoOddaj
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Members

        private IMoneyCollection _collection;

        private UserControl _currentPage;
        private StartPage _startPage;
        private ResultPage _resultPage;

        #endregion

        public MainPage()
        {
            InitializeComponent();

            StartNewCollection();
            ShowMainPage();
        }

        #region Show methods

        /// <summary>
        /// Wyświetlenie okna startowego.
        /// </summary>
        public void ShowMainPage()
        {
            _startPage = new StartPage(ShowAddMemberPage, StartNewCollection, _collection.RemoveMember, ShowResultPage, _collection.MembersList);

            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(_startPage);

            _currentPage = _startPage;
        }

        /// <summary>
        /// Wyświetlenie okna z możliwością dodania nowego użytkownika.
        /// </summary>
        public void ShowAddMemberPage()
        {
            AddMemberController addMemberController = new AddMemberController(ContentPanel, AddNewMember);
            _currentPage = null;
        }

        /// <summary>
        /// Wyświetlanie okna z wynikiem.
        /// </summary>
        public void ShowResultPage()
        {
            _resultPage = new ResultPage(_collection.Calculate());

            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(_resultPage);

            _currentPage = _resultPage;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Metoda dodaje pozycję przekazaną jako parametr do listy. Metoda przypinana do delagata w oknie wyszukiwnia nowego użytkownika. Wywoływana w momencie
        /// wskazania odpowiedniej pozycji i dodania do niej kwoty.
        /// </summary>
        /// <param name="newMember">Nowa składka.</param>
        private void AddNewMember(IMemberInfo newMember)
        {
            _collection.AddNewMember(newMember);
            ShowMainPage();
        }

        private void CalculateResult()
        {
            _collection.Calculate();
        }

        /// <summary>
        /// Rozpoczęcie nowej zbiórki piniędzy.
        /// </summary>
        private void StartNewCollection()
        {
            _collection = new MoneyCollection(RefreshData);

            if (_startPage != null)
                _startPage.panelMembersList.FillList(new List<IMemberInfo>());
        }

        /// <summary>
        /// Odświeżenie danych na formatce.
        /// </summary>
        private void RefreshData()
        {
            if (_startPage != null)
            {
                _startPage.panelAddNewCollection.RefreshData(_collection.MembersList);
                _startPage.panelMembersList.FillList(_collection.MembersList);
            }
        }

        #endregion

        #region Override methods

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            // Jeżeli aktualną stroną nie jest strona startowa do należy do niej powrócić. W innym przypadku, można spokojnie zamknąć aplikację.

            if (!(_currentPage is StartPage))
            {
                ShowMainPage();
                e.Cancel = true;
            }
        }

        #endregion
    }
}