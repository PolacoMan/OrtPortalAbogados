using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ORT_PORTAL_ABOGADOS.Models
{
        public class Estudio{

        //Atributos ----------------------------------------------------------------------------
        private String Nombre;
        private List<Abogado> Plantel;

        //Métodos ------------------------------------------------------------------------------
        public Estudio(String nombre)
        {
            this.Nombre = nombre;
            Plantel = new List<Abogado>();
        }

        //TO DO
        public bool ValidarInicioSesion(String Username, String Password)
        {
            return false;
        }

        //TO DO, se usará en el ValidarIncioSesion
        private bool ValidarUsuario(String Usuario)
        {
            return false;
        }

        //TO DO, se usará en el ValidarIncioSesion
        private bool ValidarContrasena(String Usuario)
        {
            return false;
        }

        //TO DO, relacionado a interacción con BD
        public bool VerificarAcceso(Abogado Abogado)
        {
            return false;
        }

        //TO DO, revisar funcionalidad
        public String NotificarCliente(String FirstParam, String SecondParam)
        {
            return null;
        }
    
        //TO DO
        public void AgregarSolicitud(Consulta consulta)
        {
            foreach (Abogado abogado in this.Plantel)
            {
                abogado.AgregarSolicitud(consulta);
            }
        }
    }
}