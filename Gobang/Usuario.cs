//Datos de los Usuario,la clase padre de Jugador

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    public class Usuario
    {
        const string FICHERO = "usuarios.txt";

        protected string nombre;
        protected string contrasenya;
        
        /*
         * Creo que numVictorias,numDerrotas,porcentajeVic 
         * para la clase Jugador es mejor que un Usuario
         */

        public Usuario(string nombre, string contrasenya)
        {
            this.nombre = nombre;
            this.contrasenya = contrasenya;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Contrasenya
        {
            get { return contrasenya; }
            set { contrasenya = value; }
        }

        public virtual string AFichero()
        {
            return nombre + ";" + contrasenya;
        }


        public static List<Usuario> CargarUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string nombre, contrasenya, linea;
            

            if (File.Exists(FICHERO))
            {
                using (StreamReader fichero = new StreamReader(FICHERO))
                {
                    while ((linea = fichero.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(';');
                        if (partes.Length == 2)
                        {
                            nombre = partes[0];
                            contrasenya = partes[1];
                            usuarios.Add(new Usuario(nombre, contrasenya));
                        }
                    }
                }
            }
            return usuarios;
        }


        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            using (StreamWriter fichero = new StreamWriter(FICHERO))
            {
                foreach (Usuario u in usuarios)
                {
                    fichero.WriteLine(u.AFichero());
                }
            }
        }

        //Comprobar si existe el usuario
        public static bool ValidaUsuario(string nombre, string contrasenya)
        {
            List<Usuario> usuarios = CargarUsuario();
            if (usuarios == null) 
                return false;
            foreach (Usuario u in usuarios)
            {
                if (u.Nombre == nombre && u.contrasenya == contrasenya)
                {
                    return true;
                }
            }
            return false;
        }


    }
}





















/*
namespace Gobang
{
    public class Usuario
    {
        const string FICHERO = "usuarios.txt";

        private string nombre;
        private string contrasenya;
        private int numVictorias;
        private int numDerrotas;
        private float porcentajeVic;

        public Usuario(string nombre, string contrasenya,
            int numVictorias, int numDerrotas, float porcentajeVic)
        {
            this.nombre = nombre;
            this.contrasenya = contrasenya;
            this.numVictorias = numVictorias;
            this.numDerrotas = numDerrotas;
            this.porcentajeVic = porcentajeVic;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Contrasenya
        { get { return contrasenya; }
            set { contrasenya = value; }
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
            get { return porcentajeVic; }
            set { porcentajeVic = value; }
        }

       
        public virtual string AFichero()
        {
            return nombre+ ";" +contrasenya + "; " +
               numVictorias + ";" + numDerrotas+porcentajeVic;
        }


        public static List<Usuario> CargarUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string nombre, contrasenya, linea;
            int numVictorias, numDerrotas;
            float porcentajeVic;

            if (File.Exists(FICHERO))
            {
                using (StreamReader fichero = new StreamReader(FICHERO))
                {
                    while ((linea = fichero.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(';');
                        if (partes.Length == 5)
                        {
                            nombre = partes[0];
                            contrasenya = partes[1];
                            numVictorias = Convert.ToInt32(partes[2]);
                            numDerrotas = Convert.ToInt32(partes[3]);
                            porcentajeVic = Convert.ToInt32(partes[4]);
                            usuarios.Add(new Usuario(nombre, contrasenya,
                                numVictorias, numDerrotas, porcentajeVic));
                        }
                    }
                }
            }
            return usuarios;
        }

*/