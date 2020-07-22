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

        public DTOVaultKeep GetById(int id)
        {
            DTOVaultKeep exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid vaultKeepid"); }
            return exists;

        }

        public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }

        internal IEnumerable<VaultKeepViewModel> Get(string userId)
        {
            return _repo.GetByUserId(userId);
        }


        public DTOVaultKeep Create(DTOVaultKeep newDTOVaultKeep)
        {
            return _repo.Create(newDTOVaultKeep);
        }

        public DTOVaultKeep Delete(string userId, int id)
        {
            DTOVaultKeep exists = GetById(id);
            _repo.Delete(id, userId);
            return exists;
        }
    }
}