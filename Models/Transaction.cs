namespace PaymentGatewayAPI.Models
{
    public class Transaction
    {

        //Comment set after pulling azure-pipelines.yaml
        public System.Guid Id {get; set;} 
        public virtual System.Guid MerchantId {get; set;}     
        public virtual Merchant Merchant{get;set;}
        public int BankId {get; set;}
        public virtual Bank Bank{get;set;}
        public string Currency {get; set;}
        public string CardType {get; set;}
        public string CardNumber{get; set;}
        public string NameOnCard{get; set;}
        public string ExpiryMonth{get; set;}
        public int ExpiryYear{get; set;}
        public int CVV{get; set;}
        public float Amount{get; set;}
        public System.Guid BankResponseId{get; set;}
        public string BankResponse{get; set;}
        public string Status{get;set;}
    }

    public class TransactionRepresenter
    {

        //Comment set after pulling azure-pipelines.yaml
        public virtual System.Guid MerchantId {get; set;}     
        public int BankId {get; set;}
        public string Currency {get; set;}
        public string CardType {get; set;}
        public string CardNumber{get; set;}
        public string NameOnCard{get; set;}
        public string ExpiryMonth{get; set;}
        public int ExpiryYear{get; set;}
        public int CVV{get; set;}
        public float Amount{get; set;}
    }
    
}