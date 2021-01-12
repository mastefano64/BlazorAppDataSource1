using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using BlazorAppDataSource1.Server.Business;
using BlazorAppDataSource1.Shared;
using BlazorAppDataSource1.Server.Helper;
using BlazorAppDataSource1.Server.Model;

namespace BlazorAppDataSource1.Server.Controllers
{
    [ApiController]
   
    public class StudentiController : ControllerBase
    {
        private StudentiManager _sm;

        public StudentiController(StudentiManager sm)
        {
            _sm = sm;
        }

        [HttpGet]
        [Route("Studenti/GetStudentiByQuery1")]  
        public ResultData<StudentiViewModel> GetStudentiByQuery1(string nome, string cognome, string cap, string citta,
                   string provincia, string orderbycolumn, string orderbydirection, int pagesize, int page)
        {
            StudentiSearch search = new StudentiSearch();
            search.Nome = Conv.ToString(nome);
            search.Cognome = Conv.ToString(cognome);
            search.Cap = Conv.ToString(cap);
            search.Citta = Conv.ToString(citta);
            search.Provincia = Conv.ToString(provincia);
            search.OrderbyColumn = orderbycolumn;
            search.OrderbyDirection = orderbydirection;
            search.Pagesize = pagesize;
            search.Page = page;

            ResultData<StudentiViewModel> list = _sm.GetStudentiByQuery(search, "client");

            //Thread.Sleep(3000);

            return list;
        }

        [HttpGet]
        [Route("Studenti/GetStudentiByQuery2")]
        public ResultData<StudentiViewModel> GetStudentiByQuery2(string nome, string cognome, string cap, string citta,
                  string provincia, string orderbycolumn, string orderbydirection, int pagesize, int page)
        {
            StudentiSearch search = new StudentiSearch();
            search.Nome = Conv.ToString(nome);
            search.Cognome = Conv.ToString(cognome);
            search.Cap = Conv.ToString(cap);
            search.Citta = Conv.ToString(citta);
            search.Provincia = Conv.ToString(provincia);
            search.OrderbyColumn = orderbycolumn;
            search.OrderbyDirection = orderbydirection;
            search.Pagesize = pagesize;
            search.Page = page;

            ResultData<StudentiViewModel> list = _sm.GetStudentiByQuery(search, "server");

            //Thread.Sleep(3000);

            return list;
        }

        [HttpPost]
        [Route("Studenti/InsertStudente")]
        public IActionResult InsertStudente(StudentiViewModel studente)
        {
            _sm.InsertStudente(studente);

            return Ok();
        }

        [HttpPost]
        [Route("Studenti/UpdateStudente")]
        public IActionResult UpdateStudente(StudentiViewModel studente)
        {
            _sm.UpdateStudente(studente);

            return Ok();
        }

        [HttpGet]
        [Route("Studenti/DeleteStudente")]
        public string DeleteStudente(int id)
        {
            _sm.DeleteStudente(id);

            return "yes";
        }
    }
}
