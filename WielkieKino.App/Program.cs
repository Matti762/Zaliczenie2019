using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Dane;
using WielkieKino.Lib;

namespace WielkieKino.App
{
    public class Program
    {
        /// <summary>
        /// Na podstawie danych seansu i sprzedanych biletów należy wyświetlić "podgląd"
        /// sali w ten sposób, że: każdy rząd to jedna linia tekstu, znaków w linii
        /// ma być tyle ile miejsc w rzędzie, miejsca zajęte są inaczej oznaczone niż
        /// miejsca wolne.
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        private static void WyswietlPodgladSali(List<Bilet> sprzedaneBilety, Seans seans)
        {


        }

        /// <summary>
        /// Wyświetlony powinien być tytuł filmu, godzina rozpoczęcia, czas trwania
        /// i nazwa sali.
        /// </summary>
        /// <param name="seanse"></param>
        /// <param name="data"></param>
        private static void WyswietlFilmyOGodzinie(List<Seans> seanse, DateTime data)
        {
            //Wskazówka: Do obliczenia czy parametr data "wpada" w film można wykorzystać
            //metodę AddMinutes wykonanej na czasie rozpoczęcia seansu.
        }

        public static void Main(string[] args)
        {
            //WyswietlPodgladSali(Dane.SkladDanych.Bilety, Dane.SkladDanych.Seanse[0]);
            /* Przykładowo:
            ----------
            ----------
            ----------
            ----------
            ----ooo---
            ----ooo---
            -----oo---
            ----------
            */

            //MetodyPomocnicze mp = new MetodyPomocnicze();
            //List<Bilet> bilety = SkladDanych.Bilety;
            //Seans seans = SkladDanych.Seanse[0];
            //bool a, b;
            //a = mp.CzyMoznaKupicBilet(bilety, seans, 1, 1);
            //b = mp.CzyMoznaKupicBilet(bilety, seans, 5, 5);
            //Console.WriteLine($"Pierwsze {a} drugie {b}");
            //Console.ReadKey();

            //List<Seans> seanse = SkladDanych.Seanse;
            ////Sala kameralna - egzamin
            //Sala sala1 = SkladDanych.Sale[2];
            //Film film1 = SkladDanych.Filmy[2];
            //DateTime dateTime1 = new DateTime(2019, 01, 20, 14, 00, 00); 
            //DateTime dateTime2 = new DateTime(2019, 01, 20, 17, 00, 00);
            //DateTime dateTime3 = new DateTime(2019, 01, 20, 16, 00, 00);
            //DateTime dateTime4 = new DateTime(2019, 01, 20, 17, 30, 00);



            //bool p, d,t,c;
            //p = mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime1);//true
            //d = mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime2);//false
            //t = mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime2);//false
            //c = mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime2);//false

            //Console.WriteLine($"Pierwsze {p} drugie {d} trzecie{t} czwarte{c}");
            //Console.ReadKey();
            //Assert.IsTrue(mp.CzyMoznaDodacSeans(seanse, sala1, film1, dateTime1));



        }
    }
}
