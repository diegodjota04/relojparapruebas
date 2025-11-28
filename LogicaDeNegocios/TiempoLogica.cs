using Entidades;
namespace LogicaDeNegocios
{
    public class TiempoLogica
    {
        public Tiempo tiempo;
        

        public TiempoLogica()
        {
            
        }
        
        public TiempoLogica(DateTime hora_inicio) 
        {
            ActualizarTiempo (hora_inicio);
        }
        public void ActualizarTiempo(DateTime hora_inicio)
        {
            DateTime hora_finalizacion_regular = hora_inicio.AddMinutes(80);
            DateTime hora_finalizacion_apoyos = hora_inicio.AddMinutes(110);
            DateTime hora_finalizacion_regular2 = hora_inicio.AddMinutes(120);
            DateTime hora_finalizacion_apoyos2 = hora_inicio.AddMinutes(160);
            tiempo = new Tiempo(hora_inicio, hora_finalizacion_regular, hora_finalizacion_apoyos, hora_finalizacion_regular2, hora_finalizacion_apoyos2);
        }
        public DateTime ObtenerHoraInicio()
        {
            return tiempo.HoraInicio;
        }
        public DateTime ObtenerHoraFinalizacionRegular()
        {
            return tiempo.HoraFinalizacionRegular;
        }
        public DateTime ObtenerHoraFinalizacionApoyos()
        {
            return tiempo.HoraFinalizacionApoyos;
        }

        public DateTime ObtenerHoraFinalizacionRegular2()
        {
            return tiempo.HoraFinalizacionRegular2;
        }
        public DateTime ObtenerHoraFinalizacionApoyos2()
        {
            return tiempo.HoraFinalizacionApoyos2;
        }
    }
}