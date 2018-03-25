using Projecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class ClienteUtil
    {
        public int CalcularIdade(DateTime nascimento)
        {
            var idade = DateTime.Today.Year - nascimento.Year;
            return (nascimento > DateTime.Today.AddYears(-idade)) ? idade-- : idade;
        }

        public IEnumerable<CidadeRankingProjecao> RankingCidadesPorMedalha(List<ClienteArquivoUtil> clientes) {
            
           return clientes
                .GroupBy(g => g.Regiao)
                .Select(s => new CidadeRankingProjecao
                {
                    Regiao = s.Select(ss => ss.Regiao).FirstOrDefault().ToString(),
                    Ouro = s.Sum(ss => ss.Ouro),
                    Prata = s.Sum(ss => ss.Prata),
                    Bronze = s.Sum(ss => ss.Bronze)
                })
                .OrderByDescending(o => o.Ouro)
                .ThenBy(o => o.Prata)
                .ThenBy(o => o.Bronze);

        }
    }
}
