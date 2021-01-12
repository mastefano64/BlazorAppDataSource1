using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppDataSource1.Server.Model
{
    public class StudentiSearch : BaseSearch
    {
        public string Cognome { get; set; }

        public string Nome { get; set; }

        public string Cap { get; set; }

        public string Citta { get; set; }

        public string Provincia { get; set; }
    }
}
