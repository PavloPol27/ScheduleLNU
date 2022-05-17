using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ScheduleLNU.DataAccess.Entities;
using ScheduleLNU.DataAccess.Repository;

namespace ScheduleLNU.Tests.BusinessLogic.ThemeServiceTest
{
    internal class TestStudentRepository : IRepository<Student>
    {
        private readonly List<Student> _students = new ()
        {
            new Student()
            {
                Id = "student-test-id",
                Themes = new ()
                {
                    new () { Id = 1 },
                    new () { Id = 2 },
                    new () { Id = 3 },
                },
                SelectedTheme = new () { Id = 2 }
            },
            new Student()
            {
                Id = "student-withoud-selected-theme-id",
                Themes = new ()
                {
                    new () { Id = 12 },
                    new () { Id = 13 },
                    new () { Id = 16 },
                }
            }
        };

        public Task DeleteAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> SelectAllAsync(Expression<Func<Student, bool>> selector, params Expression<Func<Student, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Student> SelectAsync(Expression<Func<Student, bool>> selector, params Expression<Func<Student, object>>[] includeProperties)
        {
            var predic = selector.Compile();
            return Task.Run(() => _students.Find(s => predic.Invoke(s)));
        }

        public Task UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}