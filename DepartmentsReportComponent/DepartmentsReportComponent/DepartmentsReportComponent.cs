using DepartmentAccountingContracts.ComponentContracts;
using DepartmentAccountingContracts.Enums;

namespace DepartmentsReportComponent;

public class DepartmentsReportComponent : IComponentContract
{
    public Guid Id => Guid.NewGuid();

    public string DisplayName => "Отчёт по подразделениям";

    public ComponentType Type => ComponentType.DepartmentReport;

    public ComponentCategory Category => ComponentCategory.Report;

    public UserControl Control => new DepartmentsReportControl();

    public LicenseLevel RequiredLicenseLevel => LicenseLevel.Advanced;
}
