using HUG.CRUDv2.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Models
{
    [Table("tAccount_NFT")]
    public class Account_NFT : BaseModel
    {
        public int AccountId { get; set; }
        public int NftId { get; set; }
        public int Likes { get; set; }
        public int Votes { get; set; }
        public bool? IsAuthor { get; set; }
        public bool? WasAuthor { get; set; }
    }
}
