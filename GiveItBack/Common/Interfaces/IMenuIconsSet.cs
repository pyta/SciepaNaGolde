using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IMenuIconsSet
    {
        /// <summary>
        /// Zwraca ścieżkę do ikony dodawania.
        /// </summary>
        string AddIcon { get; }

        /// <summary>
        /// Zwraca ścieżkę do ikony zatwierdzającej.
        /// </summary>
        string CheckIcon { get; }

        /// <summary>
        /// Zwraca ścieżkę do ikony anulowania.
        /// </summary>
        string CancelIcon { get; }
    }
}
