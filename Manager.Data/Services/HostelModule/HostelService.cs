using Manager.Data.DTOs.HostelModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.HostelModule
{
    public class HostelService : IHostelService
    {
        private readonly StudentEntities context;

        public HostelService(StudentEntities context)
        {
            this.context = context;
        }

        public async Task<bool> CreateHostel(HostelDTO hostelDTO)
        {
            try
            {
                var s = new Hostel
                {
                    Id = Guid.NewGuid(),

                    Name = hostelDTO.Name,

                    Capacity = hostelDTO.Capacity,

                    CreateDate = DateTime.Now,

                    CreatedById = hostelDTO.CreatedById,

                    UpdatedById = hostelDTO.CreatedById

                };

                context.Hostels.Add(s);

                return await context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> DeleteHostel(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Hostels.FindAsync(Id);

                if (s != null)
                {
                    context.Hostels.Remove(s);

                    await context.SaveChangesAsync();

                    return true;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<HostelDTO> GetAllHostelById(Guid Id)
        {
            try
            {
                var hostel = await context.Hostels.FindAsync(Id);

                return new HostelDTO
                {
                    Id = hostel.Id,

                    Name = hostel.Name,

                    Capacity = hostel.Capacity.Value,

                    CreateDate = hostel.CreateDate,

                    CreatedById = hostel.CreatedById,

                    UpdatedById = hostel.CreatedById
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<List<HostelDTO>> GetAllHostels()
        {
            try
            {
                var hostel = await context.Hostels.ToListAsync();

                var hostels = new List<HostelDTO>();

                foreach (var item in hostel)
                {
                    var data = new HostelDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        Capacity = item.Capacity.Value,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName +" "+ item.AspNetUser.LastName,

                        UpdatedById = item.CreatedById

                    };
                    hostels.Add(data);
                }

                return hostels;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> UpdateHostel(HostelDTO hostelDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Hostels.FindAsync(hostelDTO.Id);
                    {

                        s.Name = hostelDTO.Name;

                        s.Capacity = hostelDTO.Capacity;

                        s.UpdatedById = hostelDTO.UpdatedById;

                    };

                    transaction.Commit();

                    await context.SaveChangesAsync();

                }

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
