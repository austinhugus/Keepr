using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Keepr.Models;

namespace keepr.Models
{
    public class DTOVaultKeep
    {

        public int Id { get; set; }

        public string UserId { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }

    }

}