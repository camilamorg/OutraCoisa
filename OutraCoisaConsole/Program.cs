using OutraCoisaConsole.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace OutraCoisaConsole
{
    class Program
    {
        public  static TradutorDeArquivo Tradutor { get; set; }
        public static GeradorDeRelatorio Gerador { get; set; }
        static void Main(string[] args)
        {
            Tradutor = new TradutorDeArquivo();
            Gerador = new GeradorDeRelatorio();
            List<Corrida> listaCorrida = new List<Corrida>();
            List<Relatorio> relatorio = new List<Relatorio>();

            Tradutor.SetFilePath(ConfigurationManager.AppSettings["FilePath"]);
            try
            {

                listaCorrida = Tradutor.ReadFile();
                TimeSpan melhorVolta = Gerador.MelhorVoltaCorrida(listaCorrida);
                TimeSpan tempoTotal = listaCorrida[listaCorrida.Count - 1].Hora;
                relatorio = Gerador.MontaRelatorio(listaCorrida);

                foreach (var item in relatorio)
                {
                    Console.WriteLine(@"Posicao: {0}",item.PosicaoChegada);
                    Console.WriteLine(@"Codigo: {0}", item.Codigo);
                    Console.WriteLine(@"Piloto: {0}", item.Piloto);
                    Console.WriteLine(@"Quantidade de voltas: {0}", item.QtdVolta);
                    Console.WriteLine(@"Melhor Volta: {0}", item.MelhorVolta);
                    Console.WriteLine(@"Velocidade Media: {0}", item.Velocidade);
                    Console.WriteLine(@"Tempo Apos o Vencedor: {0}", item.TempoAposVencedor);
                    Console.WriteLine();
                }

                Console.WriteLine(@"Tempo total de prova: {0}", tempoTotal);
                Console.WriteLine(@"Melhor volta da corrida: {0}", melhorVolta);
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro ao abrir o arquivo: {0}", e.GetType().Name);
            }

            Console.ReadKey();
        }
    }
}
