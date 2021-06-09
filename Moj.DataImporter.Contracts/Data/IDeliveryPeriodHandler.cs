using Moj.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moj.DataImporter.Contracts.Data
{
    public interface IDeliveryPeriodHandler
    {
        Task<List<DeliveryPeriod>> GetAllDeliveryPeriods();
    }
}
