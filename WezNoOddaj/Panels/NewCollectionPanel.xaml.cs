using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using WezNoOddajLib.Members;
using WezNoOddaj.Members.Helpers;

namespace WezNoOddaj.Panels
{
    public partial class NewCollectionPanel : UserControl
    {
        #region Members

        /// <summary>
        /// Metoda wywoływana w momencie przyciśnięcia na guzik dodający nowego użytkownika.
        /// </summary>
        public Action AddNewMemberMethod;

        /// <summary>
        /// Metoda wywoływana w momencie przyciśnięcia na guzik Przelicz.
        /// </summary>
        public Action ShowResultMethod;

        #endregion

        public NewCollectionPanel()
        {
            InitializeComponent();
        }

        #region Public methods

        /// <summary>
        /// Wyczyszczenie kontrolki.
        /// </summary>
        public void RefreshData()
        {
            RefreshData(new List<IMemberInfo>());            
        }

        /// <summary>
        /// Ustawienie danych na kontrolkach na podstawie kolekcji.
        /// </summary>
        /// <param name="members"></param>
        public void RefreshData(List<IMemberInfo> members)
        {
            float totalShare = members.Sum(m => m.Share);

            lblSum.Text = string.Format("Suma: {0:0.00} zł", totalShare);
            lblMembersCount.Text = string.Format("Liczba użytkowników: {0}", members.Count);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Wykonanie obliczeń.
        /// </summary>
        private void CalculateResult()
        {
            if (ShowResultMethod != null)
                ShowResultMethod();
        }

        #endregion

        #region Event handlers

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            if (AddNewMemberMethod != null)
                AddNewMemberMethod();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
        }

        #endregion
    }
}
