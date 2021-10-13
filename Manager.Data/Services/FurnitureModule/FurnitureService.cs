using Manager.Data.DTOs.FurnitureModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.FurnitureModule
{
    public class FurnitureService : IFurnitureService
    {
        private readonly StudentEntities context;

        public FurnitureService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(FurnitureDTO furnitureDTO)
        {
            try
            {
                var s = new Furniture
                {
                    Id = Guid.NewGuid(),

                    ItemNumber = furnitureDTO.ItemNumber,

                    CreateDate = DateTime.Now,

                    CreatedById = furnitureDTO.ItemNumber

                };

                context.Furnitures.Add(s);

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

                var s = await context.Furnitures.FindAsync(Id);

                if (s != null)
                {
                    context.Furnitures.Remove(s);

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

        public async Task<List<FurnitureDTO>> GetAll()
        {
            try
            {
                var furniture = await context.Furnitures.ToListAsync();

                var furnitures = new List<FurnitureDTO>();

                foreach (var item in furniture)
                {
                    var data = new FurnitureDTO
                    {
                        Id = item.Id,

                        ItemNumber = item.ItemNumber,

                        CreateDate = item.CreateDate,

                        CreatedById = item.ItemNumber,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                    };

                    furnitures.Add(data);
                }
                return furnitures;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<FurnitureDTO> GetById(Guid Id)
        {
            try
            {
                var furniture = await context.Furnitures.FindAsync(Id);

                return new FurnitureDTO
                {
                    Id = furniture.Id,

                    ItemNumber = furniture.ItemNumber,

                    CreateDate = furniture.CreateDate,

                    CreatedById = furniture.ItemNumber,

                    CreatedByName = furniture.AspNetUser.FirstName + " " + furniture.AspNetUser.LastName,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(FurnitureDTO furnitureDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Furnitures.FindAsync(furnitureDTO.Id);
                    {

                        s.ItemNumber = furnitureDTO.ItemNumber;

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
