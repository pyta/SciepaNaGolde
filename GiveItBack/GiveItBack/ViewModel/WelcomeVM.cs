using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GiveItBack.Model.Pages;

namespace GiveItBack.ViewModel
{
    public class WelcomeVM : ViewModelBase
    {
        private WelcomeM _model;

        public IAppPage StartModel 
        {
            get { return _model.StartModel; }
        }

        public IAppPage HistoryModel
        {
            get { return _model.HistoryModel; }
        }

        public WelcomeVM(WelcomeM model)
        {
            _model = model;
        }
    }
}
