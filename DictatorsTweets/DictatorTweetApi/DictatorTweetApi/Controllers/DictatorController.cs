using DictatorTweetApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DictatorTweetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictatorController : Controller
    {
        private readonly IDictatorService dictatorService;
        public DictatorController(IDictatorService dictatorService)
        {
            this.dictatorService = dictatorService;
        }
        // GET: DictatorController
        [HttpGet]
        public IEnumerable<Dictator> Index()
        {
            return dictatorService.GetAllDictators();
        }

        // GET: DictatorController/Create
        [HttpPost]
        public Dictator Create(string dictatorName, string Description)
        {
            return dictatorService.CreateDictator(dictatorName, Description);
        }


        // GET: DictatorController/Edit/5
        [HttpPatch]
        public Dictator Edit(string dictatorName, string newDicName, string newDesc)
        {
            return dictatorService.UpdateDictator(dictatorName, newDicName, newDesc);
        }


        // POST: DictatorController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
