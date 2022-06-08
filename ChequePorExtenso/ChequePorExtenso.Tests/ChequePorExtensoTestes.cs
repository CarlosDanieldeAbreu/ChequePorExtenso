using Cheque.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cheque.Tests
{
    [TestClass]
    public class ChequePorExtensoTestes
    {
        private ChequePorExtenso cheque;

        public ChequePorExtensoTestes()
        {
            cheque = new ChequePorExtenso();
        }

        [TestMethod]
        [DataRow("um real", 1)]
        [DataRow("quatro reais", 4)]
        [DataRow("oito reais", 8)]
        [DataRow("seis reais", 6)]
        public void Escrever_Unidades_por_Extenso(string escrita, int resultadoEsperado)
        {
            //cenário - arrange
            string numeroRomano = escrita;

            //ação - action 
            var resultado = cheque.EscreverNumeroPorExtenso(resultadoEsperado);

            //verificação - assert
            Assert.AreEqual(numeroRomano, resultado);
        }

        [TestMethod]
        [DataRow("onze reais", 11)]
        [DataRow("catorze reais", 14)]
        [DataRow("dezoito reais", 18)]
        [DataRow("dezesseis reais", 16)]
        public void Escrever_Dezenas_por_Extenso(string escrita, int resultadoEsperado)
        {
            //cenário - arrange
            string numeroRomano = escrita;

            //ação - action 
            var resultado = cheque.EscreverNumeroPorExtenso(resultadoEsperado);

            //verificação - assert
            Assert.AreEqual(numeroRomano, resultado);
        }

        [TestMethod]
        [DataRow("cento e onze reais", 111)]
        [DataRow("cento e quarenta e um reais", 141)]
        [DataRow("cento e oitenta e um reais", 181)]
        [DataRow("cento e sessenta e um reais", 161)]
        public void Escrever_Centenas_por_Extenso(string escrita, int resultadoEsperado)
        {
            //cenário - arrange
            string numeroRomano = escrita;

            //ação - action 
            var resultado = cheque.EscreverNumeroPorExtenso(resultadoEsperado);

            //verificação - assert
            Assert.AreEqual(numeroRomano, resultado);
        }

        [TestMethod]
        [DataRow("um mil reais", 1000)]
        [DataRow("três mil reais", 3000)]
        [DataRow("um mil cento e onze reais", 1111)]
        [DataRow("um mil quatrocentos e onze reais", 1411)]
        [DataRow("dois mil oitocentos e quinze reais", 2815)]
        [DataRow("nove mil seiscentos e trinta e cinco reais", 9635)]
        public void Escrever_Milhares_por_Extenso(string escrita, int resultadoEsperado)
        {
            //cenário - arrange
            string numeroRomano = escrita;

            //ação - action 
            var resultado = cheque.EscreverNumeroPorExtenso(resultadoEsperado);

            //verificação - assert
            Assert.AreEqual(numeroRomano, resultado);
        }

        [TestMethod]
        [DataRow("um milhão de reais", 1000000)]
        [DataRow("quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", 425961637)]
        [DataRow("oito bilhões quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", 8425961637)]
        public void Escrever_Milhares_e_Bilhoes_por_Extenso(string escrita, decimal resultadoEsperado)
        {
            //cenário - arrange
            string numeroRomano = escrita;

            //ação - action 
            var resultado = cheque.EscreverNumeroPorExtenso(resultadoEsperado);

            //verificação - assert
            Assert.AreEqual(numeroRomano, resultado);
        }
    }
}
