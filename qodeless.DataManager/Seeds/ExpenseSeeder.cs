using qodeless.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using qodeless.domain.Enums;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.domain.Entities;

namespace qodeless.DataManager.Seeds
{
    public class ExpenseSeeder
    {
        public static void Seed(ApplicationDbContext _dbContext)
        {


            #region EXPENSESEEDER
            //PARA GERAR UM NOVO GUID: ACESSE ==> https://www.guidgenerator.com/online-guid-generator.aspx
            var expenseSeederId1 = Guid.Parse("e915e741-d068-4e02-8b2c-45f2a7e2d3ae");
            var expenseSeederId2 = Guid.Parse("4bc6e874-d8a7-4c36-bfd3-b110f917f5fd");
            var expenseSeeds = new List<Expense>() {
                new Expense(expenseSeederId1){SiteId = SiteSeeder.siteId1, Amount=300.0, DueDate= DateTime.Now, Note= "", Status= EExpenseStatus.Approved},
                new Expense(expenseSeederId2){SiteId = SiteSeeder.siteId1, Amount=300.0, DueDate= DateTime.Now, Note= "", Status= EExpenseStatus.Approved}
            };

            var ExpenseRepository = new ExpenseRepository(_dbContext);
            foreach (var expenseSeed in expenseSeeds)
            {
                ExpenseRepository.Upsert(expenseSeed, _ => _.Id == expenseSeed.Id, true);
            }
            #endregion //EXPENSESEEDER

        }
    }
}

