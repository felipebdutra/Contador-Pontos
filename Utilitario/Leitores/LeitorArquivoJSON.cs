using Excecoes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utilitario.Interfaces;

namespace Utilitario
{
    public class LeitorArquivoJSON : ILeitorArquivo
    {
        public List<ClienteArquivoUtil> BuscarHistorico()
        {
            try
            {
                this.VerificarExistenciaArquivo();

                return this.ObterConteudo(Constantes.ConstantesArquivos.DiretorioArquivoJson);

            }
            catch (ErroSistema e)
            {
                throw new ErroSistema(string.Format(Constantes.ConstantesExcecoes.ErroLeituraArquivo, Constantes.ConstantesArquivos.DiretorioArquivoJson, e.Message));
            }

        }

        public List<ClienteArquivoUtil> ObterConteudo(string caminhoArquivo)
        {
            string texto = File.ReadAllText(caminhoArquivo);

            return JsonConvert.DeserializeObject<List<ClienteArquivoUtil>>(texto);
        }

        public void Salvar(List<ClienteArquivoUtil> conteudo, bool identar = false)
        {
            Formatting formatacao = identar ? Formatting.Indented : Formatting.None;
            string texto = JsonConvert.SerializeObject(conteudo, formatacao);
            File.WriteAllText(Constantes.ConstantesArquivos.DiretorioArquivoJson, texto);
        }

        public void VerificarExistenciaArquivo() { 
        
            if (!File.Exists(Constantes.ConstantesArquivos.DiretorioArquivoJson))
                File.Create(Constantes.ConstantesArquivos.DiretorioArquivoJson).Close();

        }


        public List<ClienteArquivoUtil> BuscarAtualizacao()
        {
            throw new NotImplementedException();
        }
    }
}
