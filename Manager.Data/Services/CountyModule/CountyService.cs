using Manager.Data.DTOs.CountyModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.CountyModule
{
    public class CountyService : ICountyService
    {
        private readonly StudentEntities context;

        public CountyService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<List<CountyDTO>> GetAllCounties()
        {
            try
            {
                var county = await context.Counties.ToListAsync();

                var counties = new List<CountyDTO>();

                foreach (var item in county)
                {
                    var data = new CountyDTO
                    {
                        Id=item.Id,

                        Name=item.Name,
                    };

                    counties.Add(data);

                }
                return counties;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
