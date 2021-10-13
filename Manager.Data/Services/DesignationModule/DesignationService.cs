using Manager.Data.DTOs.DesignationModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Manager.Data.EDMX;
using System.Linq;

namespace Manager.Data.DesignationModule
{
    public class DesignationService : IDesignationService
    {
        private readonly StudentEntities context;
        public DesignationService(StudentEntities context)
        {
            this.context = context;
        }


        public async Task<Tuple<bool, DesignationDTO, string>> CreateDesignation(DesignationDTO designationDTO)
        {
            try
            {
                var s = new Designation
                {
                    Id = Guid.NewGuid().ToString(),

                    Name = designationDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedById = designationDTO.CreatedById,

                    UpdatedById = designationDTO.CreatedById,
                };

                context.Designations.Add(s);

                var res = await context.SaveChangesAsync();

                return new Tuple<bool, DesignationDTO, string>(res > 0 ? true : false, designationDTO, res > 0 ? "Record has been successfully saved" : "Details could not be saved");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<bool> DeleteDesignation(string Id)
        {
            try
            {
                bool result = false;

                var s = await context.Designations.FindAsync(Id);

                if (s != null)
                {
                    context.Designations.Remove(s);

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



        public async Task<Tuple<bool, List<DesignationDTO>, string>> GetAllDesignation()
        {
            try
            {
                var claim = (from d in context.Designations

                             join u in context.AspNetUsers on d.CreatedById equals u.Id

                             select new DesignationDTO()
                             {
                                 Id = d.Id,

                                 Name = d.Name,

                                 CreateDate = d.CreateDate,

                                 CreatedById = d.CreatedById,

                                 CreatedByName = u.FirstName + " " + u.LastName,


                             }).ToListAsync();


                return new Tuple<bool, List<DesignationDTO>, string>(true, await claim, "claim details");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }


        public async Task<DesignationDTO> GetDesignationById(string Id)
        {
            try
            {
                var designation = await context.Designations.FindAsync(Id);

                return new DesignationDTO()
                {
                    Id = designation.Id,

                    Name = designation.Name,

                    CreateDate = designation.CreateDate,

                    CreatedById = designation.CreatedById,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }


        public async Task<Tuple<bool, DesignationDTO, string>> UpdateDesignation(DesignationDTO designationDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Designations.FindAsync(designationDTO.Id);
                    {
                        s.Name = designationDTO.Name;

                        s.UpdatedById = designationDTO.UpdatedById;

                    };

                    transaction.Commit();
                }

                var res = await context.SaveChangesAsync();

                return new Tuple<bool, DesignationDTO, string>(res > 0 ? true : false, designationDTO, res > 0 ? "Record  has been successfully updated" : "Details could not update");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new Tuple<bool, DesignationDTO, string>(false, null, ex.Message);
            }
        }

    }
}
