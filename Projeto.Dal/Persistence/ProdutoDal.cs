using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Dal.DataSource;
using Projeto.Dal.Repository;
using Projeto.Entities;

namespace Projeto.Dal.Persistence
{
    public class ProdutoDal : GenericDal<Produto>
    {
        public List<Produto> FindByNome(string Nome)
        {
            using (Conexao Con = new Conexao())
            {
                return Con.Produto
                    .Where(p => p.Nome.StartsWith(Nome))
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }
    }
}
