using System;
using Azure.Core;
using BusinessObject;
using DataAccess.Dto.ClassroomDto;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ClassroomDAO
    {
        private readonly VemsContext _context;

        public ClassroomDAO()
        {
            _context = new VemsContext();
        }

        // Lấy Classroom theo Id
        public async Task<Classroom> GetClassroomByIdAsync(Guid id)
        {
            try
            {
                return await _context.Classrooms.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lớp học theo Id: {ex.Message}", ex);
            }
        }

        // Lấy tất cả Classrooms
        public async Task<List<ClassroomResponse>> GetAllClassroomsAsync()
        {
            try
            {
                var classrooms = await (from c in _context.Classrooms
                                        join g in _context.Grades on c.GradeId equals g.Id
                                        join t in _context.Teacher on c.Id equals t.ClassroomId into teacherGroup
                                        from teacher in teacherGroup.DefaultIfEmpty()
                                        select new
                                        {
                                            ClassID = c.Id,
                                            ClassName = c.ClassName,
                                            GradeID = g.Id,
                                            PrimaryTeacherName = teacher != null ? teacher.FullName : null,
                                            PrimaryTeacherID = teacher != null ? teacher.Id : (Guid?)null,
                                            NumberOfStudents = _context.Students.Count(s => s.ClassroomId == c.Id)
                                        })
                                       .OrderBy(c => c.ClassName)
                                       .ToListAsync();

                // Map kết quả truy vấn thành danh sách ClassroomResponse
                var result = classrooms.Select(c => new ClassroomResponse
                {
                    Id = c.ClassID,
                    ClassName = c.ClassName,
                    GradeId = c.GradeID,
                    PrimaryTeacherName = c.PrimaryTeacherName,
                    PrimaryTeacherID = c.PrimaryTeacherID,
                    NumberOfStudents = c.NumberOfStudents
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy tất cả các lớp học: {ex.Message}", ex);
            }
        }




        public async Task<ClassStudentsResponse> GetClassStudents(Guid classID)
        {
            try
            {
                var primaryTeacher = await _context.Teacher.FirstOrDefaultAsync(t => t.ClassroomId == classID);
                var students = await (from a in _context.Students
                                      join c in _context.Classrooms on a.ClassroomId equals c.Id
                                      join t in _context.studentTypes on a.StudentTypeId equals t.Id
                                      where c.Id == classID
                                      select new ClassStudentInfo
                                      {
                                          StudentID = a.Id,
                                          StudentName = a.FullName,
                                          StudentImage = a.Image,
                                          StudentType = t.TypeName,
                                          StudentTypeID = t.Id,
                                          StudentPhone = a.Phone,
                                          ClassName = c.ClassName,
                                          PublicStudentID = a.PublicStudentID

                                      }).ToListAsync();

                students = students
                    .AsEnumerable()
                    .OrderBy(s => s.StudentName.Substring(s.StudentName.LastIndexOf(" ") + 1))
                    .ToList();

                if (students.Any())
                    return new ClassStudentsResponse
                    {
                        ClassID = classID,
                        ClassName = students[0].ClassName,
                        NumberOfStudent = students.Count,
                        PrimaryTeacherName = primaryTeacher != null ? primaryTeacher.FullName : null,
                        PrimaryTeacherID = primaryTeacher != null ? primaryTeacher.Id : null,
                        Students = students
                    };

                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra: " + e.Message);
            }
        }

        public async Task<List<StudentType>> GetAllStudentType()
        {
            try
            {
                return await _context.studentTypes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra: " + e.Message);

            }
        }


        public async Task<bool> AssignStudentType(AssignStudentTypeRequest request)
        {
            try
            {
                var studentType = _context.studentTypes.ToList();
                var currentStudent = _context.Students.Find(request.studentID);


                if (request.studentTypeID == studentType.Find(x => x.Code == "CLASS_MONITOR").Id)
                {
                    var currentClassMonitor = _context.Students.Count(item => item.ClassroomId == currentStudent.ClassroomId && item.StudentTypeId == request.studentTypeID);
                    if (currentClassMonitor == 0)
                    {
                        currentStudent.StudentTypeId = request.studentTypeID;
                        _context.Entry<Student>(currentStudent).State = EntityState.Modified;
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Mỗi lớp chỉ được tồn tại một chức vụ lớp trưởng!");
                    }
                }
                else if (request.studentTypeID == studentType.Find(x => x.Code == "CLASS_VICE_MONITOR").Id)
                {
                    var currentClassMonitor = _context.Students.Count(item => item.ClassroomId == currentStudent.ClassroomId && item.StudentTypeId == request.studentTypeID);
                    if (currentClassMonitor == 0)
                    {
                        currentStudent.StudentTypeId = request.studentTypeID;
                        _context.Entry<Student>(currentStudent).State = EntityState.Modified;
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Mỗi lớp chỉ được tồn tại một chức vụ lớp phó!");
                    }
                }
                else
                {
                    currentStudent.StudentTypeId = request.studentTypeID;
                    _context.Entry<Student>(currentStudent).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;

                }

            }
            catch (Exception e)
            {
                throw new Exception("" + e.Message.ToString());
            }
        }
        // Thêm Classroom
        public async Task AddClassroomAsync(Classroom classroom)
        {
            try
            {
                // Kiểm tra nếu gradeId đã tồn tại
                if (!await IsGradeExists(classroom.GradeId))
                {
                    throw new InvalidOperationException("Khối không tồn tại.");
                }

                // Kiểm tra nếu classroomId đã tồn tại
                if (await IsClassroomExists(classroom.Id))
                {
                    throw new InvalidOperationException("ID của lớp học đã tồn tại.");
                }

                _context.Classrooms.Add(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Xảy ra lỗi đồng thời khi tạo lớp học. Vui lòng thử lại.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm lớp học: {ex.Message}", ex);
            }
        }

        public async Task AddClassrooms(List<ImportClassRequest> classrooms)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    foreach (var request in classrooms)
                    {
                        var existingClassroom = await context.Classrooms
                            .FirstOrDefaultAsync(c => c.ClassName == request.ClassName);

                        if (existingClassroom != null)
                        {
                            continue;
                        }

                        var newClassroom = new Classroom
                        {
                            ClassName = request.ClassName,
                            GradeId = request.GradeID  
                        };

                        context.Classrooms.Add(newClassroom);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Có lỗi khi tạo lớp: {e.Message}", e);
            }
        }

        // Cập nhật Classroom
        public async Task UpdateClassroomAsync(Classroom classroom)
        {
            try
            {
                // Kiểm tra nếu gradeId đã tồn tại
                if (!await IsGradeExists(classroom.GradeId))
                {
                    throw new InvalidOperationException("Khối không tồn tại.");
                }

                // Kiểm tra nếu classroomId đã tồn tại
                if (!await IsClassroomExists(classroom.Id))
                {
                    throw new InvalidOperationException("Không tìm thấy lớp học.");
                }

                _context.Classrooms.Update(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Xảy ra lỗi đồng thời khi cập nhật lớp học. Vui lòng thử lại.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lớp học: {ex.Message}", ex);
            }
        }

        // Xóa Classroom
        public async Task DeleteClassroomAsync(Guid id)
        {
            try
            {
                var classroom = await GetClassroomByIdAsync(id);
                if (classroom == null)
                {
                    throw new InvalidOperationException("Không tìm thấy lớp học.");
                }

                _context.Classrooms.Remove(classroom);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Xảy ra lỗi đồng thời khi xóa lớp học. Vui lòng thử lại.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lớp học: {ex.Message}", ex);
            }
        }

        public async Task<List<GetSelectHomeroomResponse>> GetSelectHomeroomResponse()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Classrooms
                        .Where(c => !context.Teacher.Any(t => t.ClassroomId == c.Id))
                        .Select(c => new GetSelectHomeroomResponse  { ClassId = c.Id, ClassName = c.ClassName })
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tạo lớp:"+ex.Message);
            }
        }

        // Kiểm tra nếu Classroom tồn tại
        private async Task<bool> IsClassroomExists(Guid id)
        {
            return await _context.Classrooms
                .AsNoTracking()
                .AnyAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        // Kiểm tra nếu Grade tồn tại
        private async Task<bool> IsGradeExists(Guid gradeId)
        {
            return await _context.Grades
                .AsNoTracking()
                .AnyAsync(g => g.Id == gradeId)
                .ConfigureAwait(false);
        }
    }
}
