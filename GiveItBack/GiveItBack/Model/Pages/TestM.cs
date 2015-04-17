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
    public class TestM : PageBase
    {
        public string Header { get { return "To jest okno testowe"; } }

        public new Control Content
        {
            get { return new TestPage(); }
        }

        public TestM(IAppPage previousPage)
            : base(previousPage)
        { 
        
        }
    }
}
