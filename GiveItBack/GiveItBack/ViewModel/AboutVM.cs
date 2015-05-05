using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;

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

        public AboutVM(AboutM model)
        {
            _model = model;
        }
    }
}
