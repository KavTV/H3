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
        public Dictator Create([FromBody]Dictator dictator)
        {
            return dictatorService.CreateDictator(dictator.Name, dictator.Description);
        }


        // GET: DictatorController/Edit/5
        [HttpPatch]
        public Dictator Edit(string id, [FromBody] Dictator dictator)
        {
            return dictatorService.UpdateDictator(id, dictator.Name, dictator.Description);
        }


        // POST: DictatorController/Delete/5
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (dictatorService.DeleteDictator(id))
            {
                return Ok();
            }

            return StatusCode(404);
        }
    }
}
