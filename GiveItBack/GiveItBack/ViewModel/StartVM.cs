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

        public RelayCommand ShowAutors { get; private set; }

        public StartVM(StartM model)
        {
            _model = model;

            ShowAutors = new RelayCommand(_model.GoToAuthors);
        }
    }
}
