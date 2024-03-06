using HUG.CRUDv2.Services;
using NFTAuctionPlatform.Repository.Models;
using NFTAuctionPlatform.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTAuctionPlatform.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
       

        public ResponseModel CreateAccount(string walletAddress)
        {
            if (_accountRepository.IsExists(walletAddress)) return  new ResponseModel(422, "Account was already exist");

            var newAccount = new Account();
            newAccount.WalletAddress = walletAddress;
            newAccount.Name = walletAddress;
            newAccount.Avatar = "user.png";
            newAccount.Cover = "cover_default.png";
            if (!_accountRepository.Create(newAccount))
            {
                return new ResponseModel(500, "Something went wrong while creating account");
            }

            return new ResponseModel(201, "Successfully created");
        }

        public ResponseModel DeleteAccount(int accountId)
        {
            if (!_accountRepository.IsExists(accountId)) return new ResponseModel(404, "Not found");
            var accountToDelete = _accountRepository.GetById(accountId);
            if (!_accountRepository.Delete(accountToDelete))
            {
                return new ResponseModel(500, "Something went wrong when deleting Role");
            }
            return new ResponseModel(204, "");
        }

        public Account? GetAccount(int accountId)
        {
            if (!_accountRepository.IsExists(accountId)) return null;
            var account = _accountRepository.GetById(accountId);
            return account;
        }

        public Account? GetAccount(string walletAddress)
        {
            if (!_accountRepository.IsExists(walletAddress)) return null;
            var account = _accountRepository.GetAccount(walletAddress);
            return account;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAll();
        }

        public ResponseModel UpdateRole(int accountId, Account updatedAccount)
        {
            if (!_accountRepository.IsExists(accountId)) return new ResponseModel(404, "Not found");
            if (!_accountRepository.Update(updatedAccount))
            {
                return new ResponseModel(500, "Something went wrong updating Account");
            }
            return new ResponseModel(204, "");
        }

        public ResponseModel UpdateActiveStatus(int accountId, bool status)
        {
            if (!_accountRepository.IsExists(accountId)) return new ResponseModel(404, "Not found");
            var updatedRole = _accountRepository.GetById(accountId);
            updatedRole.IsActive = status;
            if (!_accountRepository.Update(updatedRole))
            {
                return new ResponseModel(500, "Something went wrong when change delete status Account");
            }
            return new ResponseModel(204, "");
        }

        public IEnumerable<Account> Search(string field, string keyWords)
        {
            if (keyWords == "null") return _accountRepository.GetAll();
            var res = _accountRepository.Search(field, keyWords);
            if (res == null) return new List<Account>();
            return res;
        }

        public int GetTotal()
        {
            return _accountRepository.GetAll().Where(x => x.IsActive == true).Count();
        }
    }
}
