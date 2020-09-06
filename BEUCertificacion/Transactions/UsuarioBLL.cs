using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class UsuarioBLL
    {
        public static Usuario Get(int? id)
        {
            Entities db = new Entities();
            return db.Usuarios.Find(id);
        }

        public static void Create(Usuario c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuarios.Add(c);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Update(Usuario c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuarios.Attach(c);
                        db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        public static List<Usuario> List()
        {
            Entities db = new Entities();
            return db.Usuarios.ToList();
        }

        public static Usuario Validate(Usuario usuario)
        {
            Entities db = new Entities();
            return db.Usuarios.FirstOrDefault(x => x.usuario == usuario.usuario
                && x.contrasena == usuario.contrasena);

        }
    }
}
