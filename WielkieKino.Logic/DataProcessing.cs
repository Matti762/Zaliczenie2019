using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Logic
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        public List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
            List<string> wynik;
            wynik = (from Film f in filmy
                     where f.Gatunek == gatunek
                     select f.Tytul).ToList();
            return wynik;
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public int PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            // Właściwa odpowiedź: 400
            double wynikDouble = (from Bilet b in bilety
                                  select b.Cena).Sum();
            int wynik = (int)wynikDouble;

            return wynik;
        }

        public List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
            List<Film> filmyZDnia = (from Film f in seanse
                                     where f.Tytul == (from Seans s in seanse
                                                       //where s.Film.Tytul = f.Tytul
                                                   select s.Film.Tytul).First()
                                    select f).ToList();
                                    // (from Film f in seanse
                                    // where f.Tytul  (from Seans s in seanse
                                    //                   //where s.Film.Tytul = f.Tytul
                                    //                   select s.Film.Tytul)
                                    // select f).ToList();
                
            return filmyZDnia;
        }

        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public string NajpopularniejszyGatunek(List<Film> filmy)
        {
            string pop = (from Film f in filmy
                          orderby f.Gatunek.Count() descending
                          select f.Gatunek).First();
            return pop;
        }

        public List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)
            List<Sala> saleSort = (from Sala s in sale
                                   orderby s.LiczbaMiejscWRzedzie * s.LiczbaRzedow descending
                                   select s).ToList();
            return saleSort;
        }

        public Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        {
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 
            //Sala oblozonaSala 
            ///= 
            //(from Sala sal in seanse
            //    //where sal.Nazwa == (from Seans s in seanse
            //    //                    where s.Date == data
            //    //                    select s.Sala.ToString()).First()
            //where sal.Nazwa == (from Seans s in seanse
            //                    where s.Date == data
            //                    select s.Sala.ToString()).First() 
            //                    orderby (from Seans s in seanse
            //         where s.Date == data
            //         select s.Sala).Count() descending
            //select sal  
            //)

            // (from Seans s in seanse
            //   where s.Date == data 
            //  select s.Sala).Count();

            return null; //oblozonaSala;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            // Właściwa odpowiedź: "Konan Destylator"
            return null;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {
            return null;
        }


        //WielkieKinoInitializer.Seed()



    }

    //public class CreateDatabaseIfNotExists<WielkieKinoInitializer> :
    //    IDatabaseInitializer<WielkieKinoInitializer> where WielkieKinoInitializer : DbContext
    //{

    //}
    //DropCreateDatabaseIfModelChanges
    public class WielkieKinoInitializer : CreateDatabaseIfNotExists<ModelDataProcessing>
    {

        protected override void Seed(ModelDataProcessing context)
        {
            List<Bilet> bilety = new List<Bilet>();
            bilety.ForEach(b => context.Bilety.Add(b));
            context.SaveChanges();
            List<Film> filmy = new List<Film>();
            filmy.ForEach(f => context.Filmy.Add(f));
            context.SaveChanges();
            List<Sala> sale = new List<Sala>();
            sale.ForEach(s => context.Sale.Add(s));
            context.SaveChanges();
            List<Seans> seanse = new List<Seans>();
            seanse.ForEach(se => context.Seanse.Add(se));
            context.SaveChanges();
        }

            }


    public class ModelDataProcessing : DbContext
    {
        public ModelDataProcessing(): base("ModelDataProcessing")
        {

        }
        public DbSet<Film>  Filmy   { get; set; }
        public DbSet<Bilet> Bilety  { get; set; }
        public DbSet<Sala>  Sale    { get; set; }
        public DbSet<Seans> Seanse  { get; set; }
    }

}
