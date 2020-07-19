using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Vault> GetById(int id, string userId)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id AND userId = @userId";
            return _db.Query<Vault>(sql, new { id, userId });
        }

        internal IEnumerable<Vault> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id AND userId = @userId";
            return _db.Query<Vault>(sql, new { userId });
        }

        internal Vault Get(int id)
        {
            string sql = @"
            SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }

        internal Vault Create(Vault vaultInfo)
        {
            string sql = @"
            INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
            vaultInfo.Id = _db.ExecuteScalar<int>(sql, vaultInfo);
            return vaultInfo;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaults WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}