//El clase de Elegir un modo
//que es contra con un amigo o IA

using System.Windows.Forms;

namespace Gobang
{
    public partial class ElegirModo : Form
    {
        private Jugador jugador;
        private JugadorIA.ModoDificultad dificultad;

        //Comprobar que jugar con modoIA
        private bool modoIA;

        public Jugador Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }
        internal JugadorIA.ModoDificultad Dificultad
        {
            get { return dificultad; }
            set { dificultad = value; }
        }

        public bool ModoIA
        {
            get { return modoIA; }
        }

        public ElegirModo()
        {
            InitializeComponent();
        }

        //Jugar con Amigo
        private void button1_Click(object sender, System.EventArgs e)
        {
            modoIA = false;
            this.DialogResult=DialogResult.OK;
            this.Close();
        }

        //Jugar con IA
        private void button2_Click(object sender, System.EventArgs e)
        {
            ElegirDificultad nivelForm = new ElegirDificultad();
            if(nivelForm.ShowDialog() == DialogResult.OK)
            {
                this.dificultad = nivelForm.Dificultad;
                modoIA = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }


    }
}
