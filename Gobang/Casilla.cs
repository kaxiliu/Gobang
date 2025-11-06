//Clase de Casilla para guadar los posiciones y piezas

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    public class Casilla
    {
        public Posicion posiciones;
        public Pieza piezas;

        //tamaño de casilla
        public static int CasillaGap { get { return 40; } }

        
        public Casilla(int fila,int columna)
        {
            posiciones=new Posicion(fila,columna);
            piezas = null;
        }

        //Getter y Setter
        public Posicion Posicion
        {
            get { return posiciones; }
            set { posiciones = value; }
        }

        public Pieza Pieza
        {
            get { return piezas; }
            set { piezas = value; }
        }


    }
}
