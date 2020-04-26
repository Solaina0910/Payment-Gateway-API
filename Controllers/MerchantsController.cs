using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGatewayAPI.Models;

namespace PaymentGatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly PaymentGatewayContext _context;

        public MerchantsController(PaymentGatewayContext context)
        {
            _context = context;
        }

        //GET   api/merchants
        [HttpGet]
        public ActionResult<IEnumerable<Merchant>> GetMerchants()
        {
            return _context.Merchants;
        }

        //GET:      api/merchants/n
        [HttpGet("{id}")]
        
        public ActionResult<Merchant> GetMerchant(System.Guid id)
        {
            var merchant = _context.Merchants.Find(id);

            if (merchant == null)
            {
                return NotFound();
            }

            return merchant;
        }
        
        //POST:     api/merchants
        [HttpPost]
        public ActionResult<Merchant> PostMerchant(MerchantRepresenter merchantRepresenter)
        {
            var merchant = new Merchant();
            merchant.Name = merchantRepresenter.Name;
            merchant.Active = merchantRepresenter.Active;
            
            _context.Merchants.Add(merchant);
            _context.SaveChanges();

            return CreatedAtAction("GetMerchant", new Merchant{Id = merchant.Id}, merchant);
        }

        //PUT:      api/merchants/n
        [HttpPut("{id}")]
        public ActionResult PutMerchant(System.Guid id, Merchant merchant)
        {
            if (id != merchant.Id)
            {
                return BadRequest();
            }

            _context.Entry(merchant).State = EntityState.Modified;
            _context.SaveChanges();

            return CreatedAtAction("GetMerchant", new Merchant{Id = merchant.Id}, merchant);
        }

        //DELETE:   api/merchants/n
        [HttpDelete("{id}")]
        public ActionResult<Merchant> DeleteCommandItem(System.Guid id)
        {
            var merchant = _context.Merchants.Find(id);

            if (merchant == null)
            {
                return NotFound();
            }

            _context.Merchants.Remove(merchant);
            _context.SaveChanges();

            return merchant;
        }

    }
}