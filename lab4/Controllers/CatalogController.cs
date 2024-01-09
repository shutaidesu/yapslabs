using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private static Catalog catalog = new Catalog();

        [HttpPost(Name = "AddComposition")]
        public IActionResult AddComposition(Composition composition)
        {
            catalog.AddComposition(composition);

            return Ok(composition);
        }

        [HttpDelete(Name = "Remove")]
        public IActionResult RemoveComposition(string artistCriteria, string TitleCriteria)
        {
            Composition compositionToRemove = catalog.Search(artistCriteria, TitleCriteria).FirstOrDefault();

            catalog.RemoveComposition(compositionToRemove);
            return Ok($"Composition removed: {compositionToRemove}");
        }


        [HttpGet(Name = "GetCompositions")]
        public IEnumerable<Composition> GetAllCompositions()
        {
            return catalog.GetAllCompositions();
        }
    }
}