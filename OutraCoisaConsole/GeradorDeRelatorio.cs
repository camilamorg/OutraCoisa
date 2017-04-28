using OutraCoisaConsole.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutraCoisaConsole
{
    public class GeradorDeRelatorio
    {
        public TimeSpan MelhorVoltaCorrida(List<Corrida> listaCorrida)
        {
            TimeSpan melhorvolta = listaCorrida[0].Tempo;
            for (int i = 1; i < listaCorrida.Count; i++)
            {
                if (listaCorrida[i].Tempo.CompareTo(melhorvolta) < 0)
                {
                    melhorvolta = listaCorrida[i].Tempo;
                }
            }

            return melhorvolta;
        }

        public List<Relatorio> MontaRelatorio(List<Corrida> listaCorrida)
        {
            List<Relatorio> relatorio = new List<Relatorio>();
            int posicao = 1;

            for (int i = 0; i < listaCorrida.Count; i++)
            {
                int codigo = listaCorrida[i].Codigo;
                if (!relatorio.Any(r => r.Codigo == codigo))
                {
                    int qtdVolta = VerificaQtdVolta(listaCorrida, codigo);
                    TimeSpan melhorVolta = VerificaMelhorVoltaPiloto(listaCorrida, codigo);
                    Decimal velocidadeMedia = VerificaVelocidadeMedia(listaCorrida, codigo, qtdVolta);
                    TimeSpan tempo = TempoAposVencedor(listaCorrida, codigo);

                    Relatorio r = new Relatorio(posicao, listaCorrida[i].Codigo, listaCorrida[i].Piloto, qtdVolta,
                        melhorVolta, velocidadeMedia, tempo);
                    relatorio.Add(r);
                }
            }

            for (int i = 0; i < relatorio.Count; i++)
            {
                for (int j = 0; j < relatorio.Count; j++)
                {
                    if (relatorio[i].TempoAposVencedor.CompareTo(relatorio[j].TempoAposVencedor) < 0)
                    {
                        Relatorio aux = relatorio[i];
                        relatorio[i] = relatorio[j];
                        relatorio[j] = aux;
                    }
                }
            }

            for (int i = 0; i < relatorio.Count; i++)
            {
                relatorio[i].PosicaoChegada = i + 1;
            }

            return relatorio;
        }

        private int VerificaQtdVolta(List<Corrida> listaCorrida, int codigo)
        {
            for (int i = listaCorrida.Count - 1; i >= 0; i--)
            {
                if (listaCorrida[i].Codigo == codigo)
                {
                    return listaCorrida[i].Volta;
                }
            }

            return 0;
        }

        private static TimeSpan VerificaMelhorVoltaPiloto(List<Corrida> listaCorrida, int codigo)
        {
            TimeSpan melhorVolta = new TimeSpan();
            melhorVolta = TimeSpan.MaxValue;
            for (int i = listaCorrida.Count - 1; i >= 0; i--)
            {
                if (listaCorrida[i].Codigo == codigo)
                {
                    if (listaCorrida[i].Tempo.CompareTo(melhorVolta) < 0)
                    {
                        melhorVolta = listaCorrida[i].Tempo;
                    }
                }
            }

            return melhorVolta;
        }


        private Decimal VerificaVelocidadeMedia(List<Corrida> listaCorrida, int codigo, int qtdVolta)
        {
            Decimal velocidade = 0;

            for (int i = 0; i < listaCorrida.Count; i++)
            {
                if (listaCorrida[i].Codigo == codigo)
                {
                    velocidade += listaCorrida[i].Velocidade;

                }
            }

            velocidade = velocidade / qtdVolta;

            return velocidade;
        }

        private TimeSpan TempoAposVencedor(List<Corrida> listaCorrida, int codigo)
        {
            TimeSpan horaVencedor = VerificaHoraVencedor(listaCorrida);

            for (int i = listaCorrida.Count - 1; i >= 0; i--)
            {
                if (listaCorrida[i].Codigo == codigo)
                {
                    TimeSpan tempoApos = listaCorrida[i].Hora - horaVencedor;

                    return tempoApos;
                }
            }

            return new TimeSpan();
        }

        private TimeSpan VerificaHoraVencedor(List<Corrida> listaCorrida)
        {
            for (int i = 0; i < listaCorrida.Count; i++)
            {
                if (listaCorrida[i].Volta == 4)
                {
                    return listaCorrida[i].Hora;
                }
            }

            return new TimeSpan(0, 0, 0, 0, 0);
        }
    }
}
