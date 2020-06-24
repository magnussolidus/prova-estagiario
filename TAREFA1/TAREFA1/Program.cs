using System;
using System.Collections.Generic;
using System.Text;
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
        const string CAMINHO = "..\\..\\..\\..\\";
        const char SEPARADOR = ';';
      

        static void Main(string[] args)
        {
            FileStream fonte = LerArquivo(CAMINHO+ARQUIVO);
            ProcessaDados(fonte);
            Console.WriteLine("Arquivo 'tarefa1.csv' gerado com sucesso!");
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

        static void FechaArquivo(FileStream alvo)
        {
            alvo.Close();
        }

        static void ProcessaDados(FileStream arquivo)
        {
            // coleta dos dados

            StreamReader buffer = new StreamReader(arquivo);
            
            string linha;
            string cabeçalho = buffer.ReadLine();

            List<string> cidade = new List<string>();
            List<int> população = new List<int>();

            while((linha = buffer.ReadLine()) != null)
            {
                var valores = linha.Split(SEPARADOR);

                cidade.Add(valores[0]);
                população.Add(int.Parse(valores[1]));
            }

            FechaArquivo(arquivo);

            // processamento dos dados

            List<int> resultado = new List<int>();

            foreach (int pop in população)
            {
                resultado.Add(pop * MULTIPLICADOR);
            }

            // escrita dos dados
            
            StreamWriter escritor = new StreamWriter(CAMINHO + "tarefa1.csv", false, Encoding.UTF8);
            escritor.WriteLine(cabeçalho);

            for(int i=0; i<cidade.Count; i++)
            {
                linha = cidade.ToArray()[i] + SEPARADOR + " " + resultado.ToArray()[i];
                escritor.WriteLine(linha);
            }

            escritor.Close();
        }
    }
}
