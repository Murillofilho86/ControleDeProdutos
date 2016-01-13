using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Dal.DataSource;
using System.Data.Entity;

namespace Projeto.Dal.Repository
{
    public abstract class GenericDal<TEntity> : IGenericDal<TEntity>
    where TEntity : class
    {

        public void Insert(TEntity obj)
        {
            using (Conexao Con = new Conexao())
            {
                Con.Entry(obj).State = EntityState.Added;
                Con.SaveChanges();
            }
        }

        public void Delete(TEntity obj)
        {
            using (Conexao Con = new Conexao())
            {
                Con.Entry(obj).State = EntityState.Deleted;
                Con.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            using (Conexao Con = new Conexao())
            {
                Con.Entry(obj).State = EntityState.Modified;
                Con.SaveChanges();
            }
        }

        public List<TEntity> FindAll()
        {
            using (Conexao Con = new Conexao())
            {
                return Con.Set<TEntity>().ToList();
            }
        }

        public TEntity FindById(int id)
        {
            using (Conexao Con = new Conexao())
            {
                return Con.Set<TEntity>().Find(id);
            }
        }
    }
}
