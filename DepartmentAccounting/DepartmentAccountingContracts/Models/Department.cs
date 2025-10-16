using System.ComponentModel;

namespace DepartmentAccountingContracts.Models;

public class Department : Entity
{
    [DisplayName("Наименование")]
    public string Name { get; set; }
    [DisplayName("Схема расположения")]
    public string LocationScheme { get; set; }
    [DisplayName("Специализация")]
    public string Specialization { get; set; }
    [DisplayName("Рабочий телефон")]
    public string PhoneNumber { get; set; }
}
