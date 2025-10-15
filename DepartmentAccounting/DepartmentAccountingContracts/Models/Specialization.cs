using System.ComponentModel;

namespace DepartmentAccountingContracts.Models;

public class Specialization : Entity
{
    [DisplayName("Специализация")]
    public string Name { get; set; }
}
