//Clase de tablero que tiene constante tamaño,width y height
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gobang
{
    public class Tablero
    {
        public const int tamanyo = 15;
        
        //Definir en constantes el Width y Height
        public const int TableroWidth = 600;
        public const int TableroHeight = 600;

        //El atributo "celdas" como privado
        private Casilla[,] celdas;

        //Getter y Setter
        public Casilla[,] Celdas
        {
            get { return celdas; }
            set { celdas = value; }
        }
       
        public Tablero()
        {
            IniciarTablero();
        }


        //Inicia el Tablero(Uso en el Gobang.cs)
        public void IniciarTablero()
        {
            celdas = new Casilla[tamanyo, tamanyo];
            for (int fila = 0; fila < tamanyo; fila++)
            {
                for (int columna = 0; columna < tamanyo; columna++)
                {
                    celdas[fila, columna] = new Casilla(fila, columna);
                }
            }
        }

        //Dibujar Tablero(También buscado los videos...)
        public static void DibujarTablero(Graphics g)
        {
            int GapWidth = Casilla.CasillaGap;
            int GapNum = tamanyo; 

            g.Clear(Color.FromArgb(255, 255, 155));
            Pen pen = new Pen(Color.FromArgb(192, 166, 107));

         
            for (int i = 0; i < GapNum; i++)
            {
                int x = i * GapWidth + 20;
                g.DrawLine(pen, new Point(x, 20),
                    new Point(x, GapWidth * (GapNum - 1) + 20));

                int y = i * GapWidth + 20;
                g.DrawLine(pen, new Point(20, y), 
                    new Point(GapWidth * (GapNum - 1) + 20, y));
            }
        }
 
    }
}
