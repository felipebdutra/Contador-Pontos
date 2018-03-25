using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using Constantes;
using Excecoes;

namespace Negocio
{
    public class ContabilizadorMedalhasNegocio
    {
        public List<ClienteArquivoUtil> ContabilizarMedalhas(List<ClienteArquivoUtil> clientes)
        {
            try
            {
                foreach (ClienteArquivoUtil cliente in clientes)
                {
                    cliente.Ouro = ContabilizarMedalhasOuro(cliente.Pontos);

                    cliente.Prata = ContabilizarMedalhasPrata(cliente.Pontos, cliente.Ouro);

                    cliente.Bronze = ContabilizarMedalhasBronze(cliente.Pontos, cliente.Ouro, cliente.Prata);
                }

                return clientes;
            }
            catch (ErroSistema e)
            {
                throw new ErroSistema(e.Message);
            }
     
        }

        private int ContabilizarMedalhasOuro(int pontos)
        {
            double total = pontos / ConstantesMedalhas.QntPtsMedalhaOuro;
            return (int)Math.Floor(total);
        }

        private int ContabilizarMedalhasPrata(int pontos, double qntOuro)
        {
            double total = (pontos - (ConstantesMedalhas.QntPtsMedalhaOuro * qntOuro)) / ConstantesMedalhas.QntPtsMedalhaPrata;
            return (int)Math.Floor(total);
        }

        private int ContabilizarMedalhasBronze(int pontos, double qntOuro, double qntPrata)
        {
            double qntPtsAposOuro = pontos - (ConstantesMedalhas.QntPtsMedalhaOuro * qntOuro) ;

            double qntPtsAposPrata = qntPtsAposOuro - (ConstantesMedalhas.QntPtsMedalhaPrata * qntPrata);

            double total = qntPtsAposPrata / ConstantesMedalhas.QntPtsMedalhaBronze;

            return (int)Math.Floor(total);
        }

    }
}
