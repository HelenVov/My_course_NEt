using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Models;
using Task1_MVS.Models;
using Task1_MVS.Models.ViewModels;
using Task1_MVS.WorkWithData;

namespace Task1_MVS.Controllers
{
    public class ResponsibleForIndexController : Controller
    {
        private readonly WorkWithDatabase _workWithDatabase;
        private readonly Сonverter _сonverter;

        public ResponsibleForIndexController(WorkWithDatabase workWithDatabase, Сonverter converter)
        {
            _workWithDatabase = workWithDatabase;
            _сonverter = converter;
        }

        /// <summary>
        /// Homepage action
        /// </summary>
        /// <returns>Data of the main page, article</returns>
        public ActionResult Index()
        {
            return View(GetArticles());
        }

        /// <summary>
        /// Get Articles For View Model From DB
        /// </summary>
        /// <returns></returns>
        private ArticlesViewModel GetArticles()
        {
            var articles = _workWithDatabase.GetArticles();
            var anotherArticles = _сonverter.ToArticleViewModelList(articles.ToList());

            return new ArticlesViewModel
            {
                Articles = anotherArticles
            };
        }

    }
}