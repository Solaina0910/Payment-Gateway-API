namespace PaymentGatewayAPI.Models
{
    public class Merchant
    {

        //Comment set after pulling azure-pipelines.yaml

        public System.Guid Id {get; set;}
        public string Name {get; set;}
        public bool Active {get; set;}
    }

    public class MerchantRepresenter
    {

        //Comment set after pulling azure-pipelines.yaml
        public string Name {get; set;}
        public bool Active {get; set;}
    }
}