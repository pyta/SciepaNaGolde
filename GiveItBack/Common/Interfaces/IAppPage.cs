using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Common.Interfaces
{
    public interface IAppPage
    {
        /// <summary>
        /// Zwraca poprzednią stronę.
        /// </summary>
        IAppPage PreviousPage { get; }

        /// <summary>
        /// Zwraca widok, który reprezentuje daną stronę.
        /// </summary>
        Control Content { get; }
    }
}
