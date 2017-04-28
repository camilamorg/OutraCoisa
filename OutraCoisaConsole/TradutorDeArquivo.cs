using OutraCoisaConsole.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutraCoisaConsole
{
    public class TradutorDeArquivo
    {
        private string _filePath;

        public void SetFilePath(string path)
        {
            _filePath = path;
        }

        public List<Corrida> ReadFile()
        {
            var listaCorrida = new List<Corrida>();
            string[] linhas = File.ReadAllLines(_filePath);

            for (int i = 1; i < linhas.Length; i++)
            {
                string[] auxiliar = linhas[i].Split('\t');

                TimeSpan hora = new TimeSpan(0, Convert.ToInt32(auxiliar[0].Substring(0, 2)),
                    Convert.ToInt32(auxiliar[0].Substring(3, 2)), Convert.ToInt32(auxiliar[0].Substring(6, 2)),
                    Convert.ToInt32(auxiliar[0].Substring(9, 3)));
                TimeSpan volta = new TimeSpan(0, 0, Convert.ToInt32(auxiliar[3].Substring(0, 1)),
                    Convert.ToInt32(auxiliar[3].Substring(2, 2)), Convert.ToInt32(auxiliar[3].Substring(5, 3)));

                Corrida c = new Corrida(hora, Int32.Parse(auxiliar[1].Substring(0, 3)), auxiliar[1].Substring(6, auxiliar[1].Length - 6), Convert.ToInt32(auxiliar[2]), volta,
                    Convert.ToDecimal(auxiliar[4]));

                listaCorrida.Add(c);
            }

            return listaCorrida;
        }
    }
}
