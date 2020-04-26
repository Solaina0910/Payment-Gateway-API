using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGatewayAPI.Models;

namespace PaymentGatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly PaymentGatewayContext _context;

        public BanksController(PaymentGatewayContext context)
        {
            _context = context;
        }

        //GET   api/banks
        [HttpGet]
        public ActionResult<IEnumerable<Bank>> GetBanks()
        {
            return _context.Banks;
        }

        //GET:      api/banks/n
        [HttpGet("{id}")]
        
        public ActionResult<Bank> GetBank(int id)
        {
            var bank = _context.Banks.Find(id);

            if (bank == null)
            {
                return NotFound();
            }

            return bank;
        }
        
        //POST:     api/banks
        [HttpPost]
        public ActionResult<Bank> PostBank(BankRepresenter bankRepresenter)
        {
            var bank = new Bank();
            bank.Name = bankRepresenter.Name;
            bank.Active = bankRepresenter.Active;
            
            _context.Banks.Add(bank);
            _context.SaveChanges();

            return CreatedAtAction("GetBank", new Bank{Id = bank.Id}, bank);
        }

        //PUT:      api/banks/n
        [HttpPut("{id}")]
        public ActionResult PutBank(int id, Bank bank)
        {
            if (id != bank.Id)
            {
                return BadRequest();
            }

            _context.Entry(bank).State = EntityState.Modified;
            _context.SaveChanges();

            return CreatedAtAction("GetBank", new Bank{Id = bank.Id}, bank);
        }

        //DELETE:   api/banks/n
        [HttpDelete("{id}")]
        public ActionResult<Bank> DeleteCommandItem(int id)
        {
            var bank = _context.Banks.Find(id);

            if (bank == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(bank);
            _context.SaveChanges();

            return bank;
        }

    }
}