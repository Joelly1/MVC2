using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Models;

namespace MVC2.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: Employee
		public ActionResult Index()
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			var employeeList = employeeBusinessLayer.employees();

			return View(employeeList);
		}
		[HttpGet]
		[ActionName("Create")]
		public ActionResult Create_Get()
		{

			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			var employeeId = employeeBusinessLayer.getEmployeeById(id);
			return View(employeeId);
		}

		[HttpPost]
		[ActionName("Edit")]
		public ActionResult Edit_Post(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			var singleEmployee = employeeBusinessLayer.getEmployeeById(id);
			//Include List
			//UpdateModel(singleEmployee,new string[] {"ID","Gender","City","DateOfBirth"});
			//Exclude List
			UpdateModel(singleEmployee, null, null, new string[] { "Name" });
			if (ModelState.IsValid)
			{

				employeeBusinessLayer.UpadateEmployee(singleEmployee);

				//wrong return Redirect("Index");
				return RedirectToAction("Index");
			}
			return View(singleEmployee);
		}
		/* This was firstly use that causes by pass of parameter by fiddler
		public ActionResult Edit(Employee employee)
		{

			if (ModelState.IsValid)
			{
				EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
				employeeBusinessLayer.UpadateEmployee(employee);

				//wrong return Redirect("Index");
				return RedirectToAction("Index");
			}
			return View(employee);


		}*/


		[HttpPost]
		[ActionName("Create")]
		public ActionResult Create_Post()
		{
			if (ModelState.IsValid)
			{
				Employee employee = new Employee();
				UpdateModel(employee);//TryUpdateModel(employee);
									  //if (ModelState.IsValid)
									  //{
				EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
				employeeBusinessLayer.CreateEmployee(employee);

				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpPost]
		public ActionResult Delete(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			employeeBusinessLayer.DeleteEmployee(id);
			return RedirectToAction("Index");
		} 
	}
}
	


//foreach(string key in formCollection.AllKeys)
//			{
//				Response.Write("Key = " + key + " ");
//				Response.Write(formCollection[key]);
//				Response.Write("<br/>");
//			}

/*public ActionResult Create(FormCollection formCollection)
{
	Employee employee = new Employee
	{
		Name = formCollection["Name"],
		Gender = formCollection["Gender"],
		City = formCollection["City"],
		DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"])
	};
	EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
	employeeBusinessLayer.CreateEmployee(employee);
	

	return RedirectToAction("Index");
	*/


/*Second Method of submitting form data
public ActionResult Create(Employee employee)
{
	if (ModelState.IsValid)
	{
		EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
		employeeBusinessLayer.CreateEmployee(employee);

		return RedirectToAction("Index");
	}
	return View();
}
*/
/*
    Editing using excluding and including
	
			public ActionResult Edit_Post(int id)
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			var singleEmployee = employeeBusinessLayer.getEmployeeById(id);
			//Include List
			//UpdateModel(singleEmployee,new string[] {"ID","Gender","City","DateOfBirth"});
			//Exclude List
			UpdateModel(singleEmployee,null,null, new string[] {"Name"});
			if (ModelState.IsValid)
			{
				
				employeeBusinessLayer.UpadateEmployee(singleEmployee);

				//wrong return Redirect("Index");
				return RedirectToAction("Index");
			} 
			return View(singleEmployee);
		}

	 /*
	  Using Binding Method 
	 public ActionResult Edit_Post([Bind(Include ="Id, Gender, City, DateOfBirth")] Employee employee)
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			employee.Name = employeeBusinessLayer.getEmployeeById(employee.ID).Name;
			if (ModelState.IsValid)
			{
				
				employeeBusinessLayer.UpadateEmployee(employee);

				//wrong return Redirect("Index");
				return RedirectToAction("Index");
			} 
			return View(employee);
		} 
	 */
