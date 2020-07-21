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
            string sql = @"
            SELECT 
            v.*,
            vk.id as vaultkeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k on k.id = vk.keepId
            WHERE userId = @userId;";
            return _db.Query<VaultKeep>(sql, new { userId });
        }

        internal DTOVaultKeep Get(int id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
            return (DTOVaultKeep)_db.Query<DTOVaultKeep>(sql);
        }

        internal DTOVaultKeep GetById(int id)
        {
            string sql = @"
            SELECT * FROM vaultkeeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { id });
        }



        internal IEnumerable<VaultKeep> GetKeepsByVaultId(int vaultId, string userId)
        {
            string sql = @"SELECT 
            k.*,
            vk.id as vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            return _db.Query<VaultKeep>(sql, new { vaultId, userId });
        }


        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps where id = @Id AND userId= @UserId";
            _db.Execute(sql, new { id });
        }

        internal int Create(DTOVaultKeep newDTOVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (userId, vaultId, keepId)
            VALUES
            (@UserId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newDTOVaultKeep);
        }


    }
}