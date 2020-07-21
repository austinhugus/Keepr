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

        public DTOVaultKeep Get(int id, string userId)
        {
            DTOVaultKeep exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid vaultKeepid"); }
            return exists;

        }

        public IEnumerable<VaultKeep> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }

        internal IEnumerable<VaultKeep> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        public DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
        {
            int id = _repo.Create(newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        internal VaultKeep Get(int id)
        {
            throw new NotImplementedException();
        }

        public DTOVaultKeep Delete(string userId, int id)
        {
            DTOVaultKeep exists = Get(id, userId);
            _repo.Delete(id);
            return exists;
        }
    }
}