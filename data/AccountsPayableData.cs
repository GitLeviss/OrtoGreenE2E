using System;

namespace OrtoGreenE2E.data
{
    public class AccountPaybleData
    {
        public AccountPaybleData() { }

        public string description { get; set; } = "Electricity Bill";
        public string value { get; set; } = "150.00";
        public string type { get; set; } = "Utilities";
        public string category { get; set; } = "Bills";
        public string paidDate { get; set; } = "15";
        public string successMessage { get; set; } = "Conta a pagar criada com sucesso";
    }
}