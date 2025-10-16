using DepartmentAccountingContracts.ComponentContracts;
using DepartmentAccountingContracts.Enums;

namespace DepartmentsComponent;

public class DepartmentsComponent : IComponentContract
{
    public Guid Id => Guid.NewGuid();

    public string DisplayName => "Подразделения";

    public ComponentType Type => ComponentType.Department;

    public ComponentCategory Category => ComponentCategory.Entity;

    public UserControl Control => new DepartmentsControl();

    public LicenseLevel RequiredLicenseLevel => LicenseLevel.Basic;
}
