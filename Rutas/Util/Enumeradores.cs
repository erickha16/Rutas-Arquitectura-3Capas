using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Rutas.Util
{
    public class Enumeradores
    {
        public enum Tipo
        {
            Trailer, 
            Toron, 
            [Description("Doble Remolque")] Doble_Reolque, 
            Volteo,
            [Description("Semi Remolque")] Semi_Remolque
        }

        public enum Marca {
            Volvo,
            Alliance,
            Ford,
            [Description("Mercedes Benz")] Mercedes,
            Dina,
            Tesla
        }

    }
}