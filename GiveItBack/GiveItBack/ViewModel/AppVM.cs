using System;
using System.Windows.Controls;
using Common.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GiveItBack.Model;

namespace GiveItBack.ViewModel
{
    public class AppVM : ViewModelBase
    {
        #region Private Members

        private AppModel _appModel;
        private readonly IAppService _dataService;

        #endregion

        public IAppPage CurrentPage
        {
            get { return _appModel.CurrentPage; }
            set
            {
                if (_appModel.CurrentPage != value)
                {
                    _appModel.CurrentPage = value;
                    RaisePropertyChanged("CurrentPage");
                }
            }
        }

        public string Version
        {
            get { return _appModel.VersionNumber; }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public AppVM(IAppService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // TODO: Report error here
                        return;
                    }

                    _appModel = item;
                    _appModel.CurrentPageChanged += CurrentPageChanged;
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private void CurrentPageChanged()
        {
            // _TODO_PC: W zależności od czegośtam inaczej można zmieniać strony. Albo i nie.

            //var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();

            //var uri = new Uri("/Windows/" + CurrentPage.Content.ToString() + ".xaml", UriKind.Relative);
            //navigationService.NavigateTo(uri);

            RaisePropertyChanged("CurrentPage");
        }
    }
}
