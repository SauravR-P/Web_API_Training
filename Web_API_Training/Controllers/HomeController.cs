using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Training.Model;

namespace Web_API_Training.Controllers
{
    public class HomeController : Controller
    {
        private DBContext _dbContext;
        public HomeController(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        // GET: HomeController
        [HttpGet("GETALL")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Task.FromResult(_dbContext.Books.ToList());
            return  Ok(result);
        }

        // GET: HomeController/Details/5
        [HttpGet("GETBYID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await Task.FromResult(_dbContext.Books.FirstOrDefault(x=>x.Id==id));
            return Ok(result);
        }

        [HttpPost("Upsert")]
        public async Task<IActionResult> Upsert([FromBody]Books books)
        {

            var checkExisting = _dbContext.Books.FirstOrDefault(x => x.Id == books.Id);
            if (checkExisting == null)
            {
                _dbContext.Books.Add(books);
            }
            else { _dbContext.Books.Update(books);}
            _dbContext.SaveChanges();
            return Ok(books);
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Books.Single(x => x.Id == id));
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Id Not Found");
            }
           
          
        }


    }
}
