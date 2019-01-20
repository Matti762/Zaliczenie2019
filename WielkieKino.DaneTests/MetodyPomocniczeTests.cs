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
            Assert.Fail();
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            Assert.Fail();
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