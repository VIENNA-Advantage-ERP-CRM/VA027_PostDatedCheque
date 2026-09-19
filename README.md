# Post Dated Cheque (VA027)

**Post-dated cheques for Onfinity ERP.** An add-on module for [Onfinity ERP and CRM](https://github.com/VIENNA-Advantage-ERP-CRM/Official-VAStandard-ERP-CRM) (formerly VIENNA Advantage), the open source ERP in C#/.NET.

Records a post-dated cheque with its date and the invoices it settles, keeps it until the date, and presents or allocates it when due. Cheque details, allocation and the post-dated cheque document itself are windows in the system.

Windows and forms: Post Dated Check; Cheque allocation.

## Installing

Modules are packaged with their Application Dictionary entries, code and files, and installed through the Onfinity Market inside the system or from the Module Management window (System Administration role). The module version must match the Onfinity release you run. Packaged releases of the system are on [SourceForge](https://sourceforge.net/projects/erp-crm-advant/files/); the Market is described in the [documentation](https://viennaadvantage.atlassian.net/wiki/spaces/VA/pages/3670266/About+VIENNA+Advantage+Market).

## Repository layout

| Folder | Contents |
|---|---|
| `ViennaAdvantage` | The module's model classes and processes. |
| `ViennaAdvantageSvc` | Its services. |
| `ViennaAdvantageWeb` | Its area: windows, forms, scripts. |

Build with `ViennaAdvantageWeb.sln` (Visual Studio 2019 or later, .NET Framework) against the [framework](https://github.com/VIENNA-Advantage-ERP-CRM/Official-VAFramework) and [base libraries](https://github.com/VIENNA-Advantage-ERP-CRM/Official-VABaseFiles) of the matching release; see the ERP repository's [BUILD.md](https://github.com/VIENNA-Advantage-ERP-CRM/Official-VAStandard-ERP-CRM/blob/master/BUILD.md).

| | |
|---|---|
| Website | https://onfinity.io |
| Community portal | https://login.onfinity.io/register.aspx |

## Licence

Eclipse Public Licence. See https://onfinity.io/open-source-erp.php.
