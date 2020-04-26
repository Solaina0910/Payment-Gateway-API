namespace PaymentGatewayAPI.Models
{
    public class MockBank
    {
        public string CardType {get; set;}
        public string CardNumber{get; set;}
        public string NameOnCard{get; set;}
        public string ExpiryMonth{get; set;}
        public int ExpiryYear{get; set;}
        public int CVV{get; set;}
        public float Amount{get; set;}
    }
    
}