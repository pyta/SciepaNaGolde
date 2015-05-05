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
    /// <summary>
    /// Klasa zarządzająca stroną poświęconą historii łożenia pięniądzorów.
    /// </summary>
    public class HistoryM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new HistoryPage();
                return base.SetDefaultPageAttributes(page);
            }
        }

        public string Header
        {
            get
            {
                // TODO: Jakiś tytuł.
                return "tytuł2";
            }
        }

        public HistoryM(IAppPage previousPage)
            : base(previousPage)
        {

        }
    }
}
