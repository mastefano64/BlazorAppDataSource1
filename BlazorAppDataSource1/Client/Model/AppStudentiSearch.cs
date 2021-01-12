using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSourceRazorLibrary1;

namespace BlazorAppDataSource1.Client.Model
{
    public class AppStudentiSearch
    {
        public AppStudentiSearch()
        {

        }

        [FieldSearchable]
        public string Nome { get; set; }

        [FieldSearchable]
        public string Cognome { get; set; }       

        [FieldSearchable]
        public string Cap { get; set; }

        [FieldSearchable]
        public string Citta { get; set; }

        [FieldSearchable]
        public string Provincia { get; set; }

        public AppStudentiSearch Clone()
        {
            AppStudentiSearch item2 = new AppStudentiSearch();
            item2.Nome = Nome;
            item2.Cognome = Cognome;
            item2.Cap = Cap;
            item2.Citta = Citta;
            item2.Provincia = Provincia;
            return item2;
        }
    }
}
