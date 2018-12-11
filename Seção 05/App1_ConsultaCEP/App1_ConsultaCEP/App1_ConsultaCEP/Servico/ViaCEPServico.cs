using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;
namespace App1_ConsultaCEP.Servico
{
    class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string CEP)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, CEP);

            WebClient wc = new WebClient();

            //metodoSincrono trava a tela
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.CEP == null) return null;
           
            return end;

        }


    }
}
