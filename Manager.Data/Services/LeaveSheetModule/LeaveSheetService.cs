using Manager.Data.DTOs.LeaveSheetModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Manager.Data.Services.LeaveSheetModule
{
    public class LeaveSheetService : ILeaveSheetService
    {
        private readonly StudentEntities context;

        public LeaveSheetService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(LeaveSheetDTO leaveSheetDTO)
        {
            try
            {
                var s = new LeaveSheet
                {
                    Id = Guid.NewGuid(),

                    StudentId = leaveSheetDTO.StudentId,

                    CreatedById = leaveSheetDTO.CreatedById,

                    DateTimeOut = leaveSheetDTO.DateTimeOut,

                    DatetTimeIn = leaveSheetDTO.DatetTimeIn,

                    Reasons = leaveSheetDTO.Reasons,

                    AuthorisedById = leaveSheetDTO.AuthorisedById,

                    RecordStatus = leaveSheetDTO.RecordStatus,

                    CreateDate = DateTime.Now,
                };

                context.LeaveSheets.Add(s);

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

                var s = await context.LeaveSheets.FindAsync(Id);

                if (s != null)
                {
                    context.LeaveSheets.Remove(s);

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

        public async Task<List<LeaveSheetDTO>> GetAll()
        {
            try
            {
                var record = await context.LeaveSheets.ToListAsync();

                var records = new List<LeaveSheetDTO>();

                foreach (var item in record)
                {
                    var data = new LeaveSheetDTO
                    {
                        Id = item.Id,

                        StudentId = item.StudentId,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        DateTimeOut = item.DateTimeOut,

                        DatetTimeIn = item.DatetTimeIn,

                        Reasons = item.Reasons,

                        AuthorisedById = item.AuthorisedById,

                        RecordStatus = item.RecordStatus,

                        CreateDate = item.CreateDate,
                    };

                    records.Add(data);
                }
                return records;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<LeaveSheetDTO> GetById(Guid Id)
        {
            try
            {
                var s = await context.LeaveSheets.FindAsync(Id);

                return new LeaveSheetDTO
                {
                    Id = s.Id,

                    StudentId = s.StudentId,

                    CreatedById = s.CreatedById,

                    CreatedByName = s.AspNetUser.FirstName + " " + s.AspNetUser.LastName,

                    DateTimeOut = s.DateTimeOut,

                    DatetTimeIn = s.DatetTimeIn,

                    Reasons = s.Reasons,

                    AuthorisedById = s.AuthorisedById,

                    RecordStatus = s.RecordStatus,

                    CreateDate = s.CreateDate,
                };
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(LeaveSheetDTO leaveSheetDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.LeaveSheets.FindAsync(leaveSheetDTO.Id);
                    {

                        s.StudentId = leaveSheetDTO.StudentId;

                        s.CreatedById = leaveSheetDTO.CreatedById;

                        s.DateTimeOut = leaveSheetDTO.DateTimeOut;

                        s.DatetTimeIn = leaveSheetDTO.DatetTimeIn;

                        s.Reasons = leaveSheetDTO.Reasons;

                        s.AuthorisedById = leaveSheetDTO.AuthorisedById;

                        s.RecordStatus = leaveSheetDTO.RecordStatus;

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
