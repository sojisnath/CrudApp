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
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed.")]
    public string? EmpName { get; set; }

    [Required(ErrorMessage = "Designation is required")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed.")]
    public string? EmpDesignation { get; set; }

    [Required(ErrorMessage = "Department is required")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed.")]
    public string? EmpDepartment { get; set; }

    [Required(ErrorMessage = "MobileNumber  is required")]
    [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Only numbers are allowed.")]
    public string? EmpMobileNumber { get; set; }

    [Required(ErrorMessage = "EmailId is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? EmpEmailId { get; set; }

    [Required(ErrorMessage = "Salary  is required")]
    [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Only numbers are allowed.")]
    public string? EmpSalary { get; set; }

    [Required(ErrorMessage = "Address  is required")]
    public string? EmpAddress { get; set; }


}
