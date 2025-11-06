//Subclase para IA
using System;
using System.Windows.Forms;

namespace Gobang
{
    internal class JugadorIA:Jugador
    {
        public enum ModoDificultad { FACIL = 1, MEDIO };
        private ModoDificultad dificultad;

        public JugadorIA(string nombre, string contrasenya, bool piezaEsNegra, 
            int numVictorias, int numDerrotas, float porcentajeVic,
            ModoDificultad dificultad) 
            : base(nombre, contrasenya, piezaEsNegra,
                  numVictorias, numDerrotas, porcentajeVic)
        {
            this.dificultad= dificultad;
        }

        public ModoDificultad Dificultad
        { 
            get { return dificultad; } 
            set { dificultad = value; } 
        }

        public override string AFichero()
        {
            return base.AFichero()+";"+dificultad;
        }

       //Hacer movimento aleatorio
       public void HacerMovimientoAleatorio(int[,]tablero,Panel panel)
        {
           Random r=new Random();
            int fila, columna;

            do
            {
                fila = r.Next(0, Tablero.tamanyo);
                columna = r.Next(0, Tablero.tamanyo);
            }
            while (tablero[fila, columna] != 0);

            //Colocar la pieza blanca de IA( 2=color blanca)
            tablero[fila, columna] = 2;
            Pieza.DibujarPieza(panel, false, fila, columna);

        }

        //Hacer movimiento más inteligente(dificil)
        //Solo bloquea la victoria del jugador

        public void HacerMovimientoInteligente(int[,] tablero, Panel panel)
        {
            if (dificultad == ModoDificultad.MEDIO)
            {
                for (int fila = 0; fila < tablero.GetLength(0); fila++)
                {
                    for (int columna = 0; columna < tablero.GetLength(1); columna++)
                    {
                        if (tablero[fila, columna] == 0)
                        {   
                            //Jugador
                            tablero[fila, columna] = 1;
                            bool JugadorVictoria = GoBang.Victoria(tablero, 1);
                            tablero[fila, columna] = 0;

                            if(JugadorVictoria)
                            {
                                //IA bloquea la victoria del jugador
                                tablero[fila, columna] = 2;
                                Pieza.DibujarPieza(panel, false, fila, columna);
                                return;
                            }
                        }
                    }
                }
                //Si no hay tres piezas en columna,hacer un movimiento cerca
                //de jugador
                
                for(int fila=0;fila<tablero.GetLength(0);fila++)
                {
                    for(int columna = 0;columna< tablero.GetLength(1);columna++)
                    {
                        if (tablero[fila,columna]==0 &&
                            TieneVecino(tablero, fila, columna))
                        {
                            tablero[fila, columna] = 2;
                            Pieza.DibujarPieza(panel, false, fila, columna);
                            return;
                        }
                    }
                }
            }
        }

        private bool TieneVecino(int[,]tablero,int fila,int columna)
        {
            //Comprobar 9 posiciones alededor de la posicion actual
            //(0 ,0)=posicion actal
            //(-1 ,0) que es arriba
            for (int i=-1;i<=1;i++)
            {
                for(int j=-1;j<=1;j++)
                {
                    //Calcula los posiciones de cerca
                    int f = fila + i;
                    int c=columna + j;
                    if(f>=0 &&f<tablero.GetLength(0)&&
                        c>=0 &&c<tablero.GetLength(1))
                    {
                        //Tiene vecino
                        if (tablero[f,c]!=0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


    }
}


    /*public void HacerMovimiento(int[,]tablero,Panel panel)
        {
            switch(dificultad)
            {
                case ModoDificultad.FACIL:
                    HacerMovimientoAleatorio(tablero, panel);
                    break;
                case ModoDificultad.MEDIO:
                    HacerMovimientoInteligente(tablero, panel);
                    break;
                default:
                    break;
            }
        }*/