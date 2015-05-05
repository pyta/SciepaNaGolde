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
        #region Private Members

        /// <summary>
        /// Prywatna zmienna przechowująca model okna startowego.
        /// </summary>
        private WelcomeM _model;

        #endregion

        public string AppName { get { return "Give It Back!"; } }

        public IAppPage StartModel { get { return _model.StartModel; } }
        public IAppPage HistoryModel { get { return _model.HistoryModel; } }

        public WelcomeVM(WelcomeM model)
        {
            _model = model;
        }
    }
}
