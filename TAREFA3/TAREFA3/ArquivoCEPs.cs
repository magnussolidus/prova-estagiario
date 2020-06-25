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
            this.CEP = AdjustCep(novoCep);
        }

        public ArquivoCEPs(string viacep, bool completo)
        {
            if(!completo)
            {
                return;
            }

            string[] dados = viacep.Split('|');
            this.CEP = AdjustCep(dados[0]);
            this.Logradouro = dados[1].Remove(0, 11);
            this.Complemento = dados[2].Remove(0, 12);
            this.Bairro = dados[3].Remove(0, 7);
            this.Localidade = dados[4].Remove(0, 11);
            this.UF = dados[5].Remove(0, 3);
            this.Unidade = dados[6].Remove(0, 8);
            this.IBGE = dados[7].Remove(0, 5);
            this.GIA = dados[8].Remove(0, 4);
        }

        private string AdjustCep(string alvo)
        {
            bool removeu = false;

            for(int i=0; i<alvo.Length; i++)
            {
                if(removeu)
                {
                    --i;
                    removeu = false;
                }
                switch(alvo[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        continue;
                    default:
                        alvo = alvo.Remove(i, 1);
                        removeu = true;
                        break;
                        
                }
            }

            if(alvo.Length < 8)
            {
                alvo = "ERRO! VERIFIQUE O CEP!";
            }

            return alvo;
        }

        public static bool IsValid(string CEP)
        {
            if(CEP == null || CEP.Contains("ERRO! VERIFIQUE O CEP!"))
            {
                return false;
            }
            return true;
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
