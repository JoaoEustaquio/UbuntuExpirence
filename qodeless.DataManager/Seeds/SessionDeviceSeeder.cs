using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.domain.Entities;

namespace qodeless.DataManager.Seeds
{
    public class SessionDeviceSeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {


            #region SESSIONDEVICESEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var sessiondeviceId1 = Guid.Parse("db68d210-72f5-4a08-abb5-06e346bb65b1");
            var sessiondeviceId2 = Guid.Parse("9af34e2b-692c-4d50-a103-52adb450f491");
            var SessionDeviceSeeds = new List<SessionDevice>() {
                new SessionDevice(sessiondeviceId1){UserPlayId = "db68d210-72f5-4a08-abb5-06e346bb65b1", DtBegin = DateTime.Now, DtEnd = DateTime.Now},
                new SessionDevice(sessiondeviceId2){UserPlayId = "9af34e2b-692c-4d50-a103-52adb450f491",DtBegin = DateTime.Now, DtEnd = DateTime.Now }
            };

            var sessiondeviceRepository = new SessionDeviceRepository(_dbContext);
            foreach (var SessionDeviceSeed in SessionDeviceSeeds)
            {
                sessiondeviceRepository.Upsert(SessionDeviceSeed, _ => _.Id == SessionDeviceSeed.Id, true);
            }
            #endregion //SESSIONDEVICESEEDER

        }
    }
}
