using Manager.Data.DTOs.AttendancesModule;
using Manager.Data.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AttendancesModule
{
    public class AttendanceService : IAttendanceService
    {
        private readonly StudentEntities context;

        public AttendanceService(StudentEntities context)
        {
            this.context = context;
        }
        public async Task<bool> Create(AttendanceDTO attendanceDTO)
        {
            try
            {
                var s = new Attendance
                {
                    Id = Guid.NewGuid(),

                    AttendanceDate = attendanceDTO.AttendanceDate,

                    StudentId = attendanceDTO.StudentId,

                    Remarks = attendanceDTO.Remarks,

                    CreatedById = attendanceDTO.CreatedById,

                    CreateDate = DateTime.Now,

                };

                context.Attendances.Add(s);

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

                var s = await context.Attendances.FindAsync(Id);

                if (s != null)
                {
                    context.Attendances.Remove(s);

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

        public async Task<List<AttendanceDTO>> GetAll()
        {
            try
            {
                var attendance = await context.Attendances.ToListAsync();

                var attendances = new List<AttendanceDTO>();

                foreach (var item in attendance)
                {
                    var data = new AttendanceDTO
                    {
                        Id = item.Id,

                        AttendanceDate = item.AttendanceDate,

                        StudentId = item.StudentId,

                        Remarks = item.Remarks,

                        CreatedById = item.CreatedById,

                        CreatedByName = item.AspNetUser.FirstName + " " + item.AspNetUser.LastName,

                        CreateDate = item.CreateDate,
                    };
                    attendances.Add(data);
                }

                return attendances;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<AttendanceDTO> GetById(Guid Id)
        {
            try
            {
                var attendance = await context.Attendances.FindAsync(Id);

                return new AttendanceDTO
                {
                    Id = attendance.Id,

                    AttendanceDate = attendance.AttendanceDate,

                    StudentId = attendance.StudentId,

                    Remarks = attendance.Remarks,

                    CreatedById = attendance.CreatedById,

                    CreatedByName = attendance.AspNetUser.FirstName + " " + attendance.AspNetUser.LastName,

                    CreateDate = attendance.CreateDate,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Update(AttendanceDTO attendanceDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Attendances.FindAsync(attendanceDTO.Id);
                    {

                        s.AttendanceDate = attendanceDTO.AttendanceDate;

                        s.StudentId = attendanceDTO.StudentId;

                        s.Remarks = attendanceDTO.Remarks;


                    };

                    transaction.Commit();

                    await context.SaveChangesAsync();

                    return true;

                }
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
