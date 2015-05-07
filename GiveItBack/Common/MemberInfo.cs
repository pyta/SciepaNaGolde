using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Common
{
    public class MemberInfo
    {
        public BitmapImage Avatar { get; private set; }
        public string Name { get; private set; }
        public Color UserColor { get; private set; }
        public string PhoneNumber { get; private set; }
        public double Value { get; private set; }

        public Brush Brush 
        {
            get { return new SolidColorBrush(UserColor); }
        }

        public MemberInfo(string name, double value, Color color)
            : this(name, value, color, null, null)
        {

        }

        public MemberInfo(string name, double value, Color color, BitmapImage avatar, string phoneNumber)
        {
            Name = name;
            Value = value;
            UserColor = color;
            Avatar = avatar;
            PhoneNumber = phoneNumber;
        }
    }
}
