using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.data
{
    public class PatientsData
    {
        public string PatientName { get; set; } = "Paciente Testes";
        public string Email { get; set; } = "emailteste@email.com";
        public string Phone { get; set; } = "(11) 9341-25767";
        public string BirthDate { get; set; } = "29/01/2003";
        public string CEP { get; set; } = "06240090";
        public string Street { get; set; } = "Rua pariquera açu";
        public string Number { get; set; } = "127";
        public string Complement { get; set; } = "casa";
        public string Neighborhood { get; set; } = "Munhoz Junior";
        public string City { get; set; } = "Osasco";
        public string State { get; set; } = "São Paulo";
        public string Observation { get; set; } = "apenas testando";
    }
}