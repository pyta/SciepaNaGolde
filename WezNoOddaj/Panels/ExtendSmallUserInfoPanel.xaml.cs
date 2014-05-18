using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.Windows.Media;

using WezNoOddajLib.Members;
using WezNoOddaj.Members;
using WezNoOddaj.Members.Helpers;

namespace WezNoOddaj.Panels
{
    public partial class ExtendSmallUserInfoPanel : UserControl
    {
        #region Members

        private IMemberInfo _memberInfo;

        /// <summary>
        /// Delegat na metodę usuwającą pozycję.
        /// </summary>
        private Action<IMemberInfo> _delSelctedItemMethod;

        #endregion

        public ExtendSmallUserInfoPanel(IMemberInfo memberInfo, Action<IMemberInfo> delSelectedItemMethod)
        {
            InitializeComponent();

            _memberInfo = memberInfo;
            _delSelctedItemMethod = delSelectedItemMethod;

            FillData();
        }

        #region Private methods

        /// <summary>
        /// Wypełnienie kontrolki danymi.
        /// </summary>
        private void FillData()
        {
            if (_memberInfo != null)
                FillData(_memberInfo);
        }

        /// <summary>
        /// Wypełnienie kontrolki danymi.
        /// </summary>
        /// <param name="memberInfo"></param>
        private void FillData(IMemberInfo memberInfo)
        {
            if (memberInfo is SimpleMember)
            {
                SimpleMember member = memberInfo as SimpleMember;

                imgAvatar.Source = member.Avatar;
                lblName.Text = member.DisplayName;
                lblShare.Text = string.Format("{0:0.00} zł", member.Share);
                rectColor.Fill = new SolidColorBrush(member.Color);
            }
        }

        /// <summary>
        /// Usuwanie zaznaczonej pozycji.
        /// </summary>
        private void DelSelectedItem()
        {
            if (_delSelctedItemMethod != null)
                _delSelctedItemMethod(_memberInfo);
        }

        #endregion

        #region Event handlers

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DelSelectedItem();
        }

        #endregion
    }
}
