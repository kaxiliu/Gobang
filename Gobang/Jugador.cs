//Clase Padre ,los Jugadores
using Gobang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static Gobang.JugadorIA;

namespace Gobang
{

    public abstract class Jugador:Usuario
    {
        //protected string nickname;
        //herencia de nombre de Usuario
        protected bool piezaEsNegra;

        //Actualiza estos datos de Usuario.cs a clase de Jugador
        const string FICHERO = "jugador.txt";
        protected int numVictorias;
        protected int numDerrotas;
        protected float porcentajeVic;


        protected Jugador(string nombre, string contrasenya, bool piezaEsNegra,
           int numVictorias, int numDerrotas, float porcentajeVic)
            :base(nombre, contrasenya)
        {
            this.nombre = nombre;
            this.contrasenya = contrasenya;
            this.piezaEsNegra = piezaEsNegra;
            this.numVictorias = numVictorias;
            this.numDerrotas = numDerrotas;
            this.porcentajeVic = porcentajeVic;
        }


        public bool PiezaEsNegra
        {
            get { return piezaEsNegra; }
            set { piezaEsNegra = value; }
        }

        public int NumVictorias
        {
            get { return numVictorias; }
            set { numVictorias = value; }
        }

        public int NumDerrotas
        {
            get { return numDerrotas; }
            set { numDerrotas = value; }
        }

        public float Porcentajes
        {
            get {
                    if (numVictorias + numDerrotas == 0)
                    {  return 0f;}
                    else
                        return porcentajeVic =
                        (float)numVictorias / (numVictorias + numDerrotas)*100;
                }
            set { porcentajeVic = value; }
        }

        //Si el jugador ganado
        public void IncrementarVictoria()
        {
            numVictorias++;
        }

        //Si el jugador perdido
        public void IncrementarDerrota()
        {
            numDerrotas++;
        }


        public virtual string AFichero()
        {
            return nombre +";" +contrasenya+";"+piezaEsNegra+";"+
               numVictorias + ";" + numDerrotas + ";"+porcentajeVic;
        }


        //Cargar Jugador
        public static List<Jugador> CargarJugador()
        {
            List<Jugador> jugadores = new List<Jugador>();
            string nombre,contrasenya, linea;
            bool piezaEsNegra=true;
            int numVictorias,numDerrotas;
            float porcentajeVic;
            ModoDificultad dificultad = ModoDificultad.FACIL;


            if (File.Exists(FICHERO))
            {
                using (StreamReader fichero = new StreamReader(FICHERO))
                {
                    while ((linea = fichero.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(';');
                        nombre = partes[0];
                        contrasenya = partes[1];
                        piezaEsNegra = bool.Parse(partes[2]);
                        numVictorias = Convert.ToInt32(partes[3]);
                        numDerrotas = Convert.ToInt32(partes[4]);
                        porcentajeVic = Convert.ToSingle(partes[5]);
                        if (partes.Length == 6)
                        {
                           
                            jugadores.Add(new JugadorHumano(nombre,contrasenya,
                                piezaEsNegra,numVictorias,numDerrotas,
                                porcentajeVic));
                        }
                        else
                        {
                            jugadores.Add(new JugadorIA(nombre, contrasenya,
                               piezaEsNegra, numVictorias, numDerrotas,
                               porcentajeVic,dificultad));
                        }
                    }
                }
            }
            return jugadores;
        }

        //Guadar los jugadores en Fichero
        public static void GuardarJugador(List<Jugador> jugadores)
        {
            using (StreamWriter fichero = new StreamWriter(FICHERO))
            {
                foreach (Jugador j in jugadores)
                {
                    fichero.WriteLine(j.AFichero());
                }
            }
        }

        //Volver a guardar que
        //solo guardar los datos del jugador actual

        public void VolverGuardarJugador(Jugador Jugador)
        {
            List<Jugador> jugadores = Jugador.CargarJugador();
            for (int i = 0; i < jugadores.Count; i++)
            {
                if (jugadores[i].Nombre == Jugador.Nombre)
                {
                    jugadores[i] = Jugador;
                }
            }
            Jugador.GuardarJugador(jugadores);
        }

    }
}
