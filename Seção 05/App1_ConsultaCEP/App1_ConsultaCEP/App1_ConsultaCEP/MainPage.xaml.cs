using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultaCEP.Servico.Modelo;
using App1_ConsultaCEP.Servico;
using QRCoder;
using System.Drawing;

namespace App1_ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            //TODO - Lógica do programa;

            //TODO - Validações

            string cep = CEP.Text.Trim();
            try
            {
                if (IsValidCEP(cep))
                {


                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end!=null)
                    {
                        RESULTADO.Text = string.Format("Endereco: {2}, {3} - {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço informado não foi encontrado para o cep informado" + cep,"OK");
                    }
                   
                }
            }
            catch (Exception err)
            {
                                DisplayAlert("Erro Crítico", err.Message, "OK");
            }
          

        }

        private bool IsValidCEP(string cep)
        {
            //if (cep.Length != 8) {
            //    DisplayAlert("ERRO", "CEP INVALIDO", "CEP deve conter 8 caracteres", "OK");
            //    return false;//ERRO
            //}
            
            int NewCEP=0;
            if (!int.TryParse(cep,out NewCEP))
            {
                DisplayAlert("ERRO", "CEP INVALIDO", "CEP deve ser composto apenas por numeros", "OK");
                return false;//ERRO
            }

            return true;
        }
        private void QRCodeGenerate(string Data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("2018.DWD3", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            
        }
    }
}
