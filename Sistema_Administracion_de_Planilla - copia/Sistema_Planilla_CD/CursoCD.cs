using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class CursoCD
    {
        public List<Curso> ListarCursos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Curso.ToList();
            }
        }

        public void Crear(Curso curso)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Curso.Add(curso);
                db.SaveChanges();
            }
        }

        public Curso ObtenerCurso(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                //return db.Departamento.Where(p => p.Id_Departamento == id).FirstOrDefault();
                return db.Curso.Find(id);
            }
        }

        public void Editar(Curso curso)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Curso.Find(curso.Id_Curso);
                origen.Nombre_Curso = curso.Nombre_Curso;
                origen.FechaActualizacion_Curso = curso.FechaActualizacion_Curso;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var curso = db.Curso.Find(id);
                db.Curso.Remove(curso);
                db.SaveChanges();
            }

        }
    }
}
