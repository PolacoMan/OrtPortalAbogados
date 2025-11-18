namespace RegistroAbogados.Models
{
    public class AbogadoRequest
    {
            public int Tomo { get; set; }
            public int Folio { get; set; }
            public int NroDocumento { get; set; }
            public Genero Genero { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Apellido { get; set; } = string.Empty;
        
    }
}
