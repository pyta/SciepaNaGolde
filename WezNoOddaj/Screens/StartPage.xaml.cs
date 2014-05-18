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

namespace WezNoOddaj.Screens
{
    public partial class StartPage : UserControl
    {
        #region Members
        
        #endregion

        public StartPage(Action AddNewMember, Action ClearCollection, Action<IMemberInfo> DelSelectedItem, Action ShowResult, List<IMemberInfo> members)
        {
            InitializeComponent();

            Margin = new Thickness(0, 0, 0, 0);

            panelAddNewCollection.AddNewMemberMethod += AddNewMember;
            panelAddNewCollection.ShowResultMethod += ShowResult;
            panelAddNewCollection.RefreshData(members);

            panelMembersList.DelSelectedItemMethod += DelSelectedItem;
            panelMembersList.ClearListMethod += ClearCollection;
            panelMembersList.FillList(members);
        }
    }
}
