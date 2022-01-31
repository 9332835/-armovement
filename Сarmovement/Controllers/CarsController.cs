using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сarmovement.Data;

namespace Сarmovement
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly Сarmovement.Data.ApplicationDbContext _dbContext;

        public CarsController(Сarmovement.Data.ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        // GET: api/<Car1Controller>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            //     return new string[] { "value1", "value2" };
            return _dbContext.Cars
          //      .Where(c=>c.Number== "ВН 35-44 ЕС")
                .OrderBy(c=>c.Time).ToList();
        }
        //[HttpGet("pointsbyid")]
        //public IEnumerable<Car> Getpointsbyid()
        //{
        //    //     return new string[] { "value1", "value2" };
        //    return _dbContext.Cars.Where(c => c.Number == "ВН 35-44 ЕС").OrderBy(c => c.Time).ToList();
        //}

    }
}
