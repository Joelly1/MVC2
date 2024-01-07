using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public class EmployeeBusinessLayer
	{
		MVC2DEMOEntities entitiesDB = new MVC2DEMOEntities();
		public List<Employee> employees()
		{
			var employ = entitiesDB.Employees.ToList();
			return employ;
		}

		public void CreateEmployee(Employee employee)
		{
			entitiesDB.Employees.Add(employee);
			entitiesDB.SaveChanges();
		}

		public Employee getEmployeeById(int? id)
		{
			Employee employee = entitiesDB.Employees.Single(emp=>emp.ID == id);
			return employee;
		}

		public void UpadateEmployee(Employee employee)
		{
			entitiesDB.Entry(employee).State = System.Data.Entity.EntityState.Modified;
			entitiesDB.SaveChanges();
		}
		
		public void DeleteEmployee(int id)
		{
			var delete = entitiesDB.Employees.Find(id);
			entitiesDB.Employees.Remove(delete);
			entitiesDB.SaveChanges();
		}
	}
}
