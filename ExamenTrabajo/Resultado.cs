using ExamenTrabajo.Entity;

namespace ExamenTrabajo;

public class Resultado
{
    public int DNI { get; set; }
    public TipoTrabajador Tipo { get; set; }
    public int Sueldo { get; set; }
    public int SalarioBonificacion { get; set; }
    public int MontoFinal { get; set; }
}