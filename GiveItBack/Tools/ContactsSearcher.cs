using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.Phone.UserData;

namespace Tools
{
    public class ContactsSearcher
    {
        #region Private Members

        /// <summary>
        /// Prywatny obiekt zarządzający kontaktami telefonu.
        /// </summary>
        private Contacts _contacts = new Contacts();

        /// <summary>
        /// Prywatna lista z wprowadzanymi filtrami. Używana do uwzględniania ostatniego wpisu przy wyszukiwaniu.
        /// </summary>
        private List<string> _filters = new List<string>();

        /// <summary>
        /// Prywatna metoda, która zostaje wywołana po przeszukaniu kontaków. Jako argument przyjmuje listę z wynikami wyszukiwania.
        /// </summary>
        private Action<List<SelectedMember>> SearchResult { get; set; }

        #endregion

        /// <summary>
        /// Zwraca informację o tym czy zostało rozpoczęte jakieś wyszukiwanie.
        /// </summary>
        public bool SeachInit { get { return _filters.Any(); } }

        /// <summary>
        /// Zwraca informację o trwaniu przeszukiwania kontaktów.
        /// </summary>
        public bool Searching { get; private set; }

        /// <summary>
        /// Tworzy obiekt do przeszukiwania kontaktów.
        /// </summary>
        /// <param name="searchResult">Metoda wywoływana po zakończeniu przeszukiwnia.</param>
        public ContactsSearcher(Action<List<SelectedMember>> searchResult)
        {
            SearchResult = searchResult;

            _contacts.SearchCompleted += _contacts_SearchCompleted;
        }

        /// <summary>
        /// Rozpoczyna proces przeszukiwania kontaktów, które kończy się wywołaniem metody przekazanej w konstruktorze klasy.
        /// </summary>
        /// <param name="filter">Zawężenie nazwy kontaktu.</param>
        public void StartSearching(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                _filters.Add(filter);
                _contacts.SearchAsync(filter, FilterKind.DisplayName, filter);

                Searching = true;
            }
            else
            {
                SearchResult(null);
            }
        }

        /// <summary>
        /// Czyści dane przeszukiwania.
        /// </summary>
        public void ClearSearchData()
        {
            _filters.Clear();

            if (Searching)
                Searching = false;
        }

        #region Private Methods

        /// <summary>
        /// Tworzy z wyniku przeszukiwania kontaktów listę użytkowników do wybrania.
        /// </summary>
        /// <param name="e">Argument zdarzenia zakończenia przeszukiwania kontaktów.</param>
        /// <returns></returns>
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

                result.Add(m);
            }

            return result;
        }

        #endregion

        #region Events

        /// <summary>
        /// Zdarzenie wywoływane po zakończeniu przeszukiwnia kontaktów.
        /// </summary>
        private void _contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (e.State.ToString() == _filters.Last())
            {
                Searching = false;

                List<SelectedMember> result = CreateMembersList(e);
                SearchResult(result);
            }
        }

        #endregion
    }
}
