using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ORT_PORTAL_ABOGADOS.Models
{
    public class Abogado{

        //Atributos ----------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Nombre { get; set; }
        public String Apellido { get; set; }   
        public int Tomo { get; set; }
        public int Folio { get; set; }
        public Genero Genero { get; set; }
        public int Dni { get; set; }
        public AreaPractica Area { get; set; }
        public List<Consulta> ConsultasActivas { get; set; }
        public List<Consulta> SolicitudesPendientes { get; set; }
        public String Usuario { get; set; }
        public String Password { get; set; }

        //Métodos ------------------------------------------------------------------------------
        public Abogado()
        {
            this.ConsultasActivas = new List<Consulta>();
            this.SolicitudesPendientes = new List<Consulta>();
        }

        public Abogado(String nombre, String apellido, int tomo, int folio, AreaPractica area, String usuarioParam, String passParam, Genero genero)
        {
            this.Tomo = tomo;
            this.Folio = folio;
            this.Genero = genero;
            this.Apellido = apellido;
            Area = area;
            ConsultasActivas = new List<Consulta>();
            SolicitudesPendientes = new List<Consulta>();
            this.Usuario = usuarioParam;
            this.Password = passParam;
        }

        public void AceptarSolicitud(int id, double precio) {
            Consulta consulta = BuscarConsultaPorId(id, this.SolicitudesPendientes);
            consulta.CambiarEstado();
            DesignarPrecio(precio, consulta);
            SolicitudesPendientes.Remove(consulta);
            ConsultasActivas.Add(consulta);
        }

        private void DesignarPrecio(double precio, Consulta consulta) {
            consulta.SetPrecio(precio);
        }

        public void RechazarSolicitud (int id) {
            Consulta consulta = BuscarConsultaPorId(id, this.SolicitudesPendientes);
            SolicitudesPendientes.Remove(consulta);
        }

        public void FinalizarConsulta (int id) {
            Consulta consulta = BuscarConsultaPorId(id, this.ConsultasActivas);
            ConsultasActivas.Remove(consulta);
        }

        public void MoverAlFinal(int id) {
            Consulta consulta = BuscarConsultaPorId(id, this.SolicitudesPendientes);
            SolicitudesPendientes.Remove(consulta);
            SolicitudesPendientes.Add(consulta);
        }

        private Consulta BuscarConsultaPorId(int id, List<Consulta> consultas)
        {
            Consulta consulta = null;
            int i = 0;

            while (i < consultas.Count && consulta == null)
            {
                Consulta c = consultas[i];
                if (c.MismoId(id))
                {
                    consulta = c;
                }
                i++;
            }
            return consulta;
        }

        public void AgregarSolicitud(Consulta consulta)
        {
            this.SolicitudesPendientes.Add(consulta);
        }

    }

}


