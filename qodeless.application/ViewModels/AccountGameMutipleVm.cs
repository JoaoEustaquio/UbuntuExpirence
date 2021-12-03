using System;
using System.Collections.Generic;

namespace qodeless.application.ViewModels
{
    public class AccountGameMutiplevm
    {
        public AccountGameMutiplevm()
        {
        }

        public AccountGameMutiplevm(Guid id)
        {
            Id = id;
        }

        public Guid Account { get; set; }

        public List<Guid> GameIds { get; set; }
        public Guid Id { get; }
    }
}
