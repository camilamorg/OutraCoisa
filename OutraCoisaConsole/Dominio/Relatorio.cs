using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutraCoisaConsole.Dominio
{
    public class Relatorio
    {
        public int PosicaoChegada { get; set; }

        public int Codigo { get; set; }

        public string Piloto { get; set; }

        public int QtdVolta { get; set; }

        public TimeSpan MelhorVolta { get; set; }

        public decimal Velocidade { get; set; }

        public TimeSpan TempoAposVencedor { get; set; }

        public Relatorio(int posicaoChegada, int Codigo, string piloto, int qtdVolta, TimeSpan melhorVolta, decimal velocidade,
            TimeSpan tempoAposVencedor)
        {
            this.PosicaoChegada = posicaoChegada;
            this.Codigo = Codigo;
            this.Piloto = piloto;
            this.QtdVolta = qtdVolta;
            this.MelhorVolta = melhorVolta;
            this.Velocidade = velocidade;
            this.TempoAposVencedor = tempoAposVencedor;
        }
    }
}
