using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Phone.Shell;

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

        /// <summary>
        /// Ustawia stronę określoną we właściwości <see cref="PreviousPage"/> jako aktualną stronę.
        /// </summary>
        void Back();

        /// <summary>
        /// Zwraca menu dostępne w ramach podstrony.
        /// </summary>
        ApplicationBar ApplicationBar { get; }
    }
}
