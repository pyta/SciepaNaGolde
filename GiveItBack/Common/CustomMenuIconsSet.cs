using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public class CustomMenuIconsSet : IMenuIconsSet
    {
        public string AddIcon
        {
            get { return "/Assets/Images/AppBar/check.png"; }
        }
    }
}
