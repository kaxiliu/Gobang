//El clase de Perfil Persona
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gobang
{
    public partial class PerfilPersonal : Form
    {
        private Usuario usuario;
        private Jugador jugador;
        
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value;}
        }
        public Jugador Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }


        public PerfilPersonal()
        {
            InitializeComponent();
            IniciarPerfil();
        }

        public void IniciarPerfil()
        {
            if (Usuario != null)
            {
                label3.Text = Usuario.Nombre;

                if (Jugador != null)
                {
                    numVic.Text = Jugador.NumVictorias.ToString();
                    numD.Text = Jugador.NumDerrotas.ToString();
                    porVic.Text = (Jugador.Porcentajes).ToString("F1") + "%";
                }
            }
            else
            {
                label3.Text = "Invitado";
            }
           
        }

        //Cerrar el pantalla
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
