using qodeless.domain.Entities;

namespace qodeless.domain.Interfaces.Repositories
{
    public interface IAccountRepository : IRepository<Account> //SOLID
    {
        public bool UpdateBlockAccount(Account obj, bool bCommit = true)
        {
            obj.Status = domain.Enums.EAccountStatus.Blocked;
            return Update(obj, bCommit);
        }
        public bool UpdateUnlockAccount(Account obj, bool bCommit = true)
        {
            obj.Status = domain.Enums.EAccountStatus.Actived;
            return Update(obj, bCommit);
        }

    }
}
