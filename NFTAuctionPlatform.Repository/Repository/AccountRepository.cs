
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
        public bool IsExists(string WalletAddress)
        {
            var user = _dbContext.Accounts.SingleOrDefault(a =>
                a.WalletAddress == WalletAddress
            );
            return user != null;
        }

        public Account GetAccount(string WalletAddress)
        {
            return _dbContext.Accounts.SingleOrDefault(a =>
                a.WalletAddress == WalletAddress
            );
        }
    }
}
