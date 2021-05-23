using System.Net;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Soy el Final!!!!!!!!");

            //instancia de la clase appVentaCursoContext
            using(var db = new AppVentaCursoContext()){

                //Aqui llamo todos los datos de curso, luego traigo a curso instructor  a traves de la propiedad instructorLink y luego entonces puedo llamar a la tabla o entidad instructor
                //Aqui estoy haciendo un query que relaciona las 3 tablas
                //Recordemos que esta relacion es posible a las propiedades y anclas que hay en cada entidad que permite que una llame a la otra y asi sucesivamente
                //Esto aqui es un perfecto ejemplo de lo que en linq seria eager loading traer data simultaneamente como lo hacemos aqui, que traemos la data de 3 tablas al mismo tiempo
                var cursos = db.Curso.Include(c => c.InstructorLink).ThenInclude(ci => ci.Instructor);

                //bucle para mostrar los datos de cursos
                foreach (var curso in cursos){
                    Console.WriteLine(curso.Titulo);
                    //curso.InstructorLink devuelve una coleccion de elementos
                    //insLink es la cadena que llama al ancla dentro de curso instructor "instructor" entonces llamamos a la propiedad instructor para poder acceder a las diferentes propiedades de la entidad, ejemplo nombre apellido etc
                    foreach(var insLink in curso.InstructorLink){
                        Console.WriteLine("**********"+ insLink.Instructor.Nombre);
                    }
                }

                //Aqui estamos trayendo la data de curso incluyendo la data de la tabla comentarios haciendo uso de la propiedad comentarioLista
                //luego usamos un foreach para leer esos datos y mostrar rl titulo del curso y luego otro foreach para traer el texto de la tabla comentario
                /*var cursos = db.Curso.Include(c => c.ComentarioLista).AsNoTracking();
                foreach (var curso in cursos){

                    Console.WriteLine(curso.Titulo);
                    foreach(var comentario in curso.ComentarioLista){

                        Console.WriteLine(comentario.Alumno + " " + comentario.ComentarioTexto);
                    }
                }*/

                //AsNoTracking es para que no guarde nada en cache
                //Aqui tambien estoy llamando a todos los cursos y que me incluya con include los datos de la propiedad Precio promocion de la clase Precio
                /*var cursos = db.Curso.Include(p => p.PrecioPromocion).AsNoTracking();

                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo + "--------" + curso.PrecioPromocion.PrecioActual);
                }*/

                //aqui estoy usando la variable curso para traer la informacion de la base de datos a traves del foreach instanciando el contexto de la base de datos
                /*var cursos = db.Curso.AsNoTracking();   //arreglo IQueryable
                foreach(var curso in cursos){
                    Console.WriteLine(curso.Titulo + "--------" + curso.Descripcion);
                }*/

            }

        }
    }
}
