using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Common.Interfaces;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;

namespace GiveItBack.ViewModel
{
    public class WorkVM : ViewModelBase
    {
        #region Private Members

        private WorkM _model;

        #endregion

        public FrameworkElement TopicControl { get; private set; }

        public IAppPage FundraisingModel { get { return _model.FundraisingModel; } }
        public IAppPage MembersModel { get { return _model.MembersModel; } }

        public WorkVM(WorkM model)
        {
            _model = model;
            TopicControl = CreateTopicControl();
        }

        private FrameworkElement CreateTopicControl()
        {
            // TODO: Utwrzyć jakiś element graficzny.

            return new TextBlock() { Text = "GiveItBack" };
        }
    }
}
