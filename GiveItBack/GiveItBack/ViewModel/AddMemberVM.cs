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
using Microsoft.Phone.UserData;
using Tools;
using Tools.Controls;

namespace GiveItBack.ViewModel
{
    public class AddMemberVM : ViewModelBase
    {
        #region Private Members

        private AddMemberM _model;
        private Contacts _cons;

        private List<string> _filters = new List<string>();
        private List<SelectedMember> _contacts;
       
        #endregion

        /// <summary>
        /// Zwraca listę kontaktów wyszukanych w telefonie.
        /// </summary>
        public List<ContactFindResult> VisibleContacts 
        {
            get
            {
                var contacts = new List<ContactFindResult>();

                if (_contacts != null)
                {
                    foreach (var m in _contacts)
                    {
                        var control = new ContactFindResult()
                        {
                            DataContext = m,
                            Width = double.NaN,
                            Height = 79.0d,
                            Margin = new Thickness(0)
                        };

                        contacts.Add(control);
                    }
                }

                return contacts;
            }
        }

        public int SelectedContact
        {
            get { return _model.SelectedContact; }
            set
            {
                if (value != SelectedContact && value != -1)
                {
                    _model.SelectedContact = value;

                    for (int i = 0; i < _contacts.Count; ++i)
                        _contacts[i].IsSelected = (i == SelectedContact);

                    RaisePropertyChanged("VisibleContacts");
                }
            }
        }

        public bool AddFromContacts
        {
            get { return _model.AddFromContacts; }
            set
            {
                if (value != AddFromContacts)
                {
                    _model.AddFromContacts = value;

                    if (!AddFromContacts)
                    {
                        if (_contacts != null)
                            _contacts.Clear();

                        RaisePropertyChanged("VisibleContacts");
                    }

                    RaisePropertyChanged("AddFromContacts");
                }
            }
        }

        public string MemberName 
        {
            get { return _model.MemberName; }
            set
            {
                if (value != MemberName)
                {
                    _model.MemberName = value;
                    RaisePropertyChanged("MemberName");
                }
            }
        }

        public RelayCommand FindContactsCommand { get; private set; }

        public AddMemberVM(AddMemberM model)
        {
            _cons = new Contacts();
            _cons.SearchCompleted += cons_SearchCompleted;

            _model = model;

            FindContactsCommand = new RelayCommand(FindContacts);
        }

        public void SelectMember()
        {
            if (AddFromContacts)
            {
                if (SelectedContact == -1)
                    MessageBox.Show("Nie wybrano żadnego kontaktu!");
                else
                { 
                    
                }
            }
            else
            {
                if (string.IsNullOrEmpty(MemberName))
                    MessageBox.Show("Nie wpisaneo żadnego tesktu!");
                else
                { 
                
                }
            }
        }

        #region Private Methods

        private void FindContacts()
        {
            FilterContacts(MemberName);
        }

        private void FilterContacts(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                _filters.Add(filter);
                _cons.SearchAsync(filter, FilterKind.DisplayName, filter);
            }
            else
            {
                _contacts.Clear();
            }
        }

        void cons_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (e.State.ToString() == _filters.Last())
            {                
                _contacts = CreateMembersList(e);
                _model.SelectedContact = -1;

                RaisePropertyChanged("VisibleContacts");
            }
        }

        private List<SelectedMember> CreateMembersList(ContactsSearchEventArgs e)
        {
            List<SelectedMember> result = new List<SelectedMember>();

            foreach (var c in e.Results)
            {
                SelectedMember m = new SelectedMember()
                {
                    Name = c.DisplayName,
                    Avatar = ToolsKit.GetImageFromConcat(c)
                };

                // TODO: Pobrać ewentualnie dodatkowe informacje.

                result.Add(m);
            }

            return result;
        }

        #endregion
    }
}
