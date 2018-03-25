using Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace Negocio
{
    public class ClientesImportadosNegocio
    {

        public List<ClienteArquivoUtil> AtualizarListaClientes(List<ClienteArquivoUtil> atual, List<ClienteArquivoUtil> historico)
        {
            ClienteArquivoUtil clienteAtualizado;
            List<ClienteArquivoUtil> adicionados = new List<ClienteArquivoUtil>();
            List<ClienteArquivoUtil> listaClientes = new List<ClienteArquivoUtil>();

            try
            {
               
                //Atualiza registros existentes na lista de histórico
                foreach (ClienteArquivoUtil cliente in historico)
                {
                    clienteAtualizado = atual.Where(w => w.IdERP == cliente.IdERP).FirstOrDefault();

                    listaClientes.Add(clienteAtualizado != null ? clienteAtualizado : cliente);
                }

                //Adiciona registros novos na lista de histórico
                foreach (var item in atual.Where(w => !listaClientes.Any(a => w.IdERP == a.IdERP)))
                    listaClientes.Add(item);

                return listaClientes;
            }
            catch (ErroSistema e)
            {
                throw new ErroSistema(e.Message);
            }

        }
    }
}
