//Subclase para jugador Humano
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    public class JugadorHumano : Jugador
    {

        //public JugadorHumano(string nickname, bool piezaEsNegra)
        //    : base(nickname, piezaEsNegra)
        //{
        //}
        public JugadorHumano(string nombre, string contrasenya, 
            bool piezaEsNegra, int numVictorias,
            int numDerrotas, float porcentajeVic) 
            : base(nombre, contrasenya, piezaEsNegra, 
                  numVictorias, numDerrotas, porcentajeVic)
        {
        }
    }
}
