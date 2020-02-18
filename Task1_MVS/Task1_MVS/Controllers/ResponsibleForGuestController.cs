using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1_MVS.Models;
using Task1_MVS.Models.ViewModels;
using Task1_MVS.WorkWithData;

namespace Task1_MVS.Controllers
{
    public class ResponsibleForGuestController : Controller
    {
        private readonly WorkWithDatabase _workWithDatabase;
        private readonly Сonverter _сonverter;

        public ResponsibleForGuestController(WorkWithDatabase workWithDatabase, Сonverter сonverter)
        {
            _workWithDatabase = workWithDatabase;
            _сonverter = сonverter;
        }

        /// <summary>
        /// Index action
        /// </summary>
        /// <returns></returns>
        public ActionResult Guest()
        {
            return View(GetRecalls());
        }
        /// <summary>
        /// Form submission processing
        /// </summary>
        /// <param name="recallData">Data form </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Guest(RecallDataViewModel recallData)
        {
            if (ModelState.IsValid)
            {
                _workWithDatabase.AddRecall(_сonverter.ToRecallData(recallData));
               // StaticRecallDataViewModel.DataForms.Add(recallData);

                return View(GetRecalls());
            }

            return View(new RecallViewModel
            {
                FormData = recallData
            });
        }
        /// <summary>
        /// Get Articles For View Model From DB
        /// </summary>
        /// <returns></returns>
        private RecallViewModel GetRecalls()
        {
            var recalls = _workWithDatabase.GetRecalls();
            var anotherRecall = _сonverter.ToRecallDataViewModelList(recalls.ToList());

            return new RecallViewModel
            {
                RecallDatas= anotherRecall
            };
        }



    }
}