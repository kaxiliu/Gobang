//Clase de elegir nivel de dificultad

using System;
using System.Windows.Forms;

namespace Gobang
{
    public partial class ElegirDificultad : Form
    {
        private Jugador jugador;
        private JugadorIA.ModoDificultad dificultad;

        public Jugador Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }
        internal JugadorIA.ModoDificultad Dificultad  
        {
            get { return dificultad;}
            set { dificultad = value;}
        }
        public ElegirDificultad()
        {
            InitializeComponent();
        }

        //Nivel Facil
        private void button1_Click(object sender, EventArgs e)
        {
            dificultad = JugadorIA.ModoDificultad.FACIL;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Nivel Medio
        private void button2_Click(object sender, EventArgs e)
        {
            dificultad = JugadorIA.ModoDificultad.MEDIO;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
