using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Common.Interfaces;
using Microsoft.Phone.UserData;

namespace Common
{
    public static class ToolsKit
    {
        /// <summary>
        /// Pobiera obiekt bitmapowy z kontaktu.
        /// </summary>
        /// <param name="contact">Kontakt do przeorania.</param>
        /// <returns></returns>
        public static BitmapImage GetImageFromConcat(Contact contact)
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

        public static Color GetColor()
        {
            // TODO: Ogarnąć kolory.

            return Colors.Blue;
        }

        public static IMenuIconsSet GetMenuIconsSet()
        {
            // TODO: Ogarnąć zbiory ikonek.

            return new CustomMenuIconsSet();
        }
    }
}
