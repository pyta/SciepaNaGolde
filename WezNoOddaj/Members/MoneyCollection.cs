using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;

using WezNoOddajLib.Members;
using WezNoOddaj.Screens;

namespace WezNoOddaj.Members
{
    /// <summary>
    /// Główny obiekt zarządzający działaniem aplikacji.
    /// </summary>
    public class MoneyCollection : IMoneyCollection
    {
        #region Members

        /// <summary>
        /// Kolekcja składek składająca się na pełną kwotę.
        /// </summary>
        private List<IMemberInfo> _collection;

        /// <summary>
        /// Metoda do odświeżania danych.
        /// </summary>
        private Action _refreshDataMethod;

        #endregion

        public MoneyCollection(Action refreshDataMethod)
        {
            _collection = new List<IMemberInfo>();
            _refreshDataMethod = refreshDataMethod;
        }

        #region IMoneyCollection Members

        public void AddNewMember(IMemberInfo member)
        {
            if (member != null)
                _collection.Add(member);
        }

        public void RemoveMember(IMemberInfo member)
        {
            _collection.Remove(member);

            if (_refreshDataMethod != null)
                _refreshDataMethod();
        }

        public List<IMemberInfo> MembersList
        {
            get { return _collection; }
        }

        public ICollectionCalculateResult Calculate()
        {
            return new PlanimetricResult(MembersList);
        }

        #endregion

        #region Private methods

        #endregion
    }
}
