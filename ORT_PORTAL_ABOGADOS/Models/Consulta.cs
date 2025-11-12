using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ORT_PORTAL_ABOGADOS.Models
{
    public class Consulta {

        //Atributos ----------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Descripcion { get; set; }
        public double Precio { get; set; }
        public String NombreCliente { get; set; }
        public String ApellidoCliente { get; set; }
        public String MailCliente { get; set; }
        public bool EstaActiva { get; set; }
        public int  IdAbogado { get; set; }

        //Métodos ------------------------------------------------------------------------------
        public Consulta() {
            this.EstaActiva = false;
        }
        public Consulta(String descripcion, String nombre, String apellido, String mail) {
            this.Descripcion = descripcion;
            this.NombreCliente = nombre;
            this.ApellidoCliente = apellido;
            this.MailCliente = mail;
            this.EstaActiva = false;
        }

        public void CambiarEstado() {
            this.EstaActiva = !this.EstaActiva;
        }

        public void SetPrecio(double precio) {
            this.Precio = precio;
        }

        public bool MismoId(int id) {
            return this.Id == id;
        }
    }
}