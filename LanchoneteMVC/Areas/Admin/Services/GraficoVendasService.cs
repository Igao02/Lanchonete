using LanchoneteMVC.Context;
using LanchoneteMVC.Models;

namespace LanchoneteMVC.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _appDbContext;

        public GraficoVendasService(AppDbContext context)
        {
            _appDbContext = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);


            //Consulta onde eu agrupo os dados da tabela pedido detalhem, lanche, com base na data do pedido enviado
            var lanches = (from pd in _appDbContext.PedidosDetalhe
                           join l in _appDbContext.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade),
                           });

            var lista = new List<LancheGrafico>();
            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }

            return lista;

        }

    }
}
