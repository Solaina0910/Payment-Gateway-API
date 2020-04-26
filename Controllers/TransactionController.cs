using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGatewayAPI.Models;
using System.Linq;

namespace PaymentGatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly PaymentGatewayContext _context;

        public TransactionsController(PaymentGatewayContext context)
        {
            _context = context;
        }

        //GET   api/transactions
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetTransactions()
        {
            foreach (var transaction in _context.Transactions){
            var merchant = _context.Merchants.Find(transaction.MerchantId);
            transaction.Merchant = merchant;

            var bank = _context.Banks.Find(transaction.BankId);
            transaction.Bank = bank;
            }

            return _context.Transactions;
        }

        //GET:      api/transactions/n
        [HttpGet]
        [Route("GetTransactionByTransactionId")]
        
        public ActionResult<Transaction> GetTransactionByTransactionId(System.Guid transactionId)
        {           
            var transaction = _context.Transactions.Find(transactionId);
            

            if (transaction == null)
            {
                return NotFound();
            }

            var merchant = _context.Merchants.Find(transaction.MerchantId);          
            transaction.Merchant = merchant;

            var bank = _context.Banks.Find(transaction.BankId);
            transaction.Bank = bank;

            return transaction;
        }

         //GET   api/transactions/merchantId
        [HttpGet]
        [Route("GetTransactionsByMerchantId")]
        public IQueryable<Transaction> GetTransactionsByMerchantId(System.Guid merchantId)
        {
            var transactions = _context.Transactions          
            .Where(t => t.MerchantId == merchantId);

            foreach (var transaction in transactions){
            var merchant = _context.Merchants.Find(transaction.MerchantId);           
            transaction.Merchant = merchant;

            var bank = _context.Banks.Find(transaction.BankId);
            transaction.Bank = bank;
            
            transaction.CardNumber = transaction.CardNumber.Substring(transaction.CardNumber.Length - 4).PadLeft(transaction.CardNumber.Length, '*');
            }


            return transactions;
        }
       
        //POST:     api/transactions
        [HttpPost]
        [Route("ProcessTransaction")]
        public ActionResult<Transaction> ProcessTransaction(TransactionRepresenter transactionRepresenter)
        {
            var transaction = new Transaction();
            transaction.MerchantId = transactionRepresenter.MerchantId;
            transaction.BankId = transactionRepresenter.BankId;
            transaction.Currency = transactionRepresenter.Currency;
            transaction.CardType = transactionRepresenter.CardType;
            transaction.CardNumber = transactionRepresenter.CardNumber;
            transaction.NameOnCard = transactionRepresenter.NameOnCard;
            transaction.ExpiryMonth = transactionRepresenter.ExpiryMonth;
            transaction.ExpiryYear = transactionRepresenter.ExpiryYear;
            transaction.CVV = transactionRepresenter.CVV;
            transaction.Amount = transactionRepresenter.Amount;

            var merchant = _context.Merchants.Find(transaction.MerchantId);
            var bank = _context.Banks.Find(transaction.BankId);

            if (merchant is null)
            {
                return NotFound("Merchant not found!");
            }

            if (bank is null)
            {
                return NotFound("Bank not found!");
            }

            var mockBank = new MockBank();
            mockBank.CardType = transaction.CardType;
            mockBank.CardNumber = transaction.CardNumber;
            mockBank.NameOnCard = transaction.NameOnCard;
            mockBank.ExpiryMonth = transaction.ExpiryMonth;
            mockBank.ExpiryYear = transaction.ExpiryYear;
            mockBank.CVV = transaction.CVV;
            mockBank.Amount = transaction.Amount;

            var bankresponse = new BankResponse();
            bankresponse = MockBankController.ProcessTransaction(mockBank);

            transaction.BankResponseId = bankresponse.Id;
            transaction.BankResponse = bankresponse.Response;
            transaction.Status = bankresponse.Status;

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction;

        }

    }
}