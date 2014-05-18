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
using WezNoOddaj.Panels;

namespace WezNoOddaj.Panels
{
    public partial class MembersListPanel : UserControl
    {
        #region Member

        /// <summary>
        /// Metoda do usuwania zaznaczongo obiektu.
        /// </summary>
        public Action<IMemberInfo> DelSelectedItemMethod { get; set; }

        /// <summary>
        /// Metoda do czyszczenia listy.
        /// </summary>
        public Action ClearListMethod { get; set; }

        #endregion

        public MembersListPanel()
        {
            InitializeComponent();
        }

        #region Public method

        /// <summary>
        /// Wypełnienie listy 
        /// </summary>
        /// <param name="members"></param>
        public void FillList(List<IMemberInfo> members)
        {
            listMembers.Items.Clear();

            foreach (IMemberInfo member in members)
            {
                ExtendSmallUserInfoPanel smallPanel = new ExtendSmallUserInfoPanel(member, DelSelectedItemMethod)
                {
                    Margin = new Thickness(0,0,0,0)
                };

                listMembers.Items.Add(smallPanel);
            }

            lblCaption.Text = members.Any() ? string.Format("Liczba udziałów: {0}.", members.Count) : "Lista jest pusta!";
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearList();
        }

        /// <summary>
        /// Wyczyszczenie listy udziałowców.
        /// </summary>
        private void ClearList()
        {
            if (ClearListMethod != null)
                ClearListMethod();
        }
    }
}
