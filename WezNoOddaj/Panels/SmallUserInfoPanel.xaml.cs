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
    public partial class SmallUserInfoPanel : UserControl
    {
        #region Members

        public SelectedUserInformation UserInfo { get; set; }

        #endregion

        public SmallUserInfoPanel(SelectedUserInformation userInfo, bool showColor)
        {
            InitializeComponent();

            UserInfo = userInfo;
            FillData(UserInfo, showColor);
        }

        #region Private methods

        /// <summary>
        /// Wypełnienie kontrolki danymi.
        /// </summary>
        private void FillData()
        {
            FillData(UserInfo, true);
        }

        /// <summary>
        /// Wypełnienie kontrolki danymi.
        /// </summary>
        /// <param name="userInfo">Obiekt reprezentujący informacje o użytkowniku.</param>
        private void FillData(SelectedUserInformation userInfo, bool showColor)
        {
            if (showColor)
                rectColor.Fill = new SolidColorBrush(userInfo.Color);

            imgAvatar.Source = userInfo.Avatar;
            txtBoxName.Text = userInfo.UserName;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Zaznaczenie panelu.
        /// </summary>
        public void FocusPanel()
        {
            //border.Visibility = System.Windows.Visibility.Visible;

            txtBoxName.FontWeight = FontWeights.Bold;
            txtBoxName.Foreground = new SolidColorBrush(Colors.Purple);
        }

        /// <summary>
        /// Odznaczenie panelu.
        /// </summary>
        public void UnfocusPanel()
        {
            //border.Visibility = System.Windows.Visibility.Collapsed;

            txtBoxName.FontWeight = FontWeights.Normal;
            txtBoxName.Foreground = new SolidColorBrush(Colors.White);
        }

        #endregion
    }
}
