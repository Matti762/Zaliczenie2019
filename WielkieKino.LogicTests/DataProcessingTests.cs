using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;
using WielkieKino.Dane;

namespace WielkieKino.Logic.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        [TestMethod()]
        public void WybierzFilmyZGatunkuTest()
        {
            List<Film> filmy = SkladDanych.Filmy;

            DataProcessing dp = new DataProcessing();

            var filmWybrany = new List<string>() { "Konan Destylator" };
            List<string> listaFilmow = dp.WybierzFilmyZGatunku(filmy, "Fantasy").ToList();
            CollectionAssert.AreEqual(filmWybrany, listaFilmow);
        }

        [TestMethod()]
        public void PodajCalkowiteWplywyZBiletowTest()
        {
            List<Bilet> bilety = SkladDanych.Bilety;

            DataProcessing dp = new DataProcessing();

            Assert.IsTrue(dp.PodajCalkowiteWplywyZBiletow(bilety) == 400);
        }

        [TestMethod()]
        public void NajpopularniejszyGatunekTest()
        {
            List<Film> filmy = SkladDanych.Filmy;

            DataProcessing dp = new DataProcessing();

            Assert.AreEqual(dp.NajpopularniejszyGatunek(filmy), "Obyczajowy");
        }
    }
}