using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;

namespace GiveItBack.Model.Pages
{
    public class FundraisingM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new FundraisingPage();
                return base.SetDefaultPageAttributes(page);
            }
        }

        public FundraisingM(IAppPage previousPage)
            : base(previousPage)
        { 
        
        }
    }
}
