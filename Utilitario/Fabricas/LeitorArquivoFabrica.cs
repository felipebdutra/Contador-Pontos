
using ContadorPontos.Utilitario;
using Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Interfaces;

namespace Utilitario.Fabricas
{
    public class LeitorArquivoFabrica
    {
        public ILeitorArquivo GerarLeitorHistorico()
        {
            //ExtencoesEnum.JSON fixo porque a implementação para TXT está fora do escopo atualmente.
            switch (ExtencoesEnum.JSON)
            {
                case ExtencoesEnum.TXT:
                    return new LeitorArquivoTXT();
                case ExtencoesEnum.JSON:
                    return new LeitorArquivoJSON();
                default:
                    break;
            }

            return null;
        }

        public ILeitorArquivo GerarLeitorAtualizacao()
        {
            //ExtencoesEnum.TXT fixo porque a implementação para JSON está fora do escopo atualmente.
            switch (ExtencoesEnum.TXT)
            {
                case ExtencoesEnum.TXT:
                    return new LeitorArquivoTXT();
                case ExtencoesEnum.JSON:
                    return new LeitorArquivoJSON();
                default:
                    break;
            }

            return null;
        }
    }
}
