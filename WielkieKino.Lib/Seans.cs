using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WielkieKino.Lib
{
    public class Seans
    {
        public DateTime Date { get; set; }
        public Sala Sala { get; set; }
        public Film Film { get; set; }
    }
}
