using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GiveItBack.Model.Pages;
using GiveItBack.Resources;
using Microsoft.Phone.UserData;
using Tools;

namespace GiveItBack.ViewModel
{
    public class AddMemberVM : ViewModelBase
    {
        #region Private Members

        private ContactsSearcher _contactsSearch;
        private AddMemberM _model;

        /// <summary>
        /// Prywatna lista zawierająca wynik przeszukiwania kontaktów.
        /// </summary>
        private List<SelectedMember> _visibleContacts;

        /// <summary>
        /// Prywatna zmienna przechowująca wartość wpisaną w polu z nazwą uczestnika. Wartość może służyć do przeszukiwania kontaktów.
        /// </summary>
        private string _memberName = string.Empty;

        /// <summary>
        /// Prywatna flaga informująca o trybie wprowadzania uczestnika (wartość z kontaktów lub bezpośrednio z pola tekstowego).
        /// </summary>
        private bool _addFromContacts = true;

        private const string PROP_SEARCH_STATE = "SearchState";
        private const string PROP_ADD_FOM_CONTACTS = "AddFromContacts";
        private const string PROP_MEMBER_NAME = "MemberName";
        private const string PROP_VISIBLE_CONTACTS = "VisibleContacts";
       
        #endregion

        /// <summary>
        /// Zwraca aktualny stan przeszukiwania kontaktów.
        /// </summary>
        public string SearchState
        {
            get
            {
                if (AddFromContacts && _contactsSearch.SeachInit)
                {
                    if (_contactsSearch.Searching)
                        return AppResources.strContactsSearching;
                    else
                    {
                        if (VisibleContacts.Any())
                            return string.Format("{0}: {1}.", AppResources.strFoundContactsCount, VisibleContacts.Count);
                        else
                            return AppResources.strNoContactsFound;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Zwraca lub ustawia flagę określającą źródło utworzenia uczestnika zbióreczki.
        /// </summary>
        public bool AddFromContacts
        {
            get { return _addFromContacts; }
            set
            {
                if (value != AddFromContacts)
                {
                    if (VisibleContacts != null && VisibleContacts.Any())
                        VisibleContacts = null;

                    _addFromContacts = value;
                    RaisePropertyChanged(PROP_ADD_FOM_CONTACTS);
                }
            }
        }

        /// <summary>
        /// Zwraca lub ustawia nazwę wpisaną w polu tekstowym formatki.
        /// </summary>
        public string MemberName 
        {
            get { return _memberName; }
            set
            {
                if (_memberName != value)
                {
                    _memberName = value;

                    if (AddFromContacts)
                        _contactsSearch.StartSearching(_memberName);

                    RaisePropertyChanged(PROP_SEARCH_STATE);
                }
            }
        }

        /// <summary>
        /// Zwraca listę kontaktów wyszukanych w telefonie.
        /// </summary>
        public List<SelectedMember> VisibleContacts
        {
            get { return _visibleContacts; }
            private set
            {
                if ((_visibleContacts = value) == null)
                    _contactsSearch.ClearSearchData();

                RaisePropertyChanged(PROP_VISIBLE_CONTACTS);
                RaisePropertyChanged(PROP_SEARCH_STATE);
            }
        }

        /// <summary>
        /// Zwraca lub ustawia indeks aktualnie zaznaczonego kontaktu.
        /// </summary>
        public int SelectedContact { get; set; }

        /// <summary>
        /// Tworzy ViewModel dla modułu dodawania nowego uczestnika zrzuteczki.
        /// </summary>
        /// <param name="model">Model.</param>
        public AddMemberVM(AddMemberM model)
        {
            SelectedContact = -1;
            VisibleContacts = new List<SelectedMember>();

            _contactsSearch = new ContactsSearcher(CollectSearchResult);

            _model = model;
            _model.GetSelectedMember = GetMemberInfo;
        }

        #region Private Methods

        /// <summary>
        /// Ustawia kolekcję wyszukanych kontaktów.
        /// </summary>
        /// <param name="members">Lista znalezionych kontaktów.</param>
        private void CollectSearchResult(List<SelectedMember> members)
        {
            VisibleContacts = members;

            RaisePropertyChanged(PROP_VISIBLE_CONTACTS);
            RaisePropertyChanged(PROP_SEARCH_STATE);
        }

        /// <summary>
        /// Zbiera dane wpisne na formatce i przekazuje je do modelu.
        /// </summary>
        private void GetMemberInfo()
        {
            if (!AddFromContacts)
            {
                if (!string.IsNullOrEmpty(MemberName))
                    _model.GoToValuePage(new SelectedMember() { Name = MemberName });
                else
                    MessageBox.Show(AppResources.strNonSelectedMember, AppResources.strAddMemWarTopic, MessageBoxButton.OK);
            }
            else
            {
                if (SelectedContact != -1)
                    _model.GoToValuePage(VisibleContacts[SelectedContact]);
                else
                    MessageBox.Show(AppResources.strNonSelectedContact, AppResources.strAddMemWarTopic, MessageBoxButton.OK);
            }
        }

        #endregion
    }
}
