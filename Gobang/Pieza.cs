// Clase de Pieza

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Gobang
{
    public class Pieza
    {
        //diametro de Pieza
        public static int DiametroPieza { get { return 37; } }
        public bool EsNegra;

        public Pieza(bool esNegra)
        {
            EsNegra = esNegra;
        }

       

        //Dibuja el pieza( He buscado los videos para aprender este parte...
        public static void DibujarPieza(Panel p,bool esNegra,
            int posicionX,int posicionY)
        {
            Graphics g = p.CreateGraphics();
            
            // Posicion precisa de las piezas de Gobang en el tablero
            int precisaX = posicionX * Casilla.CasillaGap+20-17;
            int precisaY = posicionY * Casilla.CasillaGap + 20 - 17;


            if(esNegra)
            {
                g.FillEllipse(new LinearGradientBrush(new Point(20,0),
                    new Point(20,40),Color.FromArgb(122,122,122),
                    Color.FromArgb(0,0,0)),
                    new Rectangle(new Point(precisaX,precisaY),
                    new Size(DiametroPieza,DiametroPieza)));
            }
            else
            {
                g.FillEllipse(new LinearGradientBrush(new Point(20, 0),
                   new Point(20, 40), Color.White,
                   Color.FromArgb(204, 204, 204)),
                   new Rectangle(new Point(precisaX, precisaY),
                   new Size(DiametroPieza, DiametroPieza)));
            }
        }

        //Redibujar y recargar las Piezas
        public static void ReDibujar(Panel p, int[,]CheckBoard)
        {
            //Crear una nueva pantalla
            Graphics g = p.CreateGraphics();

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //Determine la fila y columna actuales de la matriz
           //es turno de pieza negra o blanca,0=No,1=negra,2=blanca
            for(int i=0;i<CheckBoard.GetLength(1);i++)
            {
                for(int j=0;j<CheckBoard.GetLength(0);j++)
                {
                    int Juicio = CheckBoard[j, i];
                    if (Juicio != 0)
                    {
                        int precisaX = j * Casilla.CasillaGap + 20 - 17;
                        int precisaY = i * Casilla.CasillaGap + 20 - 17;

                        //Juicio de quienes turno y dibujar las piezas
                        if (Juicio == 1)
                        {
                            g.FillEllipse(new LinearGradientBrush
                            (new Point(20, 0),new Point(20, 40),
                            Color.FromArgb(122, 122, 122),
                            Color.FromArgb(0, 0, 0)),
                            new Rectangle(new Point(precisaX, precisaY),
                            new Size(DiametroPieza, DiametroPieza)));
                        }
                        else
                        {
                            g.FillEllipse(new LinearGradientBrush
                         (new Point(20, 0), new Point(20, 40), 
                         Color.White,Color.FromArgb(204, 204, 204)),
                         new Rectangle(new Point(precisaX, precisaY),
                         new Size(DiametroPieza, DiametroPieza)));
                        }
                    }
                } 
            }
        }

    }
}
