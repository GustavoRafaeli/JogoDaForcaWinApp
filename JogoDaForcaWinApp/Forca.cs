using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForcaWinApp
{
    public class Forca
    {
        private string[] palavras = { "ABACAXI", "BANANA", "MELANCIA", "LARANJA", "MORANGO", "ABACATE", "ACEROLA" };
        public string palavraRandom;
        public string palavraCriptografada;
        public List<char> LetrasEscolhidas;

        public Forca()
        {
            GerarPalavra();
            LetrasEscolhidas = new List<char>();
        }

        public void GerarPalavra()
        {
            Random random = new Random();
            palavraRandom = palavras[random.Next(palavras.Length)];
            palavraCriptografada = new string('_', palavraRandom.Length);
        }
        public void ResetPalavraCriptografada()
        {
            palavraCriptografada = "";
            for (int i = 0; i < palavraRandom.Length; i++)
            {
                palavraCriptografada += "_";
            }
        }
    }
}

