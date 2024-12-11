using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.DataAccess.Repository
{
    public class EmployeeRepository
    {
        private readonly DbContext _context;

        public EmployeeRepository(DbContext context)
        {
            _context = context;
        }

        public Employee? GetById(int id)
        {
            return _context.Set<Employee>().Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().ToList();
        }

        public bool Add(Employee employee)
        {
            _context.Set<Employee>().Add(employee);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Employee updatedEmployee)
        {
            var existing = GetById(updatedEmployee.Id);
            if (existing == null) return false;

            existing.Name = updatedEmployee.Name;
            existing.Position = updatedEmployee.Position;
            existing.DepartmentId = updatedEmployee.DepartmentId;

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee == null) return false;

            _context.Set<Employee>().Remove(employee);
            return _context.SaveChanges() > 0;
        }
    }
}
