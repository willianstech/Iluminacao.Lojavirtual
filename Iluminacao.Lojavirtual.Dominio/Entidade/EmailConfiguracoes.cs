using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iluminacao.Lojavirtual.Dominio.Entidade
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.iluminacao.com.br";
        public int ServidorPorta = 587;
        public string Usuario = "iluminacao";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\envioemail";
        public string De = "iluminacao@iluminacao.com.br";
        public string Para = "pedido@iluminacao.com.br";
    }
}
