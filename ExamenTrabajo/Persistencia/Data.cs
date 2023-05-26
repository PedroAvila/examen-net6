using ExamenTrabajo.Entity;

namespace ExamenTrabajo.Persistencia;

public class Data
{
    public int DNI { get; set; }
    public int Hora { get; set; }
    public int Dia { get; set; }
    public int Falta { get; set; }
    public TipoTrabajador Tipo { get; set; }
}