using Utilitario.Interfaces;
using Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario.Fabricas;
using Negocio;
using System.Web.Script.Serialization;
using Enumeradores;
using Constantes;
using Excecoes;

namespace Fachada
{
    public class ContabilizarPontosFachada
    {
        public List<ClienteArquivoUtil> AtualizarDadosClientes()
        {
            LeitorArquivoFabrica fabricaLeitorArquivo = new LeitorArquivoFabrica();

            try
            {
                ILeitorArquivo leitorAtualizacao = fabricaLeitorArquivo.GerarLeitorAtualizacao();
                ILeitorArquivo leitorHistorico = fabricaLeitorArquivo.GerarLeitorHistorico();

                List<ClienteArquivoUtil> listaHistorico = leitorHistorico.BuscarHistorico() ?? new List<ClienteArquivoUtil> ();
                List<ClienteArquivoUtil> listaAtualizacao = leitorAtualizacao.BuscarAtualizacao();

                List<ClienteArquivoUtil> conteudoAtualizado = new ClientesImportadosNegocio().AtualizarListaClientes(listaAtualizacao, listaHistorico);

                leitorHistorico.Salvar(conteudoAtualizado, true);

                return conteudoAtualizado;
            }
            catch (ErroSistema e)
            {               
                throw new ErroSistema(e.Message);
            }
         
        }

        public List<ClienteArquivoUtil> ContabilizarMedalhas(List<ClienteArquivoUtil> clientes)
        {
            try
            {
                return new ContabilizadorMedalhasNegocio().ContabilizarMedalhas(clientes);
            }
            catch (Exception e)
            {
                throw new ErroSistema(e.Message);
            }
        }
    }
}
