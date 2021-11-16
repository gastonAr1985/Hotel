using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data
{
    public class ErrorMsg
    {
        public const String Requerido = "El campo {0} es requerido";
        public const String Rango = "El campo {0} debe estar comprendido entre {1} y {2}";
        public const String StringMaxMin = "El campo {0} debe estar comprendido entre {2} y {1}";
        public const String CantDig = "El campo {0} debe estar comprendido entre {2} y {1} digitos";

    }
}
