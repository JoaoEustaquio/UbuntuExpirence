using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.domain.Entities;

namespace qodeless.DataManager.Seeds
{
    public class DeviceSeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {
          

            #region DEVICESEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var deviceSeederId1 = Guid.Parse("b36de63b-a745-40bf-bd0b-7d6b56e81d64");
            var deviceSeederId2 = Guid.Parse("bbdf1f54-ec40-4385-9cf9-2d4fd5af4fcb");
            var deviceSeeds = new List<Device>() {
                new Device(deviceSeederId1){Code = "C124", SerialNumber = "SN723", Status = EDeviceStatus.Actived, MacAddress ="00:E0:4C:7D:9C:B2"},
                new Device(deviceSeederId2){Code = "C126", SerialNumber = "SN727", Status = EDeviceStatus.Actived, MacAddress = "00:E0:4C:1A:45:C2" }
            };

            var deviceRepository = new DeviceRepository(_dbContext);
            foreach (var deviceSeed in deviceSeeds)
            {
                deviceRepository.Upsert(deviceSeed, _ => _.Id == deviceSeed.Id, true);
            }
            #endregion //DEVICESEEDER

        }
    }
}
