using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.domain.Entities;

namespace qodeless.DataManager.Seeds
{
    public class CurrencySeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {


            #region CURRENCYSEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var currencySeederId1 = Guid.Parse("68a9af4e-d3dd-453f-bf81-c2e1e41e4e46");
            var currencySeederId2 = Guid.Parse("7785aa7a-2496-4417-bf9b-0f5ebc704b70");
            var currencySeeds = new List<Currency>() {
                new Currency(currencySeederId1){Code = ECurrencyCode.EUR, VlrToBRL = 7.88},
                new Currency(currencySeederId2){Code = ECurrencyCode.USD, VlrToBRL = 9.21}
            };

            var CurrencyRepository = new CurrencyRepository(_dbContext);
            foreach (var currencySeed in currencySeeds)
            {
                CurrencyRepository.Upsert(currencySeed, _ => _.Id == currencySeed.Id, true);
            }
            #endregion //CURRENCYSEEDER

        }
    }
}

