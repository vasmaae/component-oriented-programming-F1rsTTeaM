using DepartmentAccountingContracts.ComponentContracts;
using DepartmentAccountingContracts.Enums;

namespace SpecializationsComponent;

public class SpecializationsComponent : IComponentContract
{
    public Guid Id => Guid.NewGuid();

    public string DisplayName => "Специализация";

    public ComponentType Type => ComponentType.Specialization;

    public ComponentCategory Category => ComponentCategory.Entity;

    public UserControl Control => new SpecializationsControl();

    public LicenseLevel RequiredLicenseLevel => LicenseLevel.Minimal;
}
