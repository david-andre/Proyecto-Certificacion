using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUCertificacion.Transactions
{
    public class PedidoBLL
    {
        public static Pedido Get(int? id)
        {
            Entities db = new Entities();
            return db.Pedidoes.Find(id);
        }

        public static void Create(Pedido p)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        p.fechaPeticion = DateTime.Now;
                        p.estado = "En espera";
                        db.Pedidoes.Add(p);
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

        public static void Update(Pedido p)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if(p.fechaEjecucion == null)
                        {
                            p.estado = "En espera";
                        }
                        else
                        {
                            p.estado = "Aprovado";
                        }
                        db.Pedidoes.Attach(p);
                        db.Entry(p).State = System.Data.Entity.EntityState.Modified;
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
                        Pedido p = db.Pedidoes.Find(id);
                        db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Pedido> List()
        {
            Entities db = new Entities();
            return db.Pedidoes.ToList();
        }

        public static List<Pedido> List(int id)
        {
            Entities db = new Entities();
            return db.Pedidoes.Where(x => x.Cliente.idcliente == id).ToList();
        }
    }
}
