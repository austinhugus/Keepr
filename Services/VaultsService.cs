using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public Vault GetById(int id, string userId)
        {
            var foundVault = Get(id);
            if (foundVault.UserId != userId)
            {
                throw new Exception("Ah ah ah, you didn't say the magic word");
            }
            return _repo.GetById(id, userId);
        }
        public Vault Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Vault> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }



        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal string Delete(int id, string userId)
        {
            Vault foundVault = Get(id);
            if (foundVault.UserId != userId)
            {
                throw new Exception("This is not your vault");
            }
            if (_repo.Delete(id, userId))
            {
                return "Successfully deleted";
            }
            throw new Exception("Not Successfully Deleted");
        }

    }
}