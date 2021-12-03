using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using qodeless.application.ViewModels;
using qodeless.domain.Entities;

namespace qodeless.application
{
    public interface IAccountAppService : IDisposable
    {
        Task<IEnumerable<AccountViewModel>> GetAll();
        Task<AccountViewModel> GetById(Guid id);
        Task<IEnumerable<AccountViewModel>> GetAllBy(Func<Account, bool> exp);
        Task<ValidationResult> Add(AccountViewModel vm);
        Task<ValidationResult> Update(AccountViewModel vm);     
        Task<ValidationResult> UpdateBlockAccount(Guid id);
        Task<ValidationResult> UpdateUnlockAccount(Guid id);
        Task<ValidationResult> Remove(Guid id);
    }
}