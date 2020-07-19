using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Keepr.Models;

namespace keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        public VaultKeep Get(int id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            return (IEnumerable<VaultKeepViewModel>)_repo.GetKeepsByVaultId(vaultId, userId);
        }

        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _repo.Create(newVaultKeep);
        }

        internal IEnumerable<VaultKeep> Get()
        {
            return _repo.Get();
        }

        internal string Delete(int id, string userId)
        {
            VaultKeep foundVaultKeep = Get(id);
            if (foundVaultKeep.UserId != userId)
            {
                throw new Exception("Can't delete this vaultKeep");
            }
            if (_repo.Delete(id, userId))
            {
                return "Successfully deleted";
            }
            throw new Exception("Not Successfully Deleted");
        }
    }
}