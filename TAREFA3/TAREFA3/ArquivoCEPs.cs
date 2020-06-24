using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREFA3
{
    class ArquivoCEPs
    {
        public string CEP;
        public string Logradouro;
        public string Complemento;
        public string Bairro;
        public string Localidade;
        public string UF;
        public string Unidade;
        public string IBGE;
        public string GIA;

        public ArquivoCEPs(string novoCep)
        {
            this.CEP = novoCep;
        }

        public void SetCEP(string valor)
        {
            CEP = valor;
        }
        public string GetCEP()
        {
            return CEP;
        }
        public void SetLogradouro(string valor)
        {
            Logradouro = valor;
        }
        public string GetLogradouro()
        {
            return Logradouro;
        }
        public void SetComplemento(string valor)
        {
            Complemento = valor;
        }
        public string GetComplemento()
        {
            return Complemento;
        }
        public void SetBairro(string valor)
        {
            Bairro = valor;
        }
        public string GetBairro()
        {
            return Bairro;
        }
        public void SetLocalidade(string valor)
        {
            Localidade = valor;
        }
        public string GetLocalidade()
        {
            return Localidade;
        }
        public void SetUF(string valor)
        {
            UF = valor;
        }
        public string GetUF()
        {
            return UF;
        }
        public void SetUnidade(string valor)
        {
            Unidade = valor;
        }
        public string GetUnidade()
        {
            return Unidade;
        }
        public void SetIBGE(string valor)
        {
            IBGE = valor;
        }
        public string GetIBGE()
        {
            return IBGE;
        }
        public void SetGIA(string valor)
        {
            GIA = valor;
        }
        public string GetGIA()
        {
            return GIA;
        }
    }
}
