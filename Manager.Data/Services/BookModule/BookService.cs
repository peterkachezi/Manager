using Manager.Data.DTOs.BookModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.BookModule
{
    public class BookService : IBookService
    {
        private readonly StudentEntities contex;
        public BookService(StudentEntities contex)
        {
            this.contex = contex;
        }
        public async Task<bool> Create(BookDTO bookDTO)
        {
            try
            {
                var s = new Book
                {
                    Id = Guid.NewGuid(),

                    BookNumber = bookDTO.BookNumber,

                    SupplierId = bookDTO.SupplierId,

                    Title = bookDTO.Title,

                    AuthorId = bookDTO.AuthorId,

                    Subject = bookDTO.Subject,

                    PublisherId = bookDTO.PublisherId,

                    ISBNNumber = bookDTO.ISBNNumber,

                    Quantity = bookDTO.Quantity,

                    CreateDate = DateTime.Now,

                    CreatedById = bookDTO.CreatedById,

                };

                contex.Books.Add(s);

                return await contex.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> Delete(BookDTO bookDTO)
        {
            try
            {
                bool result = false;

                var s = await contex.Books.FindAsync(bookDTO.Id);

                if (s != null)
                {
                    contex.Books.Remove(s);

                    await contex.SaveChangesAsync();

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

        public async Task<List<BookDTO>> GetAll()
        {
            try
            {
                var book = await contex.Books.ToListAsync();

                var books = new List<BookDTO>();

                foreach (var item in book)
                {
                    var data = new BookDTO
                    {
                        Id = item.Id,

                        BookNumber = item.BookNumber,

                        SupplierId = item.SupplierId,

                        Title = item.Title,

                        AuthorId = item.AuthorId,

                        Subject = item.Subject,

                        PublisherId = item.PublisherId,

                        ISBNNumber = item.ISBNNumber,

                        Quantity = item.Quantity,

                        CreateDate = item.CreateDate,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + "" + item.AspNetUser.LastName,

                    };
                    books.Add(data);
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<BookDTO> GetById(Guid Id)
        {
            try
            {
                var book = await contex.Books.FindAsync(Id);

                return new BookDTO
                {
                    Id = book.Id,

                    BookNumber = book.BookNumber,

                    SupplierId = book.SupplierId,

                    Title = book.Title,

                    AuthorId = book.AuthorId,

                    Subject = book.Subject,

                    PublisherId = book.PublisherId,

                    ISBNNumber = book.ISBNNumber,

                    Quantity = book.Quantity,

                    CreateDate = book.CreateDate,

                    CreatedById = book.CreatedById,

                    CreatedByName = book.AspNetUser.FirstName + "" + book.AspNetUser.LastName,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(BookDTO bookDTO)
        {
            try
            {

                using (var transaction = contex.Database.BeginTransaction())
                {
                    var s = await contex.Books.FindAsync(bookDTO.Id);
                    {
                        s.BookNumber = bookDTO.BookNumber;

                        s.SupplierId = bookDTO.SupplierId;

                        s.Title = bookDTO.Title;

                        s.AuthorId = bookDTO.AuthorId;

                        s.Subject = bookDTO.Subject;

                        s.PublisherId = bookDTO.PublisherId;

                        s.ISBNNumber = bookDTO.ISBNNumber;

                        s.Quantity = bookDTO.Quantity;

                    };
                    transaction.Commit();

                    await contex.SaveChangesAsync();
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
