using HUG.CRUDv2.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Models
{
    [Table("tFounder")]
    public class Founder : BaseModel
    {
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? Company { get; set; }
        public string? Avatar { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Twitter { get; set; }
        public string? Telegram { get; set; }
    }
}
