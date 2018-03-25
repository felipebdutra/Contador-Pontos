using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    [DataContract]
    public class ClienteArquivoUtil
    {
        [DataMember]
        public string IdERP { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public DateTime Nascimento { get; set; }
        [DataMember]
        public string Regiao { get; set; }
        [DataMember]
        public int Pontos { get; set; }

        public int Ouro { get; set; }
        public int Prata { get; set; }
        public int Bronze { get; set; }
    }
}
