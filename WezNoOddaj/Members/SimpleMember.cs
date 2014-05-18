using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;

using WezNoOddajLib.Members;
using WezNoOddaj.Screens;
using WezNoOddaj.Members.Helpers;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WezNoOddaj.Members
{
    public class SimpleMember : IMemberInfo
    {
        #region Member

        private SelectedUserInformation _userInfo;

        #endregion

        public SimpleMember(SelectedUserInformation userInfo, float value)
        {
            _userInfo = userInfo;

            // _TODO: Zaokrąglić kwotę do dwóch miejsc po przecinku.

            Share = value;
        }

        public SimpleMember()
        {
            _userInfo = new SelectedUserInformation();
        }

        #region IMemberInfo Members

        public string DisplayName
        {
            get { return _userInfo.UserName; }
        }

        public float Share { get; set; }

        #endregion

        public BitmapImage Avatar
        { 
            get { return _userInfo.Avatar; } 
            set { _userInfo.Avatar = value; } 
        }

        public Color Color 
        {
            get { return _userInfo.Color; }
            set { _userInfo.Color = value; }
        }
    }
}
