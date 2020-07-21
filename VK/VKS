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

        public DTOVaultKeep Get(int id)
        {
            DTOVaultKeep exists = _repo.GetById(id);
            if (exists == null)
            {
                throw new Exception("Invalid VaultKeep Id");
            }
            return exists;
        }

        public IEnumerable<VaultKeep> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }

        public DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
        {
            int id = _repo.Create(newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        public DTOVaultKeep Delete(int id)
        {
            DTOVaultKeep exists = Get(id);
            _repo.Delete(id);
            return exists;
        }

        internal IEnumerable<VaultKeep> Get()
        {
            return _repo.GetAll();
        }
    }
}