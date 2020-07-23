using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }
        internal object GetByUserId(string userId)
        {
            return _repo.GetKeepsByUserId(userId);
        }
        internal Keep GetById(int id)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            if (foundKeep.IsPrivate == true && foundKeep.UserId == foundKeep.UserId)
            {
                throw new Exception("Can't get this man!");
            }
            return foundKeep;
        }

        internal Keep Edit(Keep editKeep, string userId)
        {
            Keep foundKeep = GetById(editKeep.Id);
            if (foundKeep.Views < editKeep.Views)
            {
                if (_repo.viewKeep(editKeep))
                {
                    foundKeep.Views = editKeep.Views;
                    return foundKeep;
                }
                throw new Exception("You can't view that Keep");
            }
            if (foundKeep.Keeps < editKeep.Keeps)
            {
                if (_repo.keepKeep(editKeep))
                {
                    foundKeep.Keeps = editKeep.Keeps;
                    return foundKeep;
                }
                throw new Exception("You can't keep that Keep");
            }
            if (foundKeep.UserId == userId && _repo.Edit(editKeep, userId))
            {
                return editKeep;
            }
            throw new Exception("Can't edit that keep");

        }

        internal string Delete(int id, string userId)
        {
            Keep foundKeep = GetById(id);
            if (foundKeep.UserId != userId)
            {
                throw new Exception("This is not your keep!");
            }
            if (_repo.Delete(id, userId))
            {
                return "Successfully deleted";
            }
            throw new Exception("Not Successfully Deleted");
        }

    }
}