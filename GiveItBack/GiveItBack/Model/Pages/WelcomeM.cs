using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.ViewModel;

namespace GiveItBack.Model.Pages
{
    public class WelcomeM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new WelcomePage() { DataContext = new WelcomeVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public IAppPage StartModel { get; private set; }
        public IAppPage HistoryModel { get; private set; }
        public IAppPage AboutModel { get; private set; }

        public WelcomeM(IAppPage previousPage)
            : base(previousPage)
        {
            StartModel = new StartM(this);
            HistoryModel = new HistoryM(this);
            AboutModel = new AboutM(this);
        }
    }
}
