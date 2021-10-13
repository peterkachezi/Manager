using Manager.Data.DTOs.PublisherModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.PublisherModule
{
    public class PublisherService : IPublisherService
    {
        private readonly StudentEntities context;
        public PublisherService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(PublisherDTO publisherDTO)
        {
            try
            {
                var s = new Publisher
                {
                    Id = Guid.NewGuid(),

                    Name = publisherDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedById = publisherDTO.CreatedById,

                };

                context.Publishers.Add(s);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Publishers.FindAsync(Id);

                if (s != null)
                {
                    context.Publishers.Remove(s);

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

        public async Task<List<PublisherDTO>> GetAll()
        {
            try
            {
                var publisher = await context.Publishers.ToListAsync();

                var publishers = new List<PublisherDTO>();

                foreach (var item in publisher)
                {
                    var data = new PublisherDTO()
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,
                    };

                    publishers.Add(data);

                }
                return publishers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<PublisherDTO> GetbyId(Guid Id)
        {
            try
            {
                var publisher = await context.Publishers.FindAsync(Id);


                return new PublisherDTO()
                {
                    Id = publisher.Id,

                    Name = publisher.Name,

                    CreateDate = publisher.CreateDate,

                    CreatedById = publisher.CreatedById,

                    CreatedName = publisher.AspNetUser.FirstName + " " + publisher.AspNetUser.LastName,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(PublisherDTO publisherDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Publishers.FindAsync(publisherDTO.Id);
                    {
                        s.Name = publisherDTO.Name;

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
