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

        private Contacts _contacts = new Contacts();
        private List<string> _filters = new List<string>();

        private Action<List<SelectedMember>> SearchResult { get; set; }

        #endregion

        public bool SeachInit { get { return _filters.Any(); } }

        /// <summary>
        /// Zwraca informację o trwaniu przeszukiwania kontaktów.
        /// </summary>
        public bool Searching { get; private set; }

        public ContactsSearcher(Action<List<SelectedMember>> searchResult)
        {
            SearchResult = searchResult;

            _contacts.SearchCompleted += _contacts_SearchCompleted;
        }

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

        public void ClearSearchData()
        {
            _filters.Clear();
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

        private void _contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            if (e.State.ToString() == _filters.Last())
            {
                Searching = false;

                List<SelectedMember> result = CreateMembersList(e);
                SearchResult(result);
            }
        }
    }
}
