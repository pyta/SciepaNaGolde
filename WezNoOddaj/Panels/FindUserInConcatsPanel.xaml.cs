using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Windows.Media;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;

using WezNoOddaj.Members.Helpers;
using WezNoOddaj.Screens;

namespace WezNoOddaj.Panels
{
    /// <summary>
    /// Panel ma za zadanie przefiltrowanie kontaktów zapisanych w telefonie w celu uzyskania konkretnej pozycji. Po zakończeniu filtrowania wykonywana jest metoda,
    /// która została przypięta do publicznej właściwości FillListMethod.
    /// </summary>
    public partial class FindUserInConcatsPanel : UserControl
    {
        #region Members

        /// <summary>
        /// Historia przeszukiwania.
        /// </summary>
        private List<string> _searchHistory;

        /// <summary>
        /// Obiekt odpowiedzialny za zarządzanie kontaktami.
        /// </summary>
        private Contacts _contactsManager;

        /// <summary>
        /// Delegat na metodę, która ma zostać wywołana w chwili zakończenia filtrowania kontaktów.
        /// </summary>
        public FillListDelegate FillListMethod;

        /// <summary>
        /// Tekst wprowadzony przez użytkownika (posiada wartość tylko jeżeli wyszukiwanie kontaktów zostało wyłączone).
        /// </summary>
        public string NewUserName
        {
            get 
            {
                return !SelectFromContact ? txtBoxFilter.Text : string.Empty;
            }
        }

        #endregion

        public FindUserInConcatsPanel()
        {
            InitializeComponent();

            _contactsManager = new Contacts();
            _contactsManager.SearchCompleted += contacts_SearchCompleted;

            _searchHistory = new List<string>();
        }

        #region Events

        private void txtBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchConcats();
        }

        private void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            HandleSearchResult(e);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Wyciągnięcie z listy wyszukanych kontaktów niezbędnych informacji o użytkowniku.
        /// </summary>
        /// <param name="contacts">Lista wyszukanych kontaktów.</param>
        /// <returns>Lista obiektów typu SelectedUserInformation.</returns>
        private List<SelectedUserInformation> GetUserListFromSearchResult(List<Contact> contacts)
        {
            List<SelectedUserInformation> result = new List<SelectedUserInformation>();

            foreach (Contact contact in contacts)
            {
                SelectedUserInformation info = new SelectedUserInformation();
                
                info.UserName   = contact.DisplayName;
                info.Avatar     = GetImageFromConcat(contact);

                result.Add(info);
            }

            return result;
        }

        /// <summary>
        /// Wyciągnięcie obiektu typu BitmapImage z kontaktu.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        private BitmapImage GetImageFromConcat(Contact contact)
        {
            BitmapImage image = new BitmapImage();

            if (contact.GetPicture() != null)
                image.SetSource(contact.GetPicture());
            else
            { 
                // _TODO_PC: Ustawić jakiś domyślny.
            }

            return image;
        }

        /// <summary>
        /// Rozpoczęcie przeszukiwania kontaktów.
        /// </summary>
        /// <param name="contacts">Obiekt reprezentujący kontakty.</param>
        /// <param name="filter">Filtr</param>
        private void StartSearch(Contacts contacts, string filter)
        {
            lblSearchInfo.Text = "Trwa przeszukiwanie kontaktów...";

            _searchHistory.Add(filter);
            contacts.SearchAsync(filter, FilterKind.DisplayName, filter);
        }

        /// <summary>
        /// Wykonanie akcji po zakończeniu filtrowania kontaktów.
        /// </summary>
        private void HandleSearchResult(ContactsSearchEventArgs e)
        {
            // Uzupełnienie kolekcji tylko w momencie, w którym wynik jest wynikiem ostatniego wyszukiwania.

            if (e.State == _searchHistory.Last())
            {
                List<SelectedUserInformation> contacts = GetUserListFromSearchResult(e.Results.ToList());

                lblSearchInfo.Text = string.Format("Wyszukiwanie zakończone! Liczba wyników: {0}.", contacts.Count);

                if (FillListMethod != null)
                    FillListMethod(contacts);

                // _TODO_PC: Czyścić listę historii?
            }
        }

        /// <summary>
        /// Przeszukanie kontaktów.
        /// </summary>
        private void SearchConcats()
        {
            if (chBoxContacts.IsChecked.HasValue && (bool) chBoxContacts.IsChecked && !string.IsNullOrEmpty(txtBoxFilter.Text))
                StartSearch(_contactsManager, txtBoxFilter.Text);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Wyświetlanie klawiatury.
        /// </summary>
        public void ShowAlphaKeyboard()
        {
            txtBoxFilter.Focus();
        }

        /// <summary>
        /// Flaga informująca o tym czy wybór użytkownika nastąpił z listy kontaktów czy wartość została wpisana z palca.
        /// </summary>
        public bool SelectFromContact
        {
            get { return chBoxContacts.IsChecked.HasValue ? (bool)chBoxContacts.IsChecked : false; }
        }

        #endregion
    }
}
