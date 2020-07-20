using System;
using System.Data;
using keepr.Models;
using Dapper;
using System.Collections.Generic;
using Keepr.Models;

namespace keepr.Repositories
{
    public class VaultKeepsRepository
    {
        public readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<VaultKeep> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id AND userId = @userId";
            return _db.Query<VaultKeep>(sql, new { userId });
        }
        internal VaultKeep GetById(int id)
        {
            string sql = @"
            SELECT * FROM vaultkeeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        public IEnumerable<VaultKeep> GetKeepsByVaultId(int vaultId, string userId)
        {
            string sql = @"SELECT 
            k.*,
            vk.id as vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            return _db.Query<VaultKeep>(sql, new { vaultId, userId });
        }

        internal IEnumerable<VaultKeep> Get()
        {
            string sql = @"
            SELECT * FROM vaultkeeps";
            return _db.Query<VaultKeep>(sql);
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();";
            newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            return newVaultKeep;
        }

        public bool Delete(int id, string userId)
        {
            string sql = @"
            DELETE FROM vaultkeeps WHERE id = @Id AND userId = @UserId";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;


        }
    }
}