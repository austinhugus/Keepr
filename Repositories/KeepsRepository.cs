using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories {
    public class KeepsRepository {
        private readonly IDbConnection _db;

        public KeepsRepository (IDbConnection db) {
            _db = db;
        }

        internal IEnumerable<Keep> Get () {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep> (sql);
        }

        internal Keep Create (Keep newKeep) {
            string sql = @"
            INSERT INTO keeps
            ()
            
            
            "
        }

        internal object GetKeepsByUserId (string userId) {

        }

        internal Keep GetById (int id) {

        }

        internal bool ViewKeep (Keep keepToUpdate) {

        }

        internal bool ShareKeep (int id) {

        }

        internal bool Edit (Keep keepToUpdate, string userId) {

        }

        internal bool Delete (int id, string userId) {

        }
    }
}