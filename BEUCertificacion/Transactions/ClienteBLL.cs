using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class ClienteBLL
    {
        public static Cliente Get(int? id)
        {
            Entities db = new Entities();
            return db.Clientes.Find(id);
        }

        public static void Create(Cliente c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Clientes.Add(c);
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

        public static void Update(Cliente c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Clientes.Attach(c);
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

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Cliente e = db.Clientes.Find(id);
                        db.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                        foreach (Pedido p in db.Pedidoes.ToList())
                        {
                            if (p.idcliente == id)
                            {
                                db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                            }
                        }
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

        public static List<Cliente> List()
        {
            Entities db = new Entities();
            return db.Clientes.ToList();
        }

        public static List<Cliente> ListToNames()
        {
            {
                Entities db = new Entities();
                List<Cliente> resultado = new List<Cliente>();
                db.Clientes.ToList().ForEach(x => resultado.Add(new Cliente { nombre = x.nombre + " " + x.apellido, idcliente = x.idcliente }));
                return resultado;
            }
        }
    }
}
