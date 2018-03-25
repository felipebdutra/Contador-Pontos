using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace Utilitario.Interfaces
{
    public interface ILeitorArquivo
    {
        List<ClienteArquivoUtil> BuscarHistorico();
        List<ClienteArquivoUtil> BuscarAtualizacao();
        void Salvar(List<ClienteArquivoUtil> conteudo, bool identar = false);
    }
}
