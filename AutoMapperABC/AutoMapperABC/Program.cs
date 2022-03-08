using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperABC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDto, Employee>()
                .ForMember(f => f.Name, a => a.Ignore())
                .ForMember(f => f.Address, a => a.Ignore());
            });
            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();

            var a = new EmployeeDto() { Name = "abc", Salary = 2, Address = "Address", Department = "Department" };
            var b = mapper.Map<Employee>(a);
            b.Name = "xyz";
        }


    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Department, DepartmentDto>();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDto
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class Department
    {
        public string DeptName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }

    public class DepartmentDto
    {
        public string DeptName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
