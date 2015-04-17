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
    public class StartM : PageBase
    {
        public string Header { get { return "To jest okno startowe"; } }

        public StartM(IAppPage previousPage)
            : base(previousPage)
        { 
        
        }

        public new Control Content
        {
            get { return new StartPanel() { DataContext = new StartVM(this) }; }
        }

        public void GoToTest()
        {
            base.GoToPage(new TestM(this));
        }
    }
}
