using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using BlazorAppDataSource1.Server.Model;
using BlazorAppDataSource1.Shared;

namespace BlazorAppDataSource1.Server.Business
{
    public class StudentiManager
    {
        private AppSettings appsettings;
        private IWebHostEnvironment _server;
        private IMemoryCache _memorycache;
        private List<Studenti> studenti;

        public StudentiManager(IOptions<AppSettings> options, IWebHostEnvironment server, IMemoryCache memorycache)
        {
            appsettings = options.Value;
            _server = server;
            _memorycache = memorycache;
        }

        public ResultData<StudentiViewModel> GetStudentiByQuery(StudentiSearch search, string type)
        {
            studenti = EnsureCreated(1000);
            ResultData<StudentiViewModel> result = new ResultData<StudentiViewModel>();

            IEnumerable<Studenti> list = studenti.AsEnumerable<Studenti>();
            IQueryable<Studenti> query = Queryable.AsQueryable<Studenti>(list);

            if (String.IsNullOrEmpty(search.Nome) == false)
            {
                query = query.Where(q => q.Nome.ToLower().StartsWith(search.Nome.ToLower()));
            }
            if (String.IsNullOrEmpty(search.Cognome) == false)
            {
                query = query.Where(q => q.Cognome.ToLower().StartsWith(search.Cognome.ToLower()));
            }
            if (String.IsNullOrEmpty(search.Cap) == false)
            {
                query = query.Where(q => q.Cap.ToLower().StartsWith(search.Cap.ToLower()));
            }
            if (String.IsNullOrEmpty(search.Citta) == false)
            {
                query = query.Where(q => q.Citta.ToLower().StartsWith(search.Citta.ToLower()));
            }
            if (String.IsNullOrEmpty(search.Provincia) == false)
            {
                query = query.Where(q => q.Provincia.ToLower().StartsWith(search.Provincia.ToLower()));
            }

            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "id")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Id);
                else query = query.OrderByDescending(q => q.Id);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "nome")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Nome);
                else query = query.OrderByDescending(q => q.Nome);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "cognome")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Cognome);
                else query = query.OrderByDescending(q => q.Cognome);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "cap")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Cap);
                else query = query.OrderByDescending(q => q.Cap);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "indirizzo")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Indirizzo);
                else query = query.OrderByDescending(q => q.Indirizzo);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "citta")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Citta);
                else query = query.OrderByDescending(q => q.Citta);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "provincia")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Provincia);
                else query = query.OrderByDescending(q => q.Provincia);
            }
            if (!String.IsNullOrEmpty(search.OrderbyColumn) && search.OrderbyColumn.ToLower() == "stato")
            {
                if (search.OrderbyDirection.ToLower() == "asc")
                    query = query.OrderBy(q => q.Stato);
                else query = query.OrderByDescending(q => q.Stato);
            }

            result.Count = query.Count();

            List<Studenti> liststudenti = null;
            // paginazione lato client o lato server
            if (type == "server")
            {
                int index = (search.Page - 1) * search.Pagesize;
                liststudenti = query.Skip(index).Take(search.Pagesize).ToList();
            }
            else
            {
                liststudenti = query.ToList();
            }           

            foreach (Studenti item1 in liststudenti)
            {
                StudentiViewModel item2 = new StudentiViewModel()
                {
                    Id = item1.Id,
                    Cognome = item1.Cognome,
                    Nome = item1.Nome,
                    Indirizzo = item1.Indirizzo,
                    Cap = item1.Cap,
                    Citta = item1.Citta,
                    Provincia = item1.Provincia,
                    Stato = item1.Stato,
                };
                result.Items.Add(item2);
            }

            return result;
        }

        public void InsertStudente(StudentiViewModel studente1)
        {
            studenti = EnsureCreated(1000);

            int id = studenti.OrderBy(x => x.Id).Last().Id;            

            Studenti studente2 = new Studenti();
            studente2.Id = id = id + 1; ;
            studente2.Nome = studente1.Cognome;
            studente2.Cognome = studente1.Cognome;
            studente2.Indirizzo = studente1.Indirizzo;
            studente2.Cap = studente1.Cap;
            studente2.Citta = studente1.Citta;
            studente2.Provincia = studente1.Provincia;
            studente2.Stato = studente1.Stato;
            studenti.Add(studente2);
        }

        public void UpdateStudente(StudentiViewModel studente1)
        {
            studenti = EnsureCreated(1000);

            int id = studente1.Id;
            Studenti studente2 = studenti.Where(x => x.Id == id).Single();

            studente2.Nome = studente1.Cognome;
            studente2.Cognome = studente1.Cognome;
            studente2.Indirizzo = studente1.Indirizzo;
            studente2.Cap = studente1.Cap;
            studente2.Citta = studente1.Citta;
            studente2.Provincia = studente1.Provincia;
            studente2.Stato = studente1.Stato;
        }

        public void DeleteStudente(int id)
        {
            studenti = EnsureCreated(1000);

            Studenti studente2 = studenti.Where(x => x.Id == id).Single();
            studenti.Remove(studente2);
        }

        // ----------------------------------------------------------------------------------

        private List<Studenti> EnsureCreated(int limit)
        {
            string cachekey = "liststudenti";
            if (_memorycache.TryGetValue(cachekey, out List<Studenti> cache) == true)
            {
                return cache;
            }           

            string path = _server.ContentRootPath;
            string filename = $"{path}\\Files\\studenti.csv";
            string[] lines = System.IO.File.ReadAllLines(filename);

            int index = 1;
            cache = new List<Studenti>();
            foreach (string line in lines.Take(limit))
            {
                string[] fields = line.Split(',');
                Studenti studente = new Studenti()
                {
                    Id = index,
                    Nome = fields[0],
                    Cognome = fields[1],
                    Indirizzo = fields[2],
                    Cap = fields[3],
                    Citta = fields[4],
                    Provincia = fields[5],
                    Stato = fields[6],
                };
                cache.Add(studente);
                index++;
            }

            _memorycache.Set(cachekey, cache, new MemoryCacheEntryOptions().SetAbsoluteExpiration(
                        TimeSpan.FromMinutes(30)).SetPriority(CacheItemPriority.High));
            return cache;
        }
    }
}
