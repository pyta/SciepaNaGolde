using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;

namespace GiveItBack.Model.Pages
{
    public class ServiceTestM :PageBase
    {

        public override System.Windows.Controls.Control Content
        {
            get
            {
                var page = new ServiceTestPage() { DataContext = new ServiceTestVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return null; } }

        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if (value)
                {
                    StatusColor = "Green";
                }
                else
                    StatusColor = "Red";

                _isConnected = value;
            }
        }

        public string StatusColor = "Red";

        private string _status = "Brak połączenia";

        public string StatusMessage
        {
            get
            {
                return "Connection";

            }
            set
            {
                _status = value;
            }

        }
        public ServiceTestM(IAppPage previousPage)
            : base(previousPage)
        { 
        
        }


    }
}
