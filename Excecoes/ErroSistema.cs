using Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{

    [Serializable]
    public class ErroSistema : Exception
    {
        public ErroSistema() { }
        public ErroSistema(string message) : base(message) { }
        public ErroSistema(string message, Exception inner) : base(message, inner) { }
        protected ErroSistema(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public string MensagemPadrao(string mensagem)
        {
            return string.Format(ConstantesExcecoes.ErroPadrao, mensagem);
        }

    }



}
