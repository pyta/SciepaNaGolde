using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using WezNoOddaj.Screens;
using WezNoOddaj.Members;
using WezNoOddaj.Members.Helpers;

using WezNoOddajLib.Members;

namespace WezNoOddaj.Members.Helpers
{
    public class AddMemberController : IDisposable
    {
        #region Members

        SelectUserFromContactsPage      _selectPage;
        InsertValueForSelectedUserPage  _insertPage;

        /// <summary>
        /// Metoda dodająca użytkownika do głównej listy.
        /// </summary>
        private Action<IMemberInfo> _addMemberToListMethod;

        /// <summary>
        /// Obiekt, do którego mają być wpisane odpowiednie panele.
        /// </summary>
        private Grid _mainGrid;

        #endregion

        public AddMemberController(Grid mainGrid, Action<IMemberInfo> addMemberToListMethod)
        {
            _mainGrid = mainGrid;
            _addMemberToListMethod += addMemberToListMethod;

            SelectUserFromContacts();
        }

        #region Private methods

        /// <summary>
        /// Zmiana ekranu na ekran wprowadzania wartości dla zaznaczonego użytkownika.
        /// </summary>
        /// <param name="userInfo"></param>
        private void InsertValueForSelectedUser(SelectedUserInformation userInfo)
        {
            _insertPage = new InsertValueForSelectedUserPage(userInfo);
            _insertPage.ChangeSelectedUserMethod += SelectUserFromContacts;
            _insertPage.AddNewMemberMethod += AddNewMember;

            _mainGrid.Children.Clear();
            _mainGrid.Children.Add(_insertPage);

            _insertPage.ShowNumericKeyboard();
        }

        /// <summary>
        /// Zmiana ekranu na ekran wyszukiwania użytkownika.
        /// </summary>
        private void SelectUserFromContacts()
        {
            _selectPage = new SelectUserFromContactsPage();
            _selectPage.InsertValueMethod += InsertValueForSelectedUser;

            _mainGrid.Children.Clear();
            _mainGrid.Children.Add(_selectPage);

            _selectPage.ShowAlphaKeyboard();
        }

        /// <summary>
        /// Zatwierdzenie ekranu - dodanie wyniku.
        /// </summary>
        /// <param name="userInfo">Obiekt reprezentujący informacje o użytkowniku.</param>
        /// <param name="value">Kwaota, którą wyłożył użytkownik.</param>
        private void AddNewMember(SelectedUserInformation userInfo, float value)
        {
            IMemberInfo member = new SimpleMember(userInfo, value);

            if (_addMemberToListMethod != null)
                _addMemberToListMethod(member);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _addMemberToListMethod = null;
        }

        #endregion
    }
}
