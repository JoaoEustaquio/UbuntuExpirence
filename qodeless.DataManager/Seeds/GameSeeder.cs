using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.domain.Entities;

namespace qodeless.DataManager.Seeds
{
    public class GameSeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {
          

            #region DEVICESEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var gameSeederId1 = Guid.Parse("d83366e3-9257-4bb1-b133-cc4a367dc183");
            var gameSeederId2 = Guid.Parse("e5df679d-f0e1-4a2e-959e-1df8aea1365c");
            var gameSeeds = new List<Game>() {
                new Game(gameSeederId1){ Code = EGameCode.FreePlay, DtPublish = DateTime.Now, Status = EGameStatus.Actived, Version = "old" },
                new Game(gameSeederId2){  Code = EGameCode.Patinko, DtPublish = DateTime.Now, Status = EGameStatus.Actived,Version = "old", }
            };

            var gameRepository = new GameRepository(_dbContext);
            foreach (var gameSeed in gameSeeds)
            {
                gameRepository.Upsert(gameSeed, _ => _.Id == gameSeed.Id, true);
            }
            #endregion //DEVICESEEDER

        }
    }
}
