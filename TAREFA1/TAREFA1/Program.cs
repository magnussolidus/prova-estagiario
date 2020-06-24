using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * 1 - Crie um programa que multiplique a coluna "População no último censo" do arquivo "mapa.csv" por 2 e grave uma cópia do arquivo alterado.
 * */
namespace TAREFA1
{
    class Program
    {

        const int MULTIPLICADOR = 2;
        const string ARQUIVO = "mapa.csv";
        const string CAMINHO = "..\\..\\..\\..\\" + ARQUIVO;
        const char SEPARADOR = ';';
      

        static void Main(string[] args)
        {
            FileStream fonte = LerArquivo(CAMINHO);              


            Console.WriteLine("Sucesso!");
            Console.ReadKey();

        }

        static FileStream LerArquivo(string fonte)
        {
            try
            {
                FileStream resultado = new FileStream(fonte, FileMode.Open, FileAccess.Read);
                return resultado;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("\nErro ao encontrar o arquivo. Por favor verifique se o caminho e/ou o nome estão corretos.");
                Console.ReadKey();
                return null;
            }
        }

        static void ProcessaDados(FileStream arquivo)
        {
            // coleta dos dados

            StreamReader buffer = new StreamReader(arquivo);
            
            string linha;
            string cabeçalho = buffer.ReadLine();
            int nCols = cabeçalho.Split(SEPARADOR).Length;

            List<string> cidade = new List<string>();
            List<int> população = new List<int>();

            while((linha = buffer.ReadLine()) != null)
            {
                var valores = linha.Split(SEPARADOR);

                cidade.Add(valores[0]);
                população.Add(int.Parse(valores[1]));
            }

            // processamento dos dados



            // escrita dos dados
        }
    }
}
