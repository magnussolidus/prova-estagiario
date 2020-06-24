using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Preencha o endereco no arquivo "mapa.csv" lendo a coluna de cep e buscando na API viacep (https://viacep.com.br/) o endereço equivalente ao CEP e grave uma cópia do arquivo preenchido.
 * */
namespace TAREFA3
{
    class Program
    {
        const string ARQUIVO = "CEPs.csv"; // acredito que há um erro no enunciado da tarefa visto que o arquivo mapa.csv não contém coluna referente a CEP, assim utilizei o arquivo CEPs.csv
        const string CAMINHO = "..\\..\\..\\..\\";
        const char SEPARADOR = ';';
        const string RESULTADO = "tarefa3.csv";

        private static string _cabeçalho;

        static void Main(string[] args)
        {
        }
    }
}
