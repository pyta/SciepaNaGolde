using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tools
{
    public class SelectedMember
    {
        public string Name { get; set; }
        public BitmapImage Avatar { get; set; }

        public AdditionalMemberInfo AdditionalInfo { get; set; }

        public bool IsSelected { get; set; }

        public Brush Border
        {
            get 
            {
                if (IsSelected)
                    return new SolidColorBrush(Colors.Magenta);
                else
                    return new SolidColorBrush(Colors.Black);
            }
        }
    }

    public class AdditionalMemberInfo
    {
        public string PhoneNumber { get; set; }
    }
}
