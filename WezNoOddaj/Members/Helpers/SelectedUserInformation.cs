using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WezNoOddaj.Members.Helpers
{
    public class SelectedUserInformation
    {
        public string UserName { get; set; }
        public BitmapImage Avatar { get; set; }
        public Color Color { get; set; }

        public override string ToString()
        {
            return UserName;
        }
    }
}
