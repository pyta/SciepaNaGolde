using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Model;

namespace GiveItBack
{
    public class PageBase : IAppPage
    {
        #region Private Members

        private IAppPage _previousPage;

        #endregion

        public IAppPage PreviousPage
        {
            get { return _previousPage; }
        }

        public Control Content
        {
            get { return null; }
        }

        protected PageBase(IAppPage previousPage)
        {            
            _previousPage = previousPage;
        }

        protected void GoToPage(IAppPage newPage)
        {
            AppModel.AppModelInstance.CurrentPage = newPage;
        }
    }
}
