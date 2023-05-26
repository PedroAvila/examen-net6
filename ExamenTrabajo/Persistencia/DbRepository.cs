using System.Transactions;
using ExamenTrabajo.Entity;

namespace ExamenTrabajo.Persistencia;

public class DbRepository : IDbRepository
{
    private string path = @"D:\Examen\data-trabajadores.csv";
    
    public List<Data> GetAll()
    {
        var lineas = new List<Data>();
        using (StreamReader sr = new StreamReader(path))
        {
            sr.ReadLine();
            while (sr.Peek() != -1)
            {
                //En lineas me trae la info
                var line = sr.ReadLine();
                //lineas.Add(sr.ReadLine());
                string[] colums = line.Split('|');
                var d = new Data()
                    {
                        DNI = Convert.ToInt32(colums[0]),
                        Hora = Convert.ToInt32(colums[1]),
                        Dia = Convert.ToInt32(colums[2]),
                        Falta = Convert.ToInt32(colums[3]),
                        Tipo = (TipoTrabajador)(Convert.ToInt32(colums[4]))
                    };
                lineas.Add(d);
            }
        }

        return lineas;
    }
}