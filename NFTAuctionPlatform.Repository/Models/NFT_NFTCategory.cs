using HUG.CRUDv2.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Models
{
    [Table("tNFT_NFTCategory")]
    public class NFT_NFTCategory : BaseModel
    {
        public int NftId { get; set; }
        public int NftCategoryId { get; set; }
    }
}
