using DepartmentAccountingContracts.Models;

namespace DepartmentAccountingContracts.Repository;

public static class SharedRepository
{
    public static Repository<Department> Departments { get; set; } = new();
    public static Repository<Specialization> Specializations { get; set; } = new();

    static SharedRepository()
    {
    }
}
