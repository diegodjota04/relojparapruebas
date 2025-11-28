namespace Entidades
{
    public class Tiempo
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacionRegular { get; set; }
        public DateTime HoraFinalizacionApoyos { get; set; }
        public DateTime HoraFinalizacionRegular2 { get; set; }
        public DateTime HoraFinalizacionApoyos2 { get; set; }


        
        public Tiempo()
        {
            HoraInicio = DateTime.Now;
            HoraFinalizacionRegular = HoraInicio.AddMinutes(80);//Define hora de finalización para estudiantes regulares en prueba 1
            HoraFinalizacionApoyos = HoraInicio.AddMinutes(120);//Define hora de finalización para estudiantes con apoyos en prueba 1
            HoraFinalizacionRegular2 = HoraInicio.AddMinutes(120);//Define hora de finalización para estudiantes regulares en prueba 2
            HoraFinalizacionApoyos2 = HoraInicio.AddMinutes(180);//Define hora de finalización para estudiantes con apoyos en prueba 2
        }

        public Tiempo(DateTime hora_inicio, DateTime hora_finalizacion_regular, DateTime hora_finalizacion_apoyos, DateTime hora_finalizacion_regular2, DateTime hora_finalizacion_apoyos2)
        {
            HoraInicio=hora_inicio;
            HoraFinalizacionRegular = hora_finalizacion_regular;
            HoraFinalizacionApoyos = hora_finalizacion_apoyos;
            HoraFinalizacionRegular2 = hora_finalizacion_regular2;
            HoraFinalizacionApoyos2 = hora_finalizacion_apoyos2;
            

        }
    }
}