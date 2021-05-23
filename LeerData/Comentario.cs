namespace LeerData
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Alumno { get; set; }
        public int Puntaje { get; set; }
        public string ComentarioTexto { get; set; }
        public int CursoId { get; set; }
        
        //Ancla que permite obtener los datos de la entidad curso
        public Curso Curso { get; set; }
        
        
        
        
        
    }
}