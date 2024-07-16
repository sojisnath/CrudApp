using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models;

public partial class EmployeeDetail
{
    public int EmpId { get; set; }

    [Required(ErrorMessage = "Employee Code is required")]
    public string? EmpCode { get; set; }

    [Required(ErrorMessage = "Employee Name Code is required")]
    public string? EmpName { get; set; }

    [Required(ErrorMessage = "Designation is required")]
    public string? EmpDesignation { get; set; }

    [Required(ErrorMessage = "Department is required")]
    public string? EmpDepartment { get; set; }

    [Required(ErrorMessage = "MobileNumber  is required")]
    public string? EmpMobileNumber { get; set; }

    [Required(ErrorMessage = "EmailId is required")]
    public string? EmpEmailId { get; set; }

    [Required(ErrorMessage = "Salary  is required")]
    public string? EmpSalary { get; set; }

    [Required(ErrorMessage = "Address  is required")]
    public string? EmpAddress { get; set; }


}
