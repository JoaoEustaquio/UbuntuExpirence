using qodeless.DataManager.Seeds;
using qodeless.domain.Entities;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace qodeless.DataManager
{
    public class CoreDataManager : DataManager
    {
  
        public override void Seed() => InjectAllData();
        

        public async void InjectAllData()
        {
            //AccountSeeder.Seed(_dbContext);
            //SuccessFeeSeeder.Seed(_dbContext);
            DeviceSeeder.Seed(_dbContext);

            #region User
            ////_dbContext.Users.Add(new ApplicationUser()
            ////{
            ////    Id = "8657ed68-761d-4c76-85b1-56cba8355667",
            ////    Email = "ubuntu@ubuntu.com",
            ////    UserName = "ubuntu@ubuntu.com",
            ////    NormalizedEmail = "ubuntu@ubuntu.com".ToUpper(),
            ////    NormalizedUserName = "ubuntu@ubuntu.com".ToUpper(),
            ////    Enabled = true,
            ////    LockoutEnabled = false,
            ////    CreationDate = DateTime.Now,
            ////    PasswordHash = "AQAAAAEAACcQAAAAEMt88CUmHDTViM5PIWGbGJo6ihljSjCv3HiWEcSze+7Q5uYMsCCqAnTfPdQz0/s/Rw==",
            ////    SecurityStamp = "FQHIGXG57MGW33C2QOHFIA35L6NZ5GSQ"
            ////});

            ////_dbContext.SaveChanges();
            #endregion


            #region GROUPS
            ////var groupCsharp = Guid.Parse("de15f1f7-f826-4e54-b304-80f94e1a852b");
            ////var groupReact = Guid.Parse("6016e53a-3c5e-4a3b-baaf-fd6a7ed389f0");
            ////var groupFigma = Guid.Parse("2d5bc19a-91f1-47aa-981e-4fdfd0c29e43");
            ////var groupUx = Guid.Parse("78a0ff16-dee7-4ec9-99cb-a75091328f67");
            ////var groups = new List<Group>() {
            ////    new Group(groupCsharp){ Code = "C01", Name = "C#", AcceptanceCriteria = 75 },
            ////    new Group(groupReact){ Code = "R02", Name = "REACT", AcceptanceCriteria = 65 },
            ////    new Group(groupFigma){ Code = "F01", Name = "FIGMA", AcceptanceCriteria = 60 },
            ////    new Group(groupUx){ Code = "U01", Name = "UX", AcceptanceCriteria = 55 },
            ////};

            ////var groupRepository = new GroupRepository(_dbContext);

            ////foreach (var group in groups)
            ////{
            ////    groupRepository.Upsert(group, _ => _.Code == group.Code,true);
            ////}
            #endregion //GROUPS

            #region ACCOUNT
            ////MOCK dos dados, ou seja, Dados Fakes
            ////PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            //var accountId1 = Guid.Parse("5f4c8fd4-d41e-48ec-895a-75db1e2eaa05");
            //var accountId2 = Guid.Parse("33bbbb79-767f-4237-b614-37b337bbf984");
            //var accounts = new List<Account>() {
            //    new Account(accountId1){ Name = "RG Digital", Description = "RG Digital", Status = EAccountStatus.Actived},
            //    new Account(accountId2){ Name = "Parceiro", Description = "Parceiro", Status = EAccountStatus.Actived},
            //};

            //var accountRepository = new AccountRepository(_dbContext);
            //foreach (var account in accounts)
            //{
            //    accountRepository.Upsert(account, _ => _.Id == account.Id,true);
            //}
            #endregion //ACCOUNT

            #region SITE
            ////PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            //var siteId1 = Guid.Parse("f1818cb7-544f-476b-b5d7-e5f32721e3d4");
            //var siteId2 = Guid.Parse("1434d64c-4901-4adb-9763-b151fc12479a");
            //var siteId3 = Guid.Parse("afaa9cd1-4816-44d7-8051-6c92b9ad9884");
            //var siteId4 = Guid.Parse("33a236e7-55ef-49fd-b9e3-8dd273d8527f");
            //var sites = new List<Site>() {
            //    new Site(siteId1){ Name = "Cassino RG 1", AccountId = accountId1, Description = "Cassino RG 1", ESiteType = ESiteType.Casino},
            //    new Site(siteId2){ Name = "Cassino RG 2", AccountId = accountId1,Description = "Cassino RG 2", ESiteType = ESiteType.Casino},
            //    new Site(siteId3){ Name = "Cassino WHITE LABEL 1", AccountId = accountId2, Description = "Cassino WHITE LABEL 1", ESiteType = ESiteType.LanHouse},
            //    new Site(siteId4){ Name = "Cassino WHITE LABEL 2", AccountId = accountId2, Description = "Cassino WHITE LABEL 2", ESiteType = ESiteType.Default},
            //};
            //var siteRepository = new SiteRepository(_dbContext);
            //foreach (var site in sites)
            //{
            //    siteRepository.Upsert(site, _ => _.Id == site.Id, true);
            //}
            #endregion //SITE

            #region DEVICE
            //var deviceId1 = Guid.Parse("5d902695-08c3-46fe-81bd-b4d5a29e8de8");
            //var deviceId2 = Guid.Parse("504c313b-496d-4c70-bf3e-ca5b82c65973");
            //var devices = new List<Device>() {
            //     new Device(deviceId1){ Code = "C123", SerialNumber = "SN123", Type = EDeviceType.Cabinet, Status = EDeviceStatus.Actived },
            //    new Device(deviceId2){ Code = "C124", SerialNumber = "SN724", Type = EDeviceType.LanPC, Status = EDeviceStatus.Actived},
            //};
            //var deviceRepository = new DeviceRepository(_dbContext);
            //foreach (var device in devices)
            //{
            //    deviceRepository.Upsert(device, _ => _.Id == device.Id, true);
            //}
            #endregion //DEVICE

            #region SESSIONSITE
            //var sessionSiteId1 = Guid.Parse("5f4c8fd4-d41e-48ec-895a-75db1e2eaa05");
            //var sessionSiteId2 = Guid.Parse("33bbbb79-767f-4237-b614-37b337bbf984");
            //var sessionSiteId3 = Guid.Parse("08f753a7-d2e2-464b-a199-29a814c563c5");
            //var sessionSiteId4 = Guid.Parse("a5c3f1c0-2827-401e-843e-1c9fb068ac4d");
            //var sessionSites = new List<SessionSite>() {
            //    new SessionSite(sessionSiteId1){SiteId = siteId1, UserOperationId = "5f4c8fd4-d41e-48ec-895a-75db1e2eaa05", DtBegin = DateTime.Now, DtEnd=DateTime.Now.AddDays(1), Status = EStatusSessionSite.BusinessDayOpen},
            //    new SessionSite(sessionSiteId2){SiteId = siteId1, UserOperationId = "5f4c8fd4-d41e-48ec-895a-75db1e2eaa05",  DtBegin = DateTime.Now, DtEnd=DateTime.Now.AddDays(2), Status = EStatusSessionSite.BillingClosed},
            //    new SessionSite(sessionSiteId3){SiteId = siteId2, UserOperationId = "5f4c8fd4-d41e-48ec-895a-75db1e2eaa05", DtBegin = DateTime.Now, DtEnd=DateTime.Now.AddDays(1), Status = EStatusSessionSite.BusinessDayOpen},
            //    new SessionSite(sessionSiteId4){SiteId = siteId3, UserOperationId = "5f4c8fd4-d41e-48ec-895a-75db1e2eaa05",  DtBegin = DateTime.Now, DtEnd=DateTime.Now.AddDays(2), Status = EStatusSessionSite.BillingClosed},
            //};
            //var sessionSiteRepository = new SessionSiteRepository(_dbContext);
            //foreach (var sessionSite in sessionSites)
            //{
            //    sessionSiteRepository.Upsert(sessionSite, _ => _.Id == sessionSite.Id, true);
            //}
            #endregion //SESSIONSITE
            #region SESSIONDEVICE

            //var sessionDeviceId1 = Guid.Parse("5f4c8fd4-d41e-48ec-895a-75db1e2eaa05");
            //var sessionDeviceId2 = Guid.Parse("33bbbb79-767f-4237-b614-37b337bbf984");
            //var sessionDevices = new List<SessionDevice>() {
            //    new SessionDevice(sessionDeviceId1){ UserPlayId = "8657ed68-761d-4c76-85b1-56cba8355667", DeviceId = deviceId1, DtBegin = DateTime.Now, DtEnd=DateTime.Now.AddDays(1)},
            //    new SessionDevice(sessionDeviceId2){ UserPlayId = "8657ed68-761d-4c76-85b1-56cba8355667", DeviceId = deviceId2, DtBegin = DateTime.Now, DtEnd=DateTime.Now.AddDays(2) },
            //};

            //var sessionDeviceRepository = new SessionDeviceRepository(_dbContext);
            //foreach (var sessionDevice in sessionDevices)
            //{
            //    sessionDeviceRepository.Upsert(sessionDevice, _ => _.Id == sessionDevice.Id, true);
            //}
            #endregion //SESSIONDEVICE

            #region GAME
            ////PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            //var gameId1 = Guid.Parse("b74df049-6bbb-4f25-aebc-0c38f42e269c");
            //var gameId2 = Guid.Parse("88520a44-3530-4048-ae94-af7f4326ebab");
            //var gameId3 = Guid.Parse("bea527ac-5482-4ae5-91dc-6da018d80fd0");
            //var games = new List<Game>() {
            //    new Game(gameId1){ Code = EGameCode.NineBall, Name = "Nine Ball", Status = EGameStatus.Actived, DtPublish = DateTime.Now },
            //    new Game(gameId2){ Code = EGameCode.ShowBall3, Name = "Show Ball 2", Status = EGameStatus.Actived, DtPublish = DateTime.Now },
            //    new Game(gameId3){ Code = EGameCode.TripleBonus, Name = "Triple Bonus", Status = EGameStatus.Blocked, DtPublish = DateTime.Now },
            //};

            //var gameRepository = new GameRepository(_dbContext);
            //foreach (var game in games)
            //{
            //    gameRepository.Upsert(game, _ => _.Id == game.Id, true);
            //}
            #endregion //GAME

            #region ACCOUNTGAME
            ////PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            //var accountGameId1 = Guid.Parse("da06bf4d-c63a-49c8-9137-391c313e9fc1");
            //var accountGameId2 = Guid.Parse("b5d697af-3e4f-4b76-99a0-bdcfa796748f");
            //var accountsGame = new List<AccountGame>() {
            //    new AccountGame(accountGameId1){ AccountId = accountId1, GameId = gameId1 },
            //    new AccountGame(accountGameId2){ AccountId = accountId2, GameId = gameId2 },
            //};

            //var accountGameRepository = new AccountGameRepository(_dbContext);
            //foreach (var accountGame in accountsGame)
            //{
            //    accountGameRepository.Upsert(accountGame, _ => _.Id == accountGame.Id, true);
            //}
            #endregion //ACCOUNTGAME

        }
    }
}
