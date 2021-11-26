using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class TelefonosService : ITelefonosService
    {
        public string getTelefono(string codTel) {

            if (codTel == "001")
            {
                return "0099938398";
            }
            else { return "999999999"; }
        }



    }
    public interface ITelefonosService
    {
        public string getTelefono(string codTel);
        


    }
}
