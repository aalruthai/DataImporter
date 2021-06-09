using Moj.DataImporter.Contracts.Data;
using Moj.DataImporter.Data;
using Moj.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Moj.DataImporter.Business
{
    public class DeliveryPeriodHandler : IDeliveryPeriodHandler
    {
        private readonly ApplicationDbContext context;

        public DeliveryPeriodHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<DeliveryPeriod>> GetAllDeliveryPeriods()
        {
            return await context.DeliveryPeriods.ToListAsync();
        }
    }
}
