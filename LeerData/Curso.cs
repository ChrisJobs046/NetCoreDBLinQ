using System;
using System.Collections.Generic;

namespace LeerData
{
    public class Curso
    {
        public int CursoId { get; set; }

        public string Titulo { get; set;}

        public string Descripcion { get; set;}

        public DateTime FechaPublicacion { get; set; }
        public Precio PrecioPromocion { get; set; }

        //AL ser un conjunto de comentarios hacemos un icollection y le pasamos la clase o objeto comentario
        public ICollection<Comentario> ComentarioLista { get; set; }

        //propiedad que llama a cursoInstructor
        public ICollection<CursoInstructor> InstructorLink { get; set; }
    }
}