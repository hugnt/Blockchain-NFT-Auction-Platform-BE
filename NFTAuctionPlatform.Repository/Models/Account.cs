using HUG.CRUDv2.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Models
{
    [Table("tAccount")]
    public class Account : BaseModel
    {
        [Column("wallet_address")]
        public string WalletAddress { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
        public string? Cover { get; set; }
        public int? Followers { get; set; }
        public int? Following { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Twitter { get; set; }
        public string? Telegram { get; set; }

    }
}
