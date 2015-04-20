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
    public abstract class PageBase : IAppPage
    {
        #region Private Members

        /// <summary>
        /// Prywatna zmienna przechowująca poprzednią podstronę.
        /// </summary>
        private IAppPage _previousPage;

        #endregion

        public IAppPage PreviousPage
        {
            get { return _previousPage; }
        }

        public abstract Control Content { get; }

        protected PageBase(IAppPage previousPage)
        {
            _previousPage = previousPage;
        }

        /// <summary>
        /// Ustawia przekazaną podstronę jako aktualnie wyświetlaną w aplikacji.
        /// </summary>
        /// <param name="newPage">Podstrona do wyświetlenia.</param>
        protected void GoToPage(IAppPage newPage)
        {
            AppModel.AppModelInstance.CurrentPage = newPage;
        }
    }
}
