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
    /// <summary>
    /// Klasa zarządająca startowym oknem aplikacji.
    /// </summary>
    public class StartM : PageBase
    {
        public StartM(IAppPage previousPage)
            : base(previousPage)
        {
            
        }

        public override Control Content
        {
            get { return new StartPanel() { DataContext = new StartVM(this) }; }
        }

        public void GoToMembers()
        {
            // TODO: Przejście do tworzenia listy.
        }

        public void GoToAuthors()
        {
            // TODO: Przejście do strony about.
        }
    }
}
