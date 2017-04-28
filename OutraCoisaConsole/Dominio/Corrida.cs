using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutraCoisaConsole.Dominio
{
    public class Corrida
    {
        public TimeSpan Hora { get; set; }

        public int Codigo { get; set; }

        public string Piloto { get; set; }

        public int Volta { get; set; }

        public TimeSpan Tempo { get; set; }

        public decimal Velocidade { get; set; }

        public Corrida(TimeSpan hora, int codigo, string piloto, int volta, TimeSpan tempo, decimal velocidade)
        {
            this.Hora = hora;
            this.Codigo = codigo;
            this.Piloto = piloto;
            this.Volta = volta;
            this.Tempo = tempo;
            this.Velocidade = velocidade;
        }
    }
}
