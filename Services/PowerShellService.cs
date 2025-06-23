
using System.Management.Automation;

//public class PowerShellService
//{
//    public List<string> CheckMailboxSizes()
//    {
//        var results = new List<string>();
//        using (PowerShell ps = PowerShell.Create())
//        {
//            ps.AddScript("Connect-ExchangeOnline -UserPrincipalName admin@domain.com");
//            ps.AddScript("Get-Mailbox | Get-MailboxStatistics | Select DisplayName, TotalItemSize");

//            foreach (var result in ps.Invoke())
//            {
//                results.Add(result.ToString());
//            }
//        }
//        return results;
//    }
//}

namespace M365HealthCheckApp.Services
{
    public class PowerShellService
    {
        public List<string> CheckMailboxSizes()
        {
            var results = new List<string>();
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript("Connect-ExchangeOnline -UserPrincipalName admin@domain.com");
                ps.AddScript("Get-Mailbox | Get-MailboxStatistics | Select DisplayName, TotalItemSize");

                foreach (var result in ps.Invoke())
                {
                    results.Add(result.ToString());
                }
            }
            return results;
        }
    }
}

