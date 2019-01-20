using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Dane.Tests
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            MetodyPomocnicze mp = new MetodyPomocnicze();
            List<Bilet> bilety = SkladDanych.Bilety;
            Seans seans = SkladDanych.Seanse[0];


            Assert.IsTrue (mp.CzyMoznaKupicBilet(bilety, seans, 1, 1));
            Assert.IsFalse(mp.CzyMoznaKupicBilet(bilety, seans, 1, 2));
            Assert.IsFalse(mp.CzyMoznaKupicBilet(bilety, seans, 5, 5));

        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            MetodyPomocnicze mp = new MetodyPomocnicze();

            List<Seans> seanse = SkladDanych.Seanse;
            //Sala kameralna - egzamin
            Sala sala1 = SkladDanych.Sale[2];
            Film film1 = SkladDanych.Filmy[2];
            DateTime dateTime1 = new DateTime(2019, 01, 20, 14, 00, 00);
            DateTime dateTime2 = new DateTime(2019, 01, 20, 17, 00, 00);

            DateTime dateTime3 = new DateTime(2019, 01, 20, 17, 30, 00);
            DateTime dateTime4 = new DateTime(2019, 01, 20, 20, 30, 00);

            Assert.IsTrue(mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime1));
            Assert.IsFalse(mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime2));
            Assert.IsFalse(mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime3));
            Assert.IsTrue(mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime4));

        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            List<Bilet> bilety = SkladDanych.Bilety;
            Seans seans = SkladDanych.Seanse[0];
            MetodyPomocnicze mp = new MetodyPomocnicze();

            Assert.AreEqual(mp.LiczbaWolnychMiejscWSali(bilety, seans), 72);
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            List<Bilet> bilety = SkladDanych.Bilety;

            MetodyPomocnicze mp = new MetodyPomocnicze();

            Assert.IsTrue(mp.CalkowitePrzychodyZBiletow(bilety) == 400);

        }
    }
}