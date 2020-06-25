using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
        
        HttpClient client = new HttpClient();
        private static string _cabeçalho;

        static void Main(string[] args)
        {
            FileStream fonte = LerArquivo(CAMINHO + ARQUIVO);
            ArquivoCEPs[] dados =  ColetaDados(fonte);
            
            try
            {
                Task.WaitAll(ProcessaDados(dados));
                
                Console.WriteLine("Arquivo 'tarefa3.csv' gerado com sucesso!");
                Console.ReadKey();

            }
            catch (AggregateException) { }

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

        static ArquivoCEPs[] ColetaDados(FileStream arquivo)
        {
            // coleta dos dados

            StreamReader buffer = new StreamReader(arquivo);
            List<ArquivoCEPs> dados = new List<ArquivoCEPs>();
            string linha;

            SetCabeçalho(buffer.ReadLine());

            while ((linha = buffer.ReadLine()) != null)
            {
                var valores = linha.Split(SEPARADOR);
                dados.Add(new ArquivoCEPs(valores[0]));
            }

            FechaArquivo(arquivo);
            return dados.ToArray();
        }

        async static Task ProcessaDados(ArquivoCEPs[] dados)
        {
            // processamento dos dados

            Program p = new Program();
            int tamanho = dados.Length;
            string atual;

            for (int i = 0; i < tamanho; i++)
            {
                if(!ArquivoCEPs.IsValid(dados[i].CEP))
                {
                    continue;
                }
                atual = await p.PegaViaCEP(dados[i].CEP);

                dados[i] = new ArquivoCEPs(atual, true);
            }

            // escrita dos dados

            StreamWriter escritor = new StreamWriter(CAMINHO + RESULTADO, false, Encoding.Default);
            string linha;

            escritor.WriteLine(_cabeçalho);

            for (int i = 0; i < dados.Length; i++)
            {
                linha = dados[i].GetCEP() + SEPARADOR 
                    + dados[i].GetLogradouro() + SEPARADOR
                    + dados[i].GetComplemento() + SEPARADOR
                    + dados[i].GetBairro() + SEPARADOR
                    + dados[i].GetLocalidade() + SEPARADOR
                    + dados[i].GetUF() + SEPARADOR
                    + dados[i].GetUnidade() + SEPARADOR
                    + dados[i].GetIBGE() + SEPARADOR
                    + dados[i].GetGIA() + SEPARADOR;

                escritor.WriteLine(linha);
            }

            escritor.Close();

        }

        private async Task<string> PegaViaCEP(string cep)
        {
            return await client.GetStringAsync("http://viacep.com.br/ws/"+cep+"/piped/");
        }

    }
}
