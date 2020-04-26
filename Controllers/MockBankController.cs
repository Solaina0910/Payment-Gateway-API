using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGatewayAPI.Models;

namespace PaymentGatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockBankController : ControllerBase
    {
        public static BankResponse ProcessTransaction(MockBank mockbank)
        {
            var response = new BankResponse();
            int i = 0;

            response.Response = "Successful";
            response.Status = "Successful";

            if (!(mockbank.CVV.ToString().Length == 3)){
                response.Response = "Security Breach";
                response.Status = "Failed";}

            if (mockbank.Amount > 100000){
                response.Response = "Not enough fund";
                response.Status = "Failed";
            }
                
            if (!(mockbank.CardNumber.Length == 12) && (int.TryParse(mockbank.CardNumber, out i) == true)){
                response.Response = "Invalid Card Number";
                response.Status = "Failed";
            }
                
            if (mockbank.ExpiryYear < DateTime.Now.Year){
                response.Response = "Card has expired";
                response.Status = "Failed";
            }
                
            if ((mockbank.ExpiryYear == DateTime.Now.Year) && (Int32.Parse(mockbank.ExpiryMonth) < DateTime.Now.Month)){
                response.Response = "Card has expired";
                response.Status = "Failed";
            }

            response.Id = Guid.NewGuid();

            return response;
        }

    }
}