using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services {
    public class KeepsService {
        private readonly KeepsRepository _repo;
        public KeepsService (KeepsRepository repo) {
            _repo = repo;
        }
        public IEnumerable<Keep> Get () {
            return _repo.Get ();
        }

        public Keep Create (Keep newKeep) {
            return _repo.Create (newKeep);
        }

        internal object GetByUserId (string userId) {
            return _repo.GetKeepsByUserId (userId);
        }

        internal Keep GetById (int id) {
            Keep foundKeep = _repo.GetById (id);
            if (foundKeep == null) {
                throw new Exception ("Invalid Id");
            }
            return foundKeep;
        }

        internal Keep Edit (Keep keepToUpdate, string userId) {
            Keep foundKeep = GetById (keepToUpdate.Id);
            if (_repo.ViewKeep (keepToUpdate)) {
                foundKeep.Views = keepToUpdate.Views;
                return foundKeep;
            }
            if (_repo.ShareKeep (keepToUpdate.Id)) {
                foundKeep.Shares = keepToUpdate.Keeps;
                return foundKeep;
            }
            if (foundKeep.UserId == userId && _repo.Edit (keepToUpdate, userId)) {
                return keepToUpdate;
            }
            throw new Exception ("Can't share your own Post");

        }

        internal string Delete (int id, string userId) {
            Keep foundKeep = GetById (id);
            if (foundKeep.UserId != userId) {
                throw new Exception ("This is not your car!");
            }
            if (_repo.Delete (id, userId)) {
                return "Successfully deleted";
            }
            throw new Exception ("Not Successfully Deleted");
        }
    }
}