using AutoMapper;
using FluentValidation.Results;
using qodeless.application.ViewModels;
using qodeless.domain.Entities;
using qodeless.domain.Interfaces.Repositories;
using qodeless.domain.Validators;
using qodeless.services.api.SysCobrancaClient.Managers.Zenvia;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qodeless.application
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _AccountRepository;
        public AccountAppService(IMapper mapper, IAccountRepository AccountRepository)
        {
            _mapper = mapper;
            _AccountRepository = AccountRepository;
        }
        public async Task<ValidationResult> UpdateBlockAccount(Guid id)
        {
            var entity = _AccountRepository.GetById(id);
            var validationResult = new AccountUpdateValidator().Validate(entity);
            if (validationResult.IsValid)
            {
                _AccountRepository.UpdateBlockAccount(entity);

                if (validationResult.Errors.Count == 0)
                {
                    //SendSms or Whatsapp notification

                }
            }

            return validationResult;
        }

        public async Task<ValidationResult> UpdateUnlockAccount(Guid id)
        {
            var entity = _AccountRepository.GetById(id);
            var validationResult = new AccountUpdateValidator().Validate(entity);
            if (validationResult.IsValid)
            {
                _AccountRepository.UpdateUnlockAccount(entity);

                if (validationResult.Errors.Count == 0)
                {
                    //SendSms or Whatsapp notification
                }
            }

            return validationResult;

        }
        public async Task<IEnumerable<AccountViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AccountViewModel>>(_AccountRepository.GetAll());
        }

        public async Task<AccountViewModel> GetById(Guid id)
        {
            return _mapper.Map<AccountViewModel>(_AccountRepository.GetById(id));
        }

        public async Task<IEnumerable<AccountViewModel>> GetAllBy(Func<Account, bool> exp)
        {
            return _mapper.Map<IEnumerable<AccountViewModel>>(_AccountRepository.GetAllBy(exp));
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var entity = _AccountRepository.GetById(id);
            var validationResult = new AccountRemoveValidator().Validate(entity);
            if (validationResult.IsValid)
                _AccountRepository.SoftDelete(entity);

            return validationResult;
        }
        public async Task<ValidationResult> Add(AccountViewModel vm)
        {
            var entity = _mapper.Map<Account>(vm);
            var validationResult = new AccountAddValidator().Validate(entity);
            if (validationResult.IsValid)
                _AccountRepository.Add(entity);

            if(validationResult.Errors.Count == 0)
            {
                WhatsappSenderManager.SendWhatsapp( "5511945464365", "Jogo bloqueado! ");
            }

            return validationResult;
        }
        public async Task<ValidationResult> Update(AccountViewModel vm)
        {
            var entity = _mapper.Map<Account>(vm);
            var validationResult = new AccountUpdateValidator().Validate(entity);
            if (validationResult.IsValid)
                _AccountRepository.Update(entity);

            return validationResult;
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
