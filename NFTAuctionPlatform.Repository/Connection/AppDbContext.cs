using Microsoft.EntityFrameworkCore;
using NFTAuctionPlatform.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<NFT> NFTs { get; set; }
        public DbSet<NFTCategory> NFTCategories { get; set; }
        public DbSet<Account_NFT> Account_NFTs { get; set; }
        public DbSet<NFT_NFTCategory> NFT_NFTCategories { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
