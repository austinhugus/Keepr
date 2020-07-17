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

        }

        internal object GetById (int id) {

        }

        internal object Edit (Keep keepToUpdate, string userId) {

        }

        internal object Delete (int id, string userId) {

        }
    }
}