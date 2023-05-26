using System.Net;
using ExamenTrabajo.Entity;
using ExamenTrabajo.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTrabajo.Controllers;

[Route("api/trabajadores")]
[ApiController]
public class TrabajadorController : Controller
{
    private readonly IDbRepository _dbRepository;

    public TrabajadorController(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<List<Resultado>>), (int)HttpStatusCode.OK)]
    public IActionResult Index()
    {
        var datos = _dbRepository.GetAll();
        //Obrero, Supervisor, Gerente
        //Salario * por cada hora laborada por 15 a este monto se le resta 120 por cada falta, se suma bonificacion
        //+ 130 al monto final se le aplica un impuesto de 12%


        var obreros = datos.Where(x => x.Tipo == (int)TipoTrabajador.Obrero).ToList();
        var resultados = new List<Resultado>();
        foreach (var obrero in obreros)
        {
            var sueldo = (obrero.Hora * 15) - 120 * obrero.Falta;
            var salarioBonificacion = sueldo + 130;
            var montoFinal = (salarioBonificacion * 12) / 100;

            var r = new Resultado()
            {
                DNI = obrero.DNI,
                Tipo = obrero.Tipo,
                Sueldo = sueldo,
                SalarioBonificacion = salarioBonificacion,
                MontoFinal = montoFinal
            };
            resultados.Add(r);
        }
        //var supervisores = datos.Where(x => x.Tipo == (int)TipoTrabajador.Supervisor);
        //var gerentes = datos.Where(x => x.Tipo == (int)TipoTrabajador.Gerente);
        
        var response = new Response<List<Resultado>>("Success", resultados);
        return Ok(response);
    }
}