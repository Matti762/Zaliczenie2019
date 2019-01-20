using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Dane
{
    /// <summary>
    /// Metody do implementacji (raczej) bez wykorzystania LINQ
    /// </summary>
    public class MetodyPomocnicze
    {
        /// <summary>
        /// Sprawdzenie czy dane miejsce w konkretnym seansie nie jest zajęte
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        /// <param name="rzad"></param>
        /// <param name="miejsce"></param>
        /// <returns></returns>
        public bool CzyMoznaKupicBilet(List<Bilet> sprzedaneBilety, Seans seans, int rzad, int miejsce)
        {
            bool odp = false;
            bool miejsc, rzaad, fiiilm, saaala;
            foreach (Bilet b in sprzedaneBilety)
            {
                miejsc = (b.Miejsce == miejsce);
                rzaad = (b.Rzad == rzad);
                fiiilm = (b.Seans.Film == seans.Film);
                saaala = (b.Seans.Sala == seans.Sala);

                if (b.Miejsce == miejsce && b.Rzad == rzad && b.Seans.Film == seans.Film 
                    && b.Seans.Sala == seans.Sala)
                {
                    odp = false;
                    return odp;
                }
                else
                {
                    odp = true;
                }
            }
            return odp;
        }

        /// <summary>
        /// Sprawdzenie czy można projekcja filmu o zadanej godzinie nie nakłada się z już
        /// dodanymi seansami w tej sali.
        /// </summary>
        /// <param name="aktualneSeanse"></param>
        /// <param name="sala"></param>
        /// <param name="film"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CzyMoznaDodacSeans(List<Seans> aktualneSeanse, Sala sala, Film film, DateTime data)
        {
            // np. nie można zagrać filmu "Egzamin" w sali Kameralnej 2019-01-20 o 17:00
            // można natomiast zagrać "Egzamin" w tej sali 2019-01-20 o 14:00
            bool dodanie = false;
            TimeSpan     poczatekFilmu
                        ,koniecFilmu
                        ,poczatekSeansu
                        ,koniecSenansu;
            foreach(Seans s in aktualneSeanse)
            {
                TimeSpan czasSeansu = TimeSpan.FromMinutes(s.Film.CzasTrwania);
                TimeSpan czasFilmu = TimeSpan.FromMinutes(film.CzasTrwania);

                poczatekFilmu = data.TimeOfDay;
                koniecFilmu = (data.TimeOfDay + czasFilmu);
                poczatekSeansu = s.Date.TimeOfDay;
                koniecSenansu = (s.Date.TimeOfDay + czasSeansu);

                if (s.Sala.Nazwa == sala.Nazwa 
                    && s.Date.DayOfYear == data.DayOfYear 
                    && !(poczatekSeansu <= poczatekFilmu && koniecSenansu >= poczatekFilmu)
                    && !(poczatekSeansu <= koniecFilmu && koniecSenansu >= koniecFilmu)
                    )
                {
                    dodanie = true;
                }
                else
                {
                    dodanie = false;
                }
            }

            return dodanie;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprzedaneBilety">wszystkie sprzedane bilety</param>
        /// <param name="seansDoSprawdzenia"></param>
        /// <returns></returns>
        public int LiczbaWolnychMiejscWSali(List<Bilet> sprzedaneBilety, Seans seansDoSprawdzenia)
        {
            // Właściwa odpowiedź: np. na pierwszy seans z listy seansów w klasie SkladDanych są 72 miejsca
            int liczbaMiejscZajetych = 0;
            foreach(Bilet b in sprzedaneBilety)
            {
                if(b.Seans.Film == seansDoSprawdzenia.Film)
                {
                    liczbaMiejscZajetych ++;
                }
            }
            int pojemnoscSali = seansDoSprawdzenia.Sala.LiczbaMiejscWRzedzie * seansDoSprawdzenia.Sala.LiczbaRzedow;
            int iloscDostepnychMiejsc = pojemnoscSali - liczbaMiejscZajetych;

            return iloscDostepnychMiejsc;
        }

        public double CalkowitePrzychodyZBiletow(List<Bilet> sprzedaneBilety)
        {
            double dochod = 0.0;
            foreach(Bilet sprzedane in sprzedaneBilety)
            {
                dochod = dochod + sprzedane.Cena;
            };
            
            // Właściwa odpowiedź: 400.00
            return dochod;
        }
    }
}
