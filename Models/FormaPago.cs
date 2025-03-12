using System.ComponentModel.DataAnnotations;

public class FormaPago
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Descripcion { get; set; } = string.Empty;

    public bool Estado { get; set; } = true;
}