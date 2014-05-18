using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WezNoOddajLib.Members
{
    public interface IMoneyCollection
    {
        /// <summary>
        /// Dodawanie nowej składki.
        /// </summary>
        /// <returns>Obiekt reprezentujący nową składkę.</returns>
        void AddNewMember(IMemberInfo member);

        /// <summary>
        /// Usunięcie z kolekcji składki przekazanej jako parametr.
        /// </summary>
        /// <param name="member">Składka do usunięcia.</param>
        /// <returns>True jeżeli usunięto składkę.</returns>
        void RemoveMember(IMemberInfo member);

        /// <summary>
        /// Kolekcja wszystkich składek.
        /// </summary>
        List<IMemberInfo> MembersList { get; }

        /// <summary>
        /// Obliczenie podziału kosztów.
        /// </summary>
        /// <returns>Klasa reprezentująca wynik obliczenia.</returns>
        ICollectionCalculateResult Calculate();
    }
}
