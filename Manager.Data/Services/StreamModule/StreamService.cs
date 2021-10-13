using Manager.Data.DTOs.StreamModule;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Manager.Data.EDMX;

namespace Manager.Data.StreamModule
{
    public class StreamService : IStreamService
    {
        private readonly StudentEntities _context;
        public StreamService(StudentEntities context)
        {
            _context = context;
        }

        public async Task<Tuple<bool, StreamDTO, string>> CreateStream(StreamDTO streamDTO)
        {
            try
            {
                var stream = new Stream
                {
                    Id = Guid.NewGuid(),

                    Name = streamDTO.Name,

                    CreatedById = streamDTO.CreatedById,
                                                                        
                    CreateDate = DateTime.Now,

                };

                _context.Streams.Add(stream);

                var res = await _context.SaveChangesAsync();

                return new Tuple<bool, StreamDTO, string>(res > 0, streamDTO, res > 0 ? "Record has been successfully saved" : "Details could not be saved");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new Tuple<bool, StreamDTO, string>(false, null, ex.Message);
            }
        }

        public async Task<bool> DeleteStream(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await _context.Streams.FindAsync(Id);

                if (s != null)
                {
                    _context.Streams.Remove(s);

                    await _context.SaveChangesAsync();

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

        public async Task<List<StreamDTO>> GetAllStream()
        {
            try
            {
                var stream = await _context.Streams.ToListAsync();

                var streams = new List<StreamDTO>();

                foreach (var item in stream)
                {
                    var data = new StreamDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreatedById = item.CreatedById,

                        CreateDate = item.CreateDate,

                    };
                    streams.Add(data);
                }

                return streams;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<StreamDTO> GetstreamById(Guid Id)
        {
            try
            {
                var stream = await _context.Streams.FindAsync(Id);

                return new StreamDTO
                {
                    Id = stream.Id,

                    Name = stream.Name,

                    CreatedById = stream.CreatedById,

                    CreateDate = stream.CreateDate,


                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }



        public async Task<Tuple<bool, StreamDTO, string>> UpdateStream(StreamDTO streamDTO)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var s = await _context.Streams.FindAsync(streamDTO.Id);
                    {
                        s.Name = streamDTO.Name;
                                      

                    };

                    transaction.Commit();
                }

                var res = await _context.SaveChangesAsync();

                return new Tuple<bool, StreamDTO, string>(res > 0, streamDTO, res > 0 ? "Record  has been successfully updated" : "Details could not update");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new Tuple<bool, StreamDTO, string>(false, null, ex.Message);
            }
        }

    }
}
