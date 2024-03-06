
using HUG.CRUDv2.Repository;
using NFTAuctionPlatform.Repository.Connection;
using NFTAuctionPlatform.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Repository.Repository
{
    public class AccountRepository : GenericRepository<Account>
    {
        private readonly AppDbContext _dbContext;
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public bool IsExists(string walletAddress)
        {
            var user = _dbContext.Accounts.Any(a =>
                a.WalletAddress == walletAddress
            );
            return user;
        }

        public Account GetAccount(string walletAddress)
        {
            return _dbContext.Accounts.SingleOrDefault(a =>
                a.WalletAddress ==walletAddress
            );
        }
    }
}
