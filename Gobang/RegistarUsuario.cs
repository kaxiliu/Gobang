//El clase de Registar o Iniciar el Usuario
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gobang
{
    public partial class RegistarUsuario : Form
    {
        private Usuario usuario;
        private Jugador jugador;
        
        public RegistarUsuario()
        {
            InitializeComponent();
            List<Usuario>usuarios = Usuario.CargarUsuario();
            List<Jugador> jugadores = Jugador.CargarJugador();
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


        //El botón de Registrar
        private void button1_Click(object sender, EventArgs e)
        {
        if(txtNombre.Text!="" && txtContrasenya.Text!="")
            {
                string nombre=txtNombre.Text;
                string contrasenya = txtContrasenya.Text;

                List<Usuario> usuarios = Usuario.CargarUsuario();
                bool existe = false;
                foreach(Usuario u in usuarios)
                {
                    if(u.Nombre==nombre)
                    {
                        existe = true;
                    }
                }
                if (existe)
                {
                    MessageBox.Show("Error:Usuario ya existe");
                    txtNombre.Text = "";
                    txtContrasenya.Text = "";
                }
                else
                {
                    usuarios.Add(new Usuario(nombre, contrasenya));
                    Usuario.GuardarUsuarios(usuarios);
                    MessageBox.Show("Creado con existo"); 
                    this.Close();
                }
               

            }
        else
            {
                MessageBox.Show("Los campos no pueden estar vacíos");
            }
        }

        //El botón de Iniciar
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtContrasenya.Text != "")
            {
                string nombre = txtNombre.Text;
                string contrasenya = txtContrasenya.Text;
                if(Usuario.ValidaUsuario(nombre, contrasenya))
                {
                    this.Usuario = new Usuario(nombre, contrasenya);
                    this.Jugador=new JugadorHumano(nombre, contrasenya,
                        true,0,0,0f);
                    
                    //si iniciar correcto
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Usuario correcto");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                    txtNombre.Text = "";
                    txtContrasenya.Text = "";
                } 
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacíos");
            }
        }
    }

}
