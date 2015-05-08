using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Model;
using Microsoft.Phone.Shell;

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

        public abstract ApplicationBar ApplicationBar { get; }

        protected PageBase(IAppPage previousPage)
        {
            _previousPage = previousPage;
        }

        /// <summary>
        /// Cofa się do poprzedniej strony.
        /// </summary>
        public void Back()
        {
            if (_previousPage != null)
                GoToPage(_previousPage);
        }

        /// <summary>
        /// Ustawia przekazaną podstronę jako aktualnie wyświetlaną w aplikacji.
        /// </summary>
        /// <param name="newPage">Podstrona do wyświetlenia.</param>
        protected void GoToPage(IAppPage newPage)
        {
            AppModel.AppModelInstance.CurrentPage = newPage;
        }

        /// <summary>
        /// Ustawia domyślne właściwości kontrolek.
        /// </summary>
        /// <param name="page">Kontrolka.</param>
        /// <returns>Kontrolka wzbogacona o domyślne właściwości związane z wyświetlaniem na ekranie.</returns>
        protected Control SetDefaultPageAttributes(Control page)
        {
            page.Margin = new Thickness(0);
            page.Height = page.Width = double.NaN;

            return page;
        }
    }
}
