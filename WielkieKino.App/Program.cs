using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Dane;
using WielkieKino.Lib;
using WielkieKino.Logic;
using System.Data.Entity;

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
            MetodyPomocnicze mp = new MetodyPomocnicze();
            int miejsce, rzad;
            miejsce = seans.Sala.LiczbaMiejscWRzedzie;
            rzad = seans.Sala.LiczbaRzedow;
            for(int i = 1; i <= rzad; i++)
            {
                for(int j = 1; j <= miejsce; j++)
                {
                    if (mp.CzyMoznaKupicBilet(sprzedaneBilety, seans, i, j))
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write("o");
                    }
                }
                Console.WriteLine();
            }
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

            //Inicjalizator EF
            //using (WielkieKino.Logic.ModelDataProcessing context = new ModelDataProcessing())
            //{
            //    List<Bilet> bilety = SkladDanych.Bilety;
            //    bilety.ForEach(b => context.Bilety.Add(b));
            //    context.SaveChanges();
            //    List<Film> filmy = SkladDanych.Filmy;
            //    filmy.ForEach(f => context.Filmy.Add(f));
            //    context.SaveChanges();
            //    List<Sala> sale = SkladDanych.Sale;
            //    sale.ForEach(s => context.Sale.Add(s));
            //    context.SaveChanges();
            //    List<Seans> seanse = SkladDanych.Seanse;
            //    seanse.ForEach(se => context.Seanse.Add(se));
            //    context.SaveChanges();
            //}

                //init.

                WyswietlPodgladSali(Dane.SkladDanych.Bilety, Dane.SkladDanych.Seanse[0]);
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
            Console.ReadKey();
        }
    }
}
