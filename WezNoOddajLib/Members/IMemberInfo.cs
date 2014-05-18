using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WezNoOddajLib.Members
{
    public interface IMemberInfo
    {
        /// <summary>
        /// Nazwa wyświetlana w aplikacji.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Wielkość wkładu.
        /// </summary>
        float Share { get; set; }
    }
}
