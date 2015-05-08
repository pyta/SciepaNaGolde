using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;

namespace GiveItBack.Model.Pages
{
    /// <summary>
    /// Klasa zarządzająca stroną poświęconą historii łożenia pięniądzorów.
    /// </summary>
    public class HistoryM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new HistoryPage() { DataContext = new HistoryVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return null; } }

        public string Header
        {
            get { return "Historia"; }
        }

        public HistoryM(IAppPage previousPage)
            : base(previousPage)
        {

        }
    }
}
