using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;
using GalaSoft.MvvmLight.Command;

namespace GiveItBack.ViewModel
{
    public class AboutVM : ViewModelBase
    {
        #region Private Members

        /// <summary>
        /// Prywatna zmienna przechowująca model okna z informacjami o autorach.
        /// </summary>
        private AboutM _model;

        #endregion

        public RelayCommand ShowServiceTest { get; private set; }

        public AboutVM(AboutM model)
        {
            _model = model;
            ShowServiceTest = new RelayCommand(_model.GoToTestService);
        }
    }
}
