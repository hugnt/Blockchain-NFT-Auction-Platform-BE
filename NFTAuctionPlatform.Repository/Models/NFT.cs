using HUG.CRUDv2.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Models
{
    [Table("tNFT")]
    public class NFT : BaseModel
    {
        public string PolicyId { get; set; }
        public string? Name { get; set; }
        public int? Likes { get; set; }
        public int? Status { get; set; }
    }
}
