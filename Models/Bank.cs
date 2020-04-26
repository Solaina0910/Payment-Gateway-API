namespace PaymentGatewayAPI.Models
{
    public class Bank
    {

        //Comment set after pulling azure-pipelines.yaml

        public int Id {get; set;}
        public string Name {get; set;}
        public bool Active {get; set;}
    }

    public class BankRepresenter
    {

        //Comment set after pulling azure-pipelines.yaml
        public string Name {get; set;}
        public bool Active {get; set;}
    }
}