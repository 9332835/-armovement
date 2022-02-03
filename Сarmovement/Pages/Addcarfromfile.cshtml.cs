using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Сarmovement.Data;

namespace Сarmovement.Pages
{
    public class AppFile
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
    public class AddcarfromfileModel : PageModel
    {
        public AddcarfromfileModel(Сarmovement.Data.ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }
        private readonly Сarmovement.Data.ApplicationDbContext _dbContext;
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var s = new StreamReader(memoryStream))
                {
                    String line;
                    while ((line=s.ReadLine())!=null)
                    {
                        //  ВН 36-84 ЕС,45.698175,28.6018233,2022-01-19 04:39:45.419735 +00:00
                        var data = line.Split(",");
                        if (data.Length != 4)
                        {
                            // return NotFound();
                            ModelState.AddModelError(string.Empty, "Your file not good!");
                        }
                        if (data.Length == 4)
                        {
                            Car car = new Car();
                            //car.CarId = 1;
                            car.Number = data[0];
                            car.Latitude = data[1];
                            car.Longitude = data[2];
                            car.Time = DateTime.Parse(data[3]);
                            _dbContext.Cars.Add(car);
                        }
                        

                    }

                    await _dbContext.SaveChangesAsync();
                }
               
            }

            return Page();
        }
    }
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
