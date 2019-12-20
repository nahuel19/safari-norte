using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class CitaComponent : IComponent<Cita>
    {
        public Cita Add(Cita cita)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();

            result = citaDAC.Create(cita);
            return result;
            //List<Cita> citas = new CitaDAC().Read();
            //int count=0;

            //var existeTurno = new CitaDAC().Read().Where(x => x.Fecha == cita.Fecha).FirstOrDefault();

            //foreach (var c in citas)
            //{
            //    if(cita.Fecha == c.Fecha)
            //    {
            //        count += 1;
            //    }                
            //}

            //if(existeTurno == null)
            //{
            //    result = citaDAC.Create(cita);
            //    return result;
            //}
            //else
            //{
            //    throw new Exception("Horario NO disponible");

            //}

        }


        public void Edit(Cita cita)
        {
            var citaDAC = new CitaDAC();
            citaDAC.Update(cita);

        }

        public Cita Find(int? id)
        {
            Cita result = default(Cita);
            var citaDAC = new CitaDAC();
            result = citaDAC.ReadBy(id.Value);
            
            result.Medico = new MedicoDAC().ReadBy(result.MedicoId);
            result.Paciente = new PacienteDAC().ReadBy(result.PacienteId);
            result.Sala = new SalaDAC().ReadBy(result.SalaId);
            result.TipoServicio = new TipoServicioDAC().ReadBy(result.TipoServicioId);

            return result;
        }

        public List<Cita> ToList()
        {
            List<Cita> result = default(List<Cita>);

            var citaDAC = new CitaDAC();
            result = citaDAC.Read();


            foreach (var r in result)
            {
                r.Medico = new MedicoDAC().ReadBy(r.MedicoId);
                r.Paciente = new PacienteDAC().ReadBy(r.PacienteId);
                r.Sala = new SalaDAC().ReadBy(r.SalaId);
                r.TipoServicio = new TipoServicioDAC().ReadBy(r.TipoServicioId);
            }



            return result;

        }

        public void Remove(Cita cita)
        {
            var citaDAC = new CitaDAC();
            citaDAC.DeleteCita(cita);
        }


        public void Facturar(Cita cita, int val)
        {
            //var tServicio = new TipoServicioDAC().ReadBy(cita.TipoServicioId);
            var precio = new PrecioDAC().Read().Where(x => x.TipoServicioId == cita.TipoServicioId && x.FechaDesde < DateTime.Now && x.FechaHasta > DateTime.Now).FirstOrDefault();
            var mascota = new PacienteDAC().ReadBy(cita.PacienteId);

            var movimiento1 = new Movimiento();
            var movimiento2 = new Movimiento();

            movimiento1.Fecha = DateTime.Now;
            movimiento1.ClienteId = mascota.ClienteId;
            movimiento1.TipoMovimientoId = 4;
            movimiento1.Valor = precio.Valor;

            movimiento2.Fecha = DateTime.Now;
            movimiento2.ClienteId = mascota.ClienteId;
            movimiento2.TipoMovimientoId = 1;
            movimiento2.Valor = val;


            var movDAC = new MovimientoDAC();

            movDAC.Create(movimiento1);
            movDAC.Create(movimiento2);



            var citaDAC = new CitaDAC();
            citaDAC.Facturar(cita);

        }

    }
}
