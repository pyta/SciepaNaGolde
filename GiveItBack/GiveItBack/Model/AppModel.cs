using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;

namespace GiveItBack.Model
{
    /// <summary>
    /// Klasa reprezentująca stan głównego okna aplkacji.
    /// </summary>
    public class AppModel : ViewModelBase
    {
        #region Private Members

        private IAppPage _currentPage;

        #endregion

        private static AppModel _appModel;
        public static AppModel AppModelInstance
        {
            get
            {
                if (_appModel == null)
                    _appModel = new AppModel();

                return _appModel;
            }
        }

        /// <summary>
        /// Zwraca lub ustawia wskaźnik na metodę, która wywoływana jest w momencie zmiany aktualnie wyświetlanej strony.
        /// </summary>
        public Action CurrentPageChanged { get; set; }

        /// <summary>
        /// Zwraca numer wersji aplikacji.
        /// </summary>
        public string VersionNumber { get; private set; }

        /// <summary>
        /// Zwraca lub ustawia aktualnie wyświetlaną stronę.
        /// </summary>
        public IAppPage CurrentPage 
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;

                    if (CurrentPageChanged != null)
                        CurrentPageChanged();
                }
            }
        }

        private AppModel()
        {
            VersionNumber = GetVersionNumber();
            _currentPage = GetStartPage();
        }

        #region Private Methods

        private string GetVersionNumber()
        { 
            // TODO: Pobrać numer wesji.

            return "??";
        }

        private IAppPage GetStartPage()
        {
            return new StartM(null);
        }

        #endregion
    }
}
