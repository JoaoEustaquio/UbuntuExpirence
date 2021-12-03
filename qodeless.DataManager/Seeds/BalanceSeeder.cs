using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.domain.Entities;

namespace qodeless.DataManager.Seeds
{
    public class BalanceSeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {


            #region DEVICESEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var balanceSeederId1 = Guid.Parse("1541a4f2-c656-437a-9650-68faeabf8e4a");
            var balanceSeederId2 = Guid.Parse("1f94ad1e-abe4-4fce-9b13-31cf0dfd123b");
            var balanceSeeds = new List<Balance>() {
                new Balance(balanceSeederId1){UserPlayerId = "Chloe", UserOperationId = "1-2-d-c-6", Type = EBalanceType.Credit, Amount = 450, },
                new Balance(balanceSeederId2){UserPlayerId = "Amenadiel", UserOperationId = "2-4-c-g-8", Type = EBalanceType.Debit, Amount = 500,  }
            };

            var BalanceRepository = new BalanceRepository(_dbContext);
            foreach (var balanceSeed in balanceSeeds)
            {
                BalanceRepository.Upsert(balanceSeed, _ => _.Id == balanceSeed.Id, true);
            }
            #endregion //DEVICESEEDER

        }
    }
}

