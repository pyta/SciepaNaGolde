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
    public class HistoryM : PageBase
    {
        public override Control Content { get { return new HistoryPage(); } }

        public HistoryM(IAppPage previousPage)
            : base(previousPage)
        { 
        
        }
    }
}
