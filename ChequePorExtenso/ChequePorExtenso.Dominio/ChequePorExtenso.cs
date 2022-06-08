using System;
using System.Collections.Generic;

namespace Cheque.Dominio
{
    public class ChequePorExtenso
    {
        private static readonly Dictionary<int, string> numeros = new Dictionary<int, string>()
        {
            {1, "um"},
            {2, "dois"},
            {3, "três"},
            {4, "quatro"},
            {5, "cinco"},
            {6, "seis"},
            {7, "sete"},
            {8, "oito"},
            {9, "nove"},
            {10, "dez"},
            {11, "onze"},
            {12, "doze"},
            {13, "treze"},
            {14, "catorze"},
            {15, "quinze"},
            {16, "dezesseis"},
            {17, "dezessete"},
            {18, "dezoito"},
            {19, "dezenove"},
            {20, "vinte"},
            {30, "trinta"},
            {40, "quarenta"},
            {50, "cinquenta"},
            {60, "sessenta"},
            {70, "setenta"},
            {80, "oitenta"},
            {90, "noventa"},
            {100, "cento"},
            {200, "duzentos"},
            {300, "trezentos"},
            {400, "quatrocentos"},
            {500, "quinhentos"},
            {600, "seiscentos"},
            {700, "setecentos"},
            {800, "oitocentos"},
            {900, "novecentos"}
        };

        public string EscreverNumeroPorExtenso(decimal valor)
        {
            int valorInteiro = (int)Math.Truncate(valor);
            int valorCentavos = (int)Math.Truncate((valor - valorInteiro) * 100);

            string moeda = "reais";
            if (valorInteiro == 1)
            {
                moeda = "real";
            }
            else if (valorInteiro < 0)
            {
                moeda = "de real";
            }else if ((valor % 1000000) == 0)
            {
                moeda = "de reais";
            }else if((valor % 1000000000) == 0)
            {
                moeda = "de reais";
            }

            string numeroString = "";
            if (valorInteiro > 0)
                numeroString += EscreverNumero(valorInteiro) + " " + moeda;
            if (valorCentavos > 0)
                numeroString += (numeroString != "" ? " e " : "") + EscreverNumero(valorCentavos) + " centavos";

            return numeroString;
        }

        private string EscreverNumero(int valor)
        {
            var extenso = new List<string>();
            string extensoMilhar = "";
            string extensoMilhao = "";
            string extensoBilhar = "";

            if (valor / 1000000000 > 0)
            {
                int valorBilhao = valor;
                valor %= 1000000000;
                if (valorBilhao > 1000000000)
                    extensoBilhar = EscreverNumero(valorBilhao / 1000000000) + (valor > 0 ? " bilhões " : " bilhões");
                else
                    extensoBilhar = EscreverNumero(valorBilhao / 1000000000) + (valor > 0 ? " bilhão " : " bilhão");
            }

            if (valor / 1000000 > 0)
            {
                int valorMilhao = valor;
                valor %= 1000000;
                if(valorMilhao > 1000000)
                    extensoMilhao = EscreverNumero(valorMilhao / 1000000) + (valor > 0 ? " milhões " : " milhões");
                else
                    extensoMilhao = EscreverNumero(valorMilhao / 1000000) + (valor > 0 ? " milhão " : " milhão");
            }

            if (valor / 1000 > 0)
            {
                int valorMilhar = valor;
                valor %= 1000;
                extensoMilhar = EscreverNumero(valorMilhar / 1000) + (valor > 0 ? " mil " : " mil");
            }

            if (valor / 100 > 0)
            {
                int valorCentena = valor;
                valor %= 100;

                if (valorCentena == 100)
                {
                    extenso.Add("cem");
                }
                else
                {
                    extenso.Add(numeros[valorCentena - valor]);
                }

            }

            if (valor > 20)
            {
                int valorDezena = valor;
                valor %= 10;
                extenso.Add(numeros[valorDezena - valor]);
            }

            if (valor > 0)
                extenso.Add(numeros[valor]);

            return extensoBilhar + extensoMilhao + extensoMilhar + string.Join(" e ", extenso.ToArray());
        }
    }
}
