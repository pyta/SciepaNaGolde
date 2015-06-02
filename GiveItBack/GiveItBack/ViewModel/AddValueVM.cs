using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;
using GiveItBack.Resources;

namespace GiveItBack.ViewModel
{
    public class AddValueVM : ViewModelBase
    {
        #region Private Members

        private AddValueM _model;

        #endregion

        /// <summary>
        /// Pozwala na wpisanie wartości tekstowej na kontrolce modułu wkładu.
        /// </summary>
        public string ValueStr { get; set; }

        /// <summary>
        /// Zwraca nazwę uczestnika zrzuteczki.
        /// </summary>
        public string Name
        {
            get { return _model.Member.Name; }
        }

        /// <summary>
        /// Zwraca awatar uczestnika zrzuteczki.
        /// </summary>
        public BitmapImage Avatar
        {
            get { return _model.Member.Avatar; }
        }

        /// <summary>
        /// Tworzy obiekt zarządzający modułem wprowadzania wkładu uczestnika zrzuteczki.
        /// </summary>
        /// <param name="model"></param>
        public AddValueVM(AddValueM model)
        {
            _model = model;
            _model.GetValueInfo = GetValueInfo;
        }

        #region Private Members

        /// <summary>
        /// Pobiera dane o wprowadzonej wartości z wraca do modelu.
        /// </summary>
        private void GetValueInfo() 
        {
            if (!string.IsNullOrEmpty(ValueStr))
            {
                double result;
                if (double.TryParse(ValueStr, out result))
                    _model.GoToWorkPage(result);
                else
                    MessageBox.Show(AppResources.strInvalidValue, AppResources.strInvalidValueTopic, MessageBoxButton.OK);
            }
        }

        #endregion
    }
}
