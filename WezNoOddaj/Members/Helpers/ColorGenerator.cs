using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;

namespace WezNoOddaj.Members.Helpers
{
    /// <summary>
    /// Klasa pomocnicza do zwracania oryginalnego i ładnego koloru.
    /// </summary>
    public static class ColorGenerator
    {
        #region Members

        private static List<Color> _colorsList;

        #endregion

        #region Public methods

        /// <summary>
        /// Pobieranie koloru.
        /// </summary>
        /// <returns></returns>
        public static Color GetColor()
        {
            if (_colorsList == null)
                ResetCollection();

            Color color = _colorsList.FirstOrDefault();

            if (color != null)
            {
                _colorsList.Remove(color);
                return color;
            }
            else
            {
                return GenerateNewColor();
            }
        }

        /// <summary>
        /// Przywracania kolekcji kolorów do pierwotnego stanu (dostępne wszystkie kolory).
        /// </summary>
        public static void ResetCollection()
        {
            _colorsList = new List<Color>()
            {
                // _TODO_PC: Rozbudować listę zajebistych kolorów.

                Colors.Blue,
                Colors.Brown,
                Colors.Green,
                Colors.Magenta
            };
        }

        #endregion

        /// <summary>
        /// Generowanie nowego koloru.
        /// </summary>
        /// <returns></returns>
        private static Color GenerateNewColor()
        {
            // _TODO_PC: Dodać magiczne generowanie jakiegoś koloru.

            return Colors.Blue;
        }
    }
}
