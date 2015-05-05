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
        #region Private Members

        /// <summary>
        /// Prywatna zmienna przechowująca model okna głównego.
        /// </summary>
        private StartM _model;

        #endregion

        public RelayCommand ShowAuthors { get; private set; }
        public RelayCommand ShowMembers { get; private set; }

        public StartVM(StartM model)
        {
            _model = model;

            ShowAuthors = new RelayCommand(_model.GoToAuthors);
            ShowMembers = new RelayCommand(_model.GoToMembers);
        }
    }
}
