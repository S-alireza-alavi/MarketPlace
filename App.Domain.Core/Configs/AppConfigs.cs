using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Configs
{

    public class AppConfigs
    {
        public Logging Logging { get; set; }
        public CommissionSettings CommissionSettings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class CommissionSettings
    {
        public int NormalCommissionRate { get; set; }
        public int SaleAmountForMedal { get; set; }
        public int ReducedCommissionRate { get; set; }
    }
}
