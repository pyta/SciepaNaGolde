using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GiveItBack.Model.Pages;
using Telerik.Charting;

namespace GiveItBack.ViewModel
{
    public class FundraisingVM : ViewModelBase
    {
        #region Private Members

        private FundraisingM _model;

        #endregion

        public List<MemberInfo> DataPoints { get { return _model.MembersInfo; } }

        public string SumText
        {
            get
            {
                var sum = _model.MembersInfo.Sum(x => x.Value);
                return string.Format("Łączna kwaota {0:0.00} zł", sum);
            }
        }

        public RelayCommand GoToAddMember { get; private set; }
       
        public FundraisingVM(FundraisingM model)
        {
            _model = model;

            GoToAddMember = new RelayCommand(_model.GoToAddMember);
        }

        #region Private Methods

        #endregion
    }
}
