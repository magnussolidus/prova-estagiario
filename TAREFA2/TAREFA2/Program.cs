using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

/*
 * 2 - Crie um programa que reordene o arquivo "mapa.csv" pela coluna "População no último censo" do arquivo, usando bubblesort, e grave uma cópia do arquivo alterado.
 */
namespace TAREFA2
{
    struct Censo
    {
        public string cidade;
        public int população;
    }

    class Program
    {
        const string ARQUIVO = "mapa.csv";
        const string CAMINHO = "..\\..\\..\\..\\";
        const char SEPARADOR = ';';
        const string RESULTADO = "tarefa2.csv";

        private static string _cabeçalho;

        static void Main(string[] args)
        {
            FileStream fonte = LerArquivo(CAMINHO + ARQUIVO);
            Censo[] dados = ColetaDados(fonte);
            ProcessaDados(dados);

            Console.WriteLine("Arquivo 'tarefa2.csv' gerado com sucesso!");
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

        static void SetCabeçalho(string valor)
        {
            _cabeçalho = valor;
        }

        static string GetCabeçalho()
        {
            return _cabeçalho;
        }

        static Censo[] ColetaDados(FileStream arquivo)
        {
            // coleta dos dados

            StreamReader buffer = new StreamReader(arquivo);
            List<Censo> dados = new List<Censo>();
            string linha;

            SetCabeçalho(buffer.ReadLine());

            while ((linha = buffer.ReadLine()) != null)
            {
                var valores = linha.Split(SEPARADOR);
                Censo c = new Censo();
                
                c.cidade = valores[0];
                c.população = int.Parse(valores[1]);

                dados.Add(c);
            }

            FechaArquivo(arquivo);

            return dados.ToArray();
        }

        static void ProcessaDados(Censo[] alvo)
        {
            // processamento dos dados
            int tamanho = alvo.Length;
            Censo aux;
            bool trocar = true;
            int prox;
            int count = 0;

            for(int i=1; (i<=tamanho-1) && trocar; i++) // 
            {
                trocar = false;
                for(int j=0; j<tamanho-1; j++)
                {
                    prox = j+1;
                    if(alvo[j].população > alvo[prox].população)
                    {
                        ++count;
                        aux = alvo[prox];
                        alvo[prox] = alvo[j];
                        alvo[j] = aux;
                        trocar = true;
                    }
                }
            }
            
            // escrita dos dados

            StreamWriter escritor = new StreamWriter(CAMINHO + RESULTADO, false, Encoding.Default);
            string linha;
            
            escritor.WriteLine(_cabeçalho);

            for (int i=0; i<alvo.Length; i++)
            {
                linha = alvo[i].cidade + SEPARADOR + " " + alvo[i].população;
                escritor.WriteLine(linha);
            }

            escritor.Close();
        }
    }
}
