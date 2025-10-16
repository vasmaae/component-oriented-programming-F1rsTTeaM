using DepartmentAccountingContracts.Models;

namespace DepartmentAccountingContracts.Repository;

public static class SharedRepository
{
    public static Repository<Department> Departments { get; set; } = new();
    public static Repository<Specialization> Specializations { get; set; } = new();

    static SharedRepository()
    {
        Specializations.Add(new Specialization { Name = "1" });
        Specializations.Add(new Specialization { Name = "2" });
        Specializations.Add(new Specialization { Name = "3" });

        Departments.Add(new Department { Name = "1", LocationScheme = "1", Specialization = "1", PhoneNumber = "1-1-11" });
        Departments.Add(new Department { Name = "2", LocationScheme = "2", Specialization = "2", PhoneNumber = "2-2-22" });
        Departments.Add(new Department { Name = "3", LocationScheme = "3", Specialization = "2", PhoneNumber = "3-3-33" });
        Departments.Add(new Department { Name = "4", LocationScheme = "4", Specialization = "3", PhoneNumber = "4-4-44" });
        Departments.Add(new Department { Name = "5", LocationScheme = "5", Specialization = "3", PhoneNumber = "5-5-55" });
        Departments.Add(new Department { Name = "6", LocationScheme = "6", Specialization = "3", PhoneNumber = "6-6-66" });
    }
}
