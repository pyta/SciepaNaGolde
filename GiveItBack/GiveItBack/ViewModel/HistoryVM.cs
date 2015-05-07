using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;

namespace GiveItBack.ViewModel
{
    public class HistoryVM : ViewModelBase
    {
        #region Private Members

        private HistoryM _model;

        #endregion

        public HistoryVM(HistoryM model)
        {
            _model = model;
        }
    }
}
