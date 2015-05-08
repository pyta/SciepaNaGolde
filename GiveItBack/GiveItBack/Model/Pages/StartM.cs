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
using Microsoft.Phone.Shell;

namespace GiveItBack.Model.Pages
{
    /// <summary>
    /// Klasa zarządająca startowym oknem aplikacji.
    /// </summary>
    public class StartM : PageBase
    {
        public override Control Content 
        {
            get
            {
                var page = new StartPage() { DataContext = new StartVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return null; } }

        public StartM(IAppPage previousPage)
            : base(previousPage)
        {
            
        }

        public string Header 
        {
            get { return "Nowa"; }
        }

        public void GoToMembers()
        {
            var work = new WorkM(base.PreviousPage);
            base.GoToPage(work);
        }

        public void GoToAuthors()
        {
            var authors = new AboutM(base.PreviousPage);
            base.GoToPage(authors);
        }
    }
}
