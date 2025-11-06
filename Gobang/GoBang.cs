//El clase de GoBang

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gobang
{
    public partial class GoBang : Form
    {
        private Tablero tablero;
        private Usuario usuario;
        private Jugador jugador;

        public int FormWidth;
        public int FormHeight;

        //El juego si comienzado o no
        private bool start;
        //Tamaño de tablero
        private int[,] GoBangTablero 
            = new int[Tablero.tamanyo, Tablero.tamanyo];
        private bool PiezaEsNegra = true;
        //Elegir modo(Amigo/IA)
        private ElegirModo modoForm;
        private ElegirDificultad nivelForm;
        private JugadorIA.ModoDificultad dificultad;

        public GoBang()
        {
            InitializeComponent();

            //Iniciar el Tablero
            tablero = new Tablero();
           
            //Colocar las piezas Iniciales
            ColocarPiezasIniciales();
            
        }

        public Tablero Tablero 
        {   
            get { return tablero; }
            set { tablero = value; }
        }
        public Usuario Usuario 
        { 
            get { return usuario; }
            set { usuario = value; } 
        }
        public Jugador Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

        private void GoBang_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = Usuario.CargarUsuario();
            //esta inicie en sesion o no
            if (Usuario != null)
            {
                label1.Text = " Bienvenido , " + Usuario.Nombre;
                //aparece el boton de registrar 
                button4.Visible = false;
            }
            else
            {
                label1.Text = "Invitado,Por favor inicie sesión";
                button2.Visible = false;
            }
            this.FormWidth = 710;
            this.FormHeight = 640;
            this.Location = new Point(400,75);
            
        }

        //Iniciar el partida
        private void IniciarGame()
        {
            Tablero.IniciarTablero();
            start = false;

            //El botón de comenzar que sea visible
            //El botón de reiniciar que sea invisible
            button1.Visible = true;
            button2.Visible = false;
            GoBangTablero = new int[Tablero.tamanyo, Tablero.tamanyo];
            PiezaEsNegra = true;
        }

        //Iniciar los piezas(el codigo de Programa.cs)
        private void ColocarPiezasIniciales()
        {
            GoBangTablero=new int[Tablero.tamanyo,Tablero.tamanyo];

            //Dibujar las piezas a Tablero
            tablero.Celdas[3, 3].piezas = new Pieza(esNegra: true);
            tablero.Celdas[3, 4].piezas = new Pieza(esNegra: false);
            tablero.Celdas[4, 4].piezas = new Pieza(esNegra: true);
            tablero.Celdas[2, 4].piezas = new Pieza(esNegra: false);
            tablero.Celdas[5, 4].piezas = new Pieza(esNegra: true);
            tablero.Celdas[6, 4].piezas = new Pieza(esNegra: false);
            tablero.Celdas[4, 5].piezas = new Pieza(esNegra: true);
            tablero.Celdas[4, 2].piezas = new Pieza(esNegra: false);

            //Guadar los datos de piezas a Tablero
            GoBangTablero[3, 3] = 1;
            GoBangTablero[3, 4] = 2;
            GoBangTablero[4, 4] = 1;
            GoBangTablero[2, 4] = 2;
            GoBangTablero[5, 4] = 1;
            GoBangTablero[6, 4] = 2;
            GoBangTablero[4, 5] = 1;
            GoBangTablero[4, 2] = 2;
        }

        //Dibujar el panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Tablero.DibujarTablero(g);

            /* Colocar dos piezas(manual)
            Pieza.DibujarPieza(panel1, esNegra: true, 3, 4);
            Pieza.DibujarPieza(panel1, esNegra: false, 3, 3);
            Pieza.DibujarPieza(panel1, esNegra: true, 4, 4);
            Pieza.DibujarPieza(panel1, esNegra: false, 2, 4);
            */

            //Leer el tablero directamente
            foreach (Casilla casillas in tablero.Celdas)
            {
                if (casillas.piezas != null)
                {
                    Pieza.DibujarPieza(panel1, casillas.piezas.EsNegra,
                        casillas.posiciones.fila,
                        casillas.posiciones.columna);
                }
            }
        }


        //Cuando pulso el botón de Registar
        private void button4_Click(object sender, EventArgs e)
        {
            RegistarUsuario registroForm = new RegistarUsuario();
           
            //Si añadir correcto
            if (registroForm.ShowDialog() == DialogResult.OK) 
            {
                this.Usuario = registroForm.Usuario;
                this.Jugador = registroForm.Jugador;
                label1.Text = " Bienvenido, " + Usuario.Nombre;
            }
        }

        //Cerra sesión
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro salir?", "Pista",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        //Cuado pulso el botón de Comenzar
        private void button1_Click(object sender, EventArgs e)
        {
            if(Usuario==null)
            {
                var result=MessageBox.Show("No ha iniciado sesión aún," +
                    "¿quieres iniciar?", "PISTA",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    //Usamos el evento de registro/inicio
                    button4_Click(sender, e);
                }
                return;
            }

            start = true;
            PiezaEsNegra = true;
            label1.Text = "Turno de pieza negra";
            //El botón de comenzar que sea invisible
            //El botón de reiniciar que sea visible
            //Registar sea invisible tambien
            button1.Visible = false;
            button2.Visible = true;
            button4.Visible = false;
            panel1.Invalidate();
            modoForm = new ElegirModo();
           
            //Elegir modo
            if(modoForm.ShowDialog()==DialogResult.OK)
            {
                //si el modo es ModoIA
                if(modoForm.ModoIA)
                {
                    //Elegir nivel de dificultad
                    dificultad = modoForm.Dificultad;
                }    
            }
        }


        //Cuando pulso el botón de Perfil Personal
        private void button5_Click(object sender, EventArgs e)
        {
            PerfilPersonal perfilForm = new PerfilPersonal();
            perfilForm.Usuario = this.Usuario;
            if(Usuario!=null)
            {
                List<Jugador> jugadores = Jugador.CargarJugador();
                foreach(Jugador j in jugadores)
                {
                    if(j.Nombre==Usuario.Nombre)
                    {
                        perfilForm.Jugador = j;
                    }
                }
            }
            else
            {
                perfilForm.Jugador = new JugadorHumano(
                    "Invitado", "0000", true, 0, 0, 0f);
            }
            perfilForm.IniciarPerfil();
            perfilForm.ShowDialog();
        }

        //Jugar el GoBang con el mouse(usamos el Evento de MouseDown)
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (start)
            {
                //Juez la fila y columna de actual Array
                //que es turno de negra(1) o blanca(2) o nada(0)
                int Color = 0;

                //Obtener el posicion de Mouse
                int colocacionX = e.X / Casilla.CasillaGap;
                int colocacionY=e.Y / Casilla.CasillaGap;

                try
                {
                    if (GoBangTablero[colocacionX, colocacionY]!=0)
                    {
                        return;
                    }
                    if(PiezaEsNegra)
                    {
                        GoBangTablero[colocacionX, colocacionY] = 1;
                        Color = 1;
                        label1.Text = "Turno de pieza blanca";
                    }
                    else 
                    {
                        GoBangTablero[colocacionX, colocacionY] = 2;
                        Color = 2;
                        label1.Text = "Turno de pieza negra";
                    }

                    //Dibujar el pieza
                    Pieza.DibujarPieza(panel1, PiezaEsNegra,
                        colocacionX, colocacionY);
                    
                    //Comprobar quien ganado
                    if (Victoria(GoBangTablero,Color))
                    {
                        //si pieza es negra
                        if (Color==1)
                        {
                            Jugador.IncrementarVictoria();
                            MessageBox.Show
                                ("La pieza negra ha ganado","VICTORIA");
                        }
                        else
                        {
                            Jugador.IncrementarDerrota();
                            MessageBox.Show
                                ("La pieza blanca ha ganado", "DERROTA");
                        }

                        //Guardar los datos de jugador Actual
                        Jugador.VolverGuardarJugador(jugador);
                        IniciarGame();
                    }

                    //Alternar el turno 
                    PiezaEsNegra = !PiezaEsNegra;

                    //Si el modo es modoIA
                    if (modoForm!=null && modoForm.ModoIA
                        && !PiezaEsNegra)
                    {
                        JugadorIA jugadorIA;
                        if (dificultad == 
                            JugadorIA.ModoDificultad.FACIL)
                        {
                            JugadorIA jugadorIa = new JugadorIA("IA", "0000",
                                false, 0, 0, 0f, JugadorIA.ModoDificultad.FACIL);

                            jugadorIa.HacerMovimientoAleatorio
                                (GoBangTablero, panel1);

                        }
                        else if(dificultad== 
                            JugadorIA.ModoDificultad.MEDIO)
                        {
                            JugadorIA jugadorIa = new JugadorIA("IA", "0000",
                                false, 0, 0, 0f, JugadorIA.ModoDificultad.MEDIO);

                            jugadorIa.HacerMovimientoInteligente
                                (GoBangTablero, panel1);
                        }
                        //Si gana IA
                        if(Victoria(GoBangTablero,2))
                        {
                            Jugador.IncrementarDerrota();
                            MessageBox.Show("La pieza blanca(IA) ha ganado",
                                "DERROTA");
                            Jugador.VolverGuardarJugador(jugador);
                            IniciarGame();
                        }
                        PiezaEsNegra=!PiezaEsNegra;
                    }
                }
                catch(Exception)  { throw new Exception("Error"); }
            }
            else
            {
                MessageBox.Show("Comience el juego", "Pista");
            }
        }
        
        //Cuando pulso el botón de Reiniciar
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que reiniciar?", "Pista",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                IniciarGame();
                panel1.Invalidate();
            }
        }

        //Verificar si alguien ha ganado
        public static bool Victoria(int[,] GoBangTablero,int color)
        {
            bool win = false;

            for(int i = 0;i<GoBangTablero.GetLength(1);i++)
            {
                for(int j=0;j<GoBangTablero.GetLength(0);j++) 
                {
                    //Comprobar si el tablero tiene piezas
                    if (GoBangTablero[j,i]==color)
                    {
                   /* Como el tamaño de tablero es 15,
                    * si se colocan cinco piezas en línea,
                    * poner en la posicion 11 (15-11=4) no ganará el juego
                    * Esta jugada permite al programa evitar algunas
                    * comprobaciones innecesarias */
                        
                        //horizontal
                        if (j< Tablero.tamanyo-4)
                        {
                            if (GoBangTablero[j+1,i]== color && 
                                GoBangTablero[j+2,i]==color &&
                                GoBangTablero[j+3,i] == color &&
                                GoBangTablero[j+4,i] == color)
                            {
                                return win = true;
                            }
                        }

                        //vertical
                        if(i< Tablero.tamanyo - 4)
                        {
                            if (GoBangTablero[j,i+1]==color &&
                                GoBangTablero[j,i+2] == color &&
                                GoBangTablero[j,i+3] == color &&
                                 GoBangTablero[j,i+4] == color)
                            {
                                return win = true;
                            }
                        }
                        
                        //oblicua(derecha)
                        if(j< Tablero.tamanyo - 4 && i< Tablero.tamanyo - 4)
                        {
                            if (GoBangTablero[j + 1, i + 1] == color &&
                                GoBangTablero[j + 2, i + 2] == color &&
                                GoBangTablero[j + 3, i + 3] == color &&
                                GoBangTablero[j + 4, i + 4] == color)
                            { return win = true; }
                        }

                        //oblicua(izquierda)
                        /*Como es izquierda,j deberia mayor que 3
                         * (0-3=4 4<5)*/

                        if (j>3 && i< Tablero.tamanyo - 4)
                        {
                            if (GoBangTablero[j - 1, i + 1] == color &&
                                GoBangTablero[j - 2, i + 2] == color &&
                                GoBangTablero[j - 3, i + 3] == color &&
                                GoBangTablero[j - 4, i + 4] == color)
                            {
                                return win = true;
                            }
                        }
                    }
                }
            }
            return win;
        }



    }
}
