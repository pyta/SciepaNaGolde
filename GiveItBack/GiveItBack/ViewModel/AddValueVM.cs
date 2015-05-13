using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;

namespace GiveItBack.ViewModel
{
    public class AddValueVM : ViewModelBase
    {
        #region Private Members

        private AddValueM _model;

        #endregion

        public double Value 
        {
            get { return _model.Value; }
            set
            {
                if (value != _model.Value)
                {
                    _model.Value = value;
                    RaisePropertyChanged("Value");
                }
            }
        }

        public string Name
        {
            get { return _model.Member.Name; }
        }

        public BitmapImage Avatar
        {
            get { return _model.Member.Avatar; }
        }

        public AddValueVM(AddValueM model)
        {
            _model = model;
        }
    }
}
