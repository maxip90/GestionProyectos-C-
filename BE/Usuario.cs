using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public Usuario()
        {
            usuEstado = true;
            usuBloqueado = false;
            usuCii = 0;
            idEquipo = 0;
        }

        public Usuario(string nomuser, string pass) {
            usuNomUser = nomuser;
            usuPassUser = pass;
        
        }
        //public Usuario(string nombre, string apellido, DateTime fecha,
        //              int Idioma, int Rol, string mail) {

        //    usuNombre = nombre;
        //    usuApellido = apellido;
        //    fechaNac = fecha;
        //    idIdioma = Idioma;
        //    idRol = Rol;
        //    usuMail = mail;
        //    usuEstado = true;
        //    usuBloqueado = false;
        //    usuCii = 0;
        //    idEquipo = 0;
            
        //}



        private int _idUsuario;

        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private string _usuNombre;

        public string usuNombre
        {
            get { return _usuNombre; }
            set { _usuNombre = value; }
        }

        private string _usuApellido;

        public string usuApellido
        {
            get { return _usuApellido; }
            set { _usuApellido = value; }
        }

        private DateTime _fechaNac;

        public DateTime fechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        private string _usuMail;

        public string usuMail
        {
            get { return _usuMail; }
            set { _usuMail = value; }
        }

        private string _usuNomUser;

        public string usuNomUser
        {
            get { return _usuNomUser; }
            set { _usuNomUser = value; }
        }

        private string _usuPassUser;

        public string usuPassUser
        {
            get { return _usuPassUser; }
            set { _usuPassUser = value; }
        }

        private int _idIdioma;

        public int idIdioma
        {
            get { return _idIdioma; }
            set { _idIdioma = value; }
        }

        private bool _usuBloqueado;

        public bool usuBloqueado
        {
            get { return _usuBloqueado; }
            set { _usuBloqueado = value; }
        }

        private bool _usuEstado;

        public bool usuEstado
        {
            get { return _usuEstado; }
            set { _usuEstado = value; }
        }

        private int _idEquipo;

        public int idEquipo
        {
            get { return _idEquipo; }
            set { _idEquipo = value; }
        }

        private int _idRol;

        public int idRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        private int _usuCii;

        public int usuCii
        {
            get { return _usuCii; }
            set { _usuCii = value; }
        }

        private int _dvh;

        public int dvh
        {
            get { return _dvh; }
            set { _dvh = value; }
        }
        
    }
    
}
