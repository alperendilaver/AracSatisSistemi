using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Data.Abstract;
using yazilim_mimari.Data.Models;

namespace yazilim_mimari.Data.Concreate
{
    public class EfGorselService : IGorselService
    {
        public void EskiGorselleriSil(Ilan ilan)
        {
             foreach (var gorsel in ilan.Resimler)
            {
                var EskiGorselYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", gorsel);
                if (System.IO.File.Exists(EskiGorselYolu))
                    {
                        System.IO.File.Delete(EskiGorselYolu);
                    }
            }
        }

        public async Task<List<string>> GorselEkle(IFormFileCollection gorseller)
        {
            var Resimler = new List<string>();
            foreach (var gorsel in gorseller)
            {
                var extension = Path.GetExtension(gorsel.FileName);
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",randomFileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await gorsel.CopyToAsync(stream);
                }
                Resimler.Add(randomFileName);
            }    
            return Resimler;       
        }
    }
}