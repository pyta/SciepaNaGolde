using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using WezNoOddaj.Members.Helpers;

namespace WezNoOddaj.Panels
{
    /// <summary>
    /// Panel reprezentujący obecnie wybranego użytkownika z możliwością zmiany.
    /// </summary>
    public partial class SelectedUserInfoPanel : UserControl
    {
        #region Members

        private SelectedUserInformation _userInfo;

        /// <summary>
        /// Aktualnie wybrany użytkownik.
        /// </summary>
        public SelectedUserInformation UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                _userInfo = value;
                FillData();
            }
        }

        public Action ChangeSelectedUserMethod;

        #endregion

        public SelectedUserInfoPanel()
        {
            InitializeComponent();
        }

        #region Event handlers

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelectedUser();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Zmiana aktualnie wybrango użytkownika.
        /// </summary>
        private void ChangeSelectedUser()
        {
            if (ChangeSelectedUserMethod != null)
                ChangeSelectedUserMethod();
        }

        /// <summary>
        /// Wypełnianie kontrolki danymi.
        /// </summary>
        private void FillData()
        {
            FillData(UserInfo);
        }

        /// <summary>
        /// Wypełnianie kontrolki danymi.
        /// </summary>
        /// <param name="selectedUserInformation">Obiekt reprezentujący podstawowe informacje o użytkowniku.</param>
        private void FillData(SelectedUserInformation selectedUserInformation)
        {
            labelUserName.Text = ValidateTextWidth(selectedUserInformation.UserName);
            imgAvatar.Source = selectedUserInformation.Avatar;
            rectColor.Fill = new SolidColorBrush(_userInfo.Color);
        }

        /// <summary>
        /// Walidacja długości tekstu. Jeżeli jest za długi to zostanie rozbity na dwa wiersze w momencie napotkania spacji.
        /// </summary>
        /// <param name="text">Tekst do sprawdzenia.</param>
        /// <returns>Zmodyfikowany tekst. Do jego zawartości eentualnie zostaną dodane znaki nowego wiersza.</returns>
        private string ValidateTextWidth(string text)
        {
            return ValidateTextWidth(text, labelUserName.Width);
        }

        /// <summary>
        /// Walidacja długości tekstu. Jeżeli jest za długi to zostanie rozbity na dwa wiersze w momencie napotkania spacji.
        /// </summary>
        /// <param name="text">Tekst do sprawdzenia.</param>
        /// <param name="len">Maksymalna długość tekstu.</param>
        /// <returns>Zmodyfikowany tekst. Do jego zawartości eentualnie zostaną dodane znaki nowego wiersza.</returns>
        private string ValidateTextWidth(string text, double len)
        {
            // _TODO: Dodanie rozbijania na wiersze w razie potrzeby.

            return text;
        }

        #endregion
    }
}
