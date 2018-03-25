using Excecoes;
using Fachada;
using Negocio;
using Projecao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utilitario;

namespace ContadorPontos
{
    class Program
    {
        public static ClienteUtil ClienteUtil = new ClienteUtil();

        static void Main(string[] args)
        {
            try
            {
                ContabilizarPontosFachada fachada = new ContabilizarPontosFachada();

                List<ClienteArquivoUtil> clientes = fachada.AtualizarDadosClientes();

                clientes = fachada.ContabilizarMedalhas(clientes);

                RelatorioExibicaoResultado(clientes);
            }
            catch (ErroSistema e)
            {
                Console.WriteLine(new ErroSistema().MensagemPadrao(e.Message));
                Console.ReadKey();
            }    
        }

        private static void RelatorioExibicaoResultado(List<ClienteArquivoUtil> clientes)
        {
            RelatorioPorCliente(clientes);

            Console.WriteLine(string.Empty);

            RelatorioPorCidade(clientes);

            Console.WriteLine("========================================================");
            Console.WriteLine("Pressione qualquer tecla para finalizar.");
            Console.ReadKey();
            
        }

        private static void RelatorioPorCliente(List<ClienteArquivoUtil> clientes)
        {
            ClienteUtil clienteUtil = new ClienteUtil();

            //Alinhando nome
            int tamanhoMaiorNome = clientes.Max(w => w.Nome.Length);

            foreach (ClienteArquivoUtil cli in clientes)
            {

                Console.WriteLine("{0} | {1} anos | Ouro: {2} | Prata: {3} | Bronze: {4}", cli.Nome.PadRight(tamanhoMaiorNome),
                    clienteUtil.CalcularIdade(cli.Nascimento).ToString().PadLeft(2),
                    cli.Ouro.ToString().PadRight(4),
                    cli.Prata.ToString().PadRight(4),
                    cli.Bronze.ToString().PadRight(4));
            }
        }

        private static void RelatorioPorCidade(List<ClienteArquivoUtil> clientes)
        {
            foreach (CidadeRankingProjecao cidade in ClienteUtil.RankingCidadesPorMedalha(clientes))
            {
                Console.WriteLine("{0} | Ouro: {1} | Prata: {2} | Bronze: {3}", cidade.Regiao.PadRight(3),
                   cidade.Ouro.ToString().PadRight(4),
                   cidade.Prata.ToString().PadRight(4),
                   cidade.Bronze.ToString().PadRight(4));
            }

        }

    }
}
