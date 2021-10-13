using Manager.Data.DTOs.AuthorModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AuthorModule
{
    public class AuthorService : IAuthorService
    {
        private readonly StudentEntities context;
        public AuthorService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(AuthorDTO authorDTO)
        {
            try
            {
                var s = new Author
                {
                    Id = Guid.NewGuid(),

                    Name = authorDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedById = authorDTO.CreatedById,
                };

                context.Authors.Add(s);

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

                var s = await context.Authors.FindAsync(Id);

                if (s != null)
                {
                    context.Authors.Remove(s);

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

        public async Task<List<AuthorDTO>> GetAll()
        {
            try
            {

                var author = await context.Authors.ToListAsync();

                var authors = new List<AuthorDTO>();

                foreach (var item in author)
                {
                    var data = new AuthorDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + "" + item.AspNetUser.FirstName,
                    };

                    authors.Add(data);
                }
                return authors;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<AuthorDTO> GetById(Guid Id)
        {
            try
            {
                var author = await context.Authors.FindAsync(Id);

                return new AuthorDTO
                {
                    Id = author.Id,

                    Name = author.Name,

                    CreateDate = author.CreateDate,

                    CreatedById = author.CreatedById,

                    CreatedByName = author.AspNetUser.FirstName + "" + author.AspNetUser.FirstName,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(AuthorDTO authorDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Authors.FindAsync(authorDTO.Id);
                    {
                        s.Name = authorDTO.Name;

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
