using DepartmentAccountingContracts.Enums;

namespace DepartmentAccountingContracts.ComponentContracts;

public interface IComponentContract
{
    Guid Id { get; }
    string DisplayName { get; }
    ComponentType Type { get; }
    ComponentCategory Category { get; }
    UserControl Control { get; }
    LicenseLevel RequiredLicenseLevel { get; }
}
