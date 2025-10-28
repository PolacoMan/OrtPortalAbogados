using ORT_PORTAL_ABOGADOS.Models;
public class Cliente {

    //Atributos ----------------------------------------------------------------------------
    private String Mail;
    private String Nombre;
    private String Apellido;

    //Métodos ------------------------------------------------------------------------------
    public Cliente(String nombre, String apellido, String mail)
    {
        this.Mail = mail;
    }

    public Consulta RealizarConsulta(String descripcion) {
        return new Consulta(descripcion, this.Mail, this.Nombre, this.Apellido);
    }
}