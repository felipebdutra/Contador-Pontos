using Constantes;
using Utilitario.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utilitario;
using Excecoes;

namespace ContadorPontos.Utilitario
{
    public class LeitorArquivoTXT : ILeitorArquivo
    {

        public List<ClienteArquivoUtil> BuscarAtualizacao()
        {

            string linha;
            List<ClienteArquivoUtil> listaClientes = new List<ClienteArquivoUtil>();
            StreamReader arquivo = null;

            try
            {
                VerificarArquivoExistente();

                arquivo = new StreamReader(Constantes.ConstantesArquivos.DiretorioArquivoTxt, Encoding.UTF8);
                
                while ((linha = arquivo.ReadLine()) != null)
                    listaClientes.Add(PreencherCliente(linha.Split(';')));

                return listaClientes;
            }
            catch (Exception e)
            {
                throw new ErroSistema(string.Format(Constantes.ConstantesExcecoes.ErroLeituraArquivo,
                    Constantes.ConstantesArquivos.DiretorioArquivoTxt, e.Message));
            }
            finally
            {
                if (arquivo != null) arquivo.Close();
            }
        }

        private void VerificarArquivoExistente()
        {
            if (!File.Exists(Constantes.ConstantesArquivos.DiretorioArquivoTxt))
                throw new ErroSistema(string.Format(Constantes.ConstantesExcecoes.ErroArquivoNaoEncontrado, 
                    Constantes.ConstantesArquivos.NomeArquivoTxt, 
                    Constantes.ConstantesArquivos.DiretorioArquivoTxt));
        }

        private ClienteArquivoUtil PreencherCliente(string[] arrayLinha)
        {
            ClienteArquivoUtil clienteLoop = new ClienteArquivoUtil()
            {
                IdERP = arrayLinha[0],
                Nome = arrayLinha[1],
                Regiao = arrayLinha[3],
            };

            if (DateTime.TryParse(arrayLinha[2], out DateTime dataConvertida))
                clienteLoop.Nascimento = dataConvertida;

            if (int.TryParse(arrayLinha[4], out int numeroConvertido))
                clienteLoop.Pontos = numeroConvertido;

            return clienteLoop;
        }

        public List<ClienteArquivoUtil> BuscarHistorico()
        {
            //Histórico em extenção TXT não disponível.
            throw new NotImplementedException();
        }

        public void Salvar(List<ClienteArquivoUtil> conteudo, bool identar = false)
        {
            //Histórico em extenção TXT não disponível.
            throw new NotImplementedException();
        }


    }
}