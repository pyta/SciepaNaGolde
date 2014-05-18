using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using WezNoOddaj.Members.Helpers;

namespace WezNoOddaj.Screens
{
    public partial class InsertValueForSelectedUserPage : UserControl
    {
        #region Members

        public Action ChangeSelectedUserMethod { get; set; }
        public Action<SelectedUserInformation, float> AddNewMemberMethod { get; set; }

        #endregion

        public InsertValueForSelectedUserPage(SelectedUserInformation userInfo)
        {
            InitializeComponent();

            panelUserInfo.UserInfo = userInfo;
            panelUserInfo.ChangeSelectedUserMethod += ChangeSelectedUser;
        }

        #region Private methods

        private void ChangeSelectedUser()
        {
            if (ChangeSelectedUserMethod != null)
                ChangeSelectedUserMethod();
        }

        /// <summary>
        /// Zatwierdzenie okna i dodanie nowego użytkownika do listy.
        /// </summary>
        private void AddNewMember()
        {
            float result = 0.0f;

            if (string.IsNullOrEmpty(txtValue.Text))
            {
                if (MessageBox.Show(
                    "Nie podano żadnej wartości. Zostanie dodana pozcyja bez wkładu własnego. Kontynuować?",
                    "Pytanie",
                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    result = 0.0f;
                }
                else
                {
                    return;
                }
            }
            else if (!float.TryParse(txtValue.Text.Replace('.', ','), out result))
            {
                MessageBox.Show(
                    "Wprowadzona wartość jest niepoprawna!",
                    "Uwaga",
                    MessageBoxButton.OK);

                return;
            }

            if (AddNewMemberMethod != null)
                AddNewMemberMethod(panelUserInfo.UserInfo, result);
        }

        #endregion

        #region Event handlers

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            AddNewMember();
        }

        #endregion

        #region Public method

        public void ShowNumericKeyboard()
        {
            txtValue.Focus();
        }

        #endregion
    }
}
