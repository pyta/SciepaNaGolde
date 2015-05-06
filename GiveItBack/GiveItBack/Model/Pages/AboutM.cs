using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.ViewModel;

namespace GiveItBack.Model.Pages
{
    public class AboutM : PageBase
    {
        public override Control Content
        {
            get 
            {
                var page = new AboutPage() { DataContext = new AboutVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public string Header
        {
            get { return "O autorach"; }
        }

        public AboutM(IAppPage previousPage)
            : base(previousPage)
        { 
        
        }
    }
}
