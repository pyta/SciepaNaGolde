using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GiveItBack.Model.Pages;

namespace GiveItBack.ViewModel
{
    public class StartVM : ViewModelBase
    {
        private StartM _model;

        public string Header
        {
            get { return _model.Header; }
        }

        public StartVM(StartM model)
        {
            _model = model;
            GoToTest = new RelayCommand(_model.GoToTest);
        }

        public RelayCommand GoToTest { get; private set; }
    }
}
