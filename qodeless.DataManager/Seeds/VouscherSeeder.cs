using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Entities;
using qodeless.Infra.CrossCutting.Identity.Repositories;

namespace qodeless.DataManager.Seeds
{
    public class VouscherSeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {
          

            #region DEVICESEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var vouscherSeederId1 = Guid.Parse("53ae6156-4787-4bb2-bfb0-4c02d497fdd6");
            var vouscherSeederId2 = Guid.Parse("a8df2a1f-6cc4-4e53-a03e-c3a2024c3d8a");
            var vouscherSeeds = new List<Vouscher>() {
                new Vouscher(vouscherSeederId1){ UserOperationId = "124", QrCodeKey = "724", QrCodeSecret = "123", DueDate = DateTime.Now, Amount = 1500000, SiteID = Guid.Parse("f1818cb7-544f-476b-b5d7-e5f32721e3d4")},
                new Vouscher(vouscherSeederId2){  UserOperationId = "345", QrCodeKey = "850", QrCodeSecret = "321", DueDate = DateTime.Now, Amount = 1100000, SiteID = Guid.Parse("1434d64c-4901-4adb-9763-b151fc12479a")},
            };

            var VoscherRepository = new VouscherRepository(_dbContext);
            foreach (var vouscherSeed in vouscherSeeds)
            {
                VoscherRepository.Upsert(vouscherSeed, _ => _.Id == vouscherSeed.Id, true);
            }
            #endregion //DEVICESEEDER

        }
    }
}
