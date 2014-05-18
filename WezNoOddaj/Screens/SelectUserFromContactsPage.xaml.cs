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
using WezNoOddaj.Panels;

namespace WezNoOddaj.Screens
{
    public delegate void FillListDelegate(List<SelectedUserInformation> concats);

    public partial class SelectUserFromContactsPage : UserControl
    {
        #region Members

        /// <summary>
        /// Metoda do otwarcia okna z możliwością wprowadzenia kwoty dla wybranego użytkownika.
        /// </summary>
        public Action<SelectedUserInformation> InsertValueMethod;

        /// <summary>
        /// Wybrany użytkownik.
        /// </summary>
        private SelectedUserInformation _selectedUser;

        #endregion

        public SelectUserFromContactsPage()
        {
            InitializeComponent();
            panelFilterConcats.FillListMethod += FillList;            
        }

        #region Private methods

        /// <summary>
        /// Wypełnienie listy wartościami.
        /// </summary>
        /// <param name="concats"></param>
        private void FillList(List<SelectedUserInformation> concats)
        {
            listConcats.Items.Clear();

            foreach (SelectedUserInformation info in concats)
            {
                SmallUserInfoPanel smallPanel = new SmallUserInfoPanel(info, false)
                {
                    Width = listConcats.Width
                };

                listConcats.Items.Add(smallPanel);
            }
        }

        /// <summary>
        /// Otwarcie okna z możliwością wprowadznie kworty.
        /// </summary>
        private void OpenInsertValuePage()
        {
            if (InsertValueMethod != null)
            {
                if (( _selectedUser = GetSelectedUserFromList()) == null)
                {
                    // _TODO_PC: [Komunikat] dopracować.

                    MessageBox.Show(
                        "Nie została wybrana żadna wartość.",
                        "Wybór kontaktu",
                        MessageBoxButton.OK);
                }
                else
                {
                    InsertValueMethod(_selectedUser);
                }
            }
        }

        /// <summary>
        /// Pobieranie informacji o użytkowniku z listy kontaktów.
        /// </summary>
        /// <returns></returns>
        private SelectedUserInformation GetSelectedUserFromList()
        {
            SelectedUserInformation result = null;

            try
            {
                if (panelFilterConcats.SelectFromContact)
                {
                    if (listConcats.SelectedIndex != -1)
                        result = ((SmallUserInfoPanel)listConcats.Items[listConcats.SelectedIndex]).UserInfo;
                }
                else
                {
                    result = GetSelectedUserFromTextBox();
                }

                if (result != null)
                    result.Color = ColorGenerator.GetColor();
            }
            catch (Exception ex)
            {
                // _TODO_PC [Błąd] Dodać loga.

                result = null;
            }

            return result;
        }

        /// <summary>
        /// Pobieranie informacji o wybranym użytkowniku z kontrolki tekstowej.
        /// </summary>
        /// <returns></returns>
        private SelectedUserInformation GetSelectedUserFromTextBox()
        {
            SelectedUserInformation result = null;

            if (!string.IsNullOrEmpty(panelFilterConcats.NewUserName))
            {
                result = new SelectedUserInformation();

                result.UserName = panelFilterConcats.NewUserName;
                result.Color    = ColorGenerator.GetColor();
            }

            return result;
        }

        /// <summary>
        /// Ustawienie fokusa na zaznaczony obiekt na liście.
        /// </summary>
        private void SetFocusOnSelectedItem()
        {
            foreach (object obj in listConcats.Items)
                ((SmallUserInfoPanel)obj).UnfocusPanel();

            if (listConcats.SelectedIndex != -1)
                ((SmallUserInfoPanel)listConcats.Items[listConcats.SelectedIndex]).FocusPanel();
        }

        #endregion

        #region Event handlers

        private void btnSelectUser_Click(object sender, RoutedEventArgs e)
        {
            OpenInsertValuePage();
        }

        private void listConcats_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SetFocusOnSelectedItem();
        }

        #endregion

        #region Pubic method

        /// <summary>
        /// Wyświetlanie klawiatury.
        /// </summary>
        public void ShowAlphaKeyboard()
        {
            panelFilterConcats.ShowAlphaKeyboard();
        }

        #endregion        
    }
}
