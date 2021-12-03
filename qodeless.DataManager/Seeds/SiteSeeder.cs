using qodeless.domain.Entities;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;

namespace qodeless.DataManager.Seeds
{
    public class SiteSeeder
    {
        public static Guid siteId1 = Guid.Parse("f1818cb7-544f-476b-b5d7-e5f32721e3d4");
        public static Guid siteId2 = Guid.Parse("1434d64c-4901-4adb-9763-b151fc12479a");
        public static void Seed(ApplicationDbContext _dbContext)
        {
            #region SITE
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var siteId1 = Guid.Parse("f1818cb7-544f-476b-b5d7-e5f32721e3d4");
            var siteId2 = Guid.Parse("1434d64c-4901-4adb-9763-b151fc12479a");
            var siteId3 = Guid.Parse("afaa9cd1-4816-44d7-8051-6c92b9ad9884");
            var siteId4 = Guid.Parse("33a236e7-55ef-49fd-b9e3-8dd273d8527f");
            var sites = new List<Site>() {
                new Site(siteId1){ Name = "Cassino RG 1", AccountId = AccountSeeder.accountId1, Description = "Cassino RG 1", ESiteType = ESiteType.Casino},
                new Site(siteId2){ Name = "Cassino RG 2", AccountId = AccountSeeder.accountId1,Description = "Cassino RG 2", ESiteType = ESiteType.Casino},
                new Site(siteId3){ Name = "Cassino WHITE LABEL 1", AccountId =  AccountSeeder.accountId2, Description = "Cassino WHITE LABEL 1", ESiteType = ESiteType.LanHouse},
                new Site(siteId4){ Name = "Cassino WHITE LABEL 2", AccountId =  AccountSeeder.accountId2, Description = "Cassino WHITE LABEL 2", ESiteType = ESiteType.Default},
            };

            var siteRepository = new SiteRepository(_dbContext);
            foreach (var site in sites)
            {
                siteRepository.Upsert(site, _ => _.Id == site.Id, true);
            }
            #endregion //SITE
        }
    }
}
