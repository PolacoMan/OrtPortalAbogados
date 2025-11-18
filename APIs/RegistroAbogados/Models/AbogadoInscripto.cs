using System.ComponentModel.DataAnnotations;

namespace RegistroAbogados.Models
{
    public class AbogadoInscripto
    {
        [Key]
        public Guid Id { get; set; }
        public int AbogadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NroDocumento { get; set; }

        [EnumDataType(typeof(Genero))]
        public Genero Genero { get; set; }
        public int Tomo { get; set; }
        public int Folio { get; set; }
        public bool Habilitado { get; set; }

        public AbogadoInscripto(int abogadoId, string nombre, string apellido, int nroDocumento, Genero genero, int tomo, int folio)
        {
            Id = Guid.NewGuid();
            AbogadoId = abogadoId;
            Nombre = nombre;
            Apellido = apellido;
            NroDocumento = nroDocumento;
            Genero = genero;
            Tomo = tomo;
            Folio = folio;
            Habilitado = true;
        }

    }
}
