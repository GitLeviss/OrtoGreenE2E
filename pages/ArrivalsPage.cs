using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace OrtoGreenE2E.pages
{
    public class ArrivalsPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly ArrivalsData data;

        public ArrivalsPage(IPage page, ArrivalsData data = null)
        {
            this.page = page;
            this.data = data ?? new ArrivalsData();
            utils = new Utils(page);
        }

        string patientName = "User Teste";

        public static string UniqueNumber()
        {
            Random random = new Random();
            int uniqueNumber = random.Next(0, 9999);
            return uniqueNumber.ToString();
        }

        public static string number = UniqueNumber();
        public string Obs { get; } = "Test " + number;




        public async Task ScheduleAppointment()
        {
            string status = "AGENDADA";
            await utils.Click(gen.LocatorSpanText(" Nova Consulta "), "Click on New to create a new schedule");
            await Task.Delay(500);
            await utils.Click(gen.SelectOrder("1"), "Click on first select to select a patient");
            await utils.Click(gen.LocatorDiv(data.PatientName), "Set patient on select patient");
            await utils.Click(gen.SelectOrder("3"), "Click on select to expand dentist");
            await utils.Click(gen.LocatorDiv(data.DentistName), "Set dentist on select patient");
            await utils.Click(gen.SelectOrder("4"), "Click on select to expand type of appointment");
            await utils.Click(gen.LocatorSpanText(data.TypeOfConsult), "Set type of consult on select order");
            await utils.Click(gen.RadioOrder("3"), "select disponibility time");
            //await utils.Write(gen.LocatorPlaceholder("Observações sobre a consulta..."), Obs, "Insert observation");
            await utils.Click(gen.LocatorSpanText(" Salvar Agendamento"), "Click on sabe appointment");
            await utils.ValidateTextIsVisibleOnScreen("Consulta agendada com sucesso!", "Validate if success message is visible on screen of user");
            await utils.ValidateElementIsVisibleOnScreen(gen.StatusOnTable(status), $"Validate if status on table is {status}");
        }

        public async Task ConsultExistingAppointment()
        {

            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "insert patient name on search bar");
            await utils.Click(gen.ButtonExpand("1"), "Click on button to expand data of appointment");
            await utils.ValidateElementIsVisibleOnScreen("("+gen.LocatorSpanText("AGENDADA")+")[1]", "Validate if obs messa is visible on table");

        }

        public async Task Checkin()
        {            
            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            string quantityOfAppointments = await utils.GetTextOfElement(gen.LocatorDiv("Confirmadas") + "/following-sibling::div", "Get quantity of confirm appointments");
            int qtt1 = Convert.ToInt32(quantityOfAppointments);
            await utils.Click("("+gen.LocatorSpanText("Confirmar")+")[1]", "Click on confirm button");
            string quantityOfAppointmentsAfter = await utils.GetTextOfElement(gen.LocatorDiv("Confirmadas") + "/following-sibling::div", "Get quantity of confirm appointments");
            int qtt2 = Convert.ToInt32(quantityOfAppointmentsAfter);
            bool confirm = qtt2 > qtt1;
            if (confirm) 
            {
                Console.WriteLine("Appointment confirmed");
            }
            await utils.Click(gen.LocatorSpanText("Check-in"), "Click on check-in button");
            await utils.ValidateTextIsVisibleOnScreen("Check-in realizado com sucesso", "Validate if check-in success message is visible");

        }

        public async Task Call()
        {
            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            await utils.Click("(" + gen.LocatorSpanText("Chamar") + ")[1]", "Call patient to appointment");
            await utils.ValidateTextIsVisibleOnScreen("Paciente chamado com sucesso!", "Validate if call patient success message is visible");
        }
        

        public async Task Started()
        {
            string status = "ATENDENDO";
            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            await utils.Click("(" + gen.LocatorSpanText("Iniciar") + ")[1]", "Click on start button");
            await utils.ValidateTextIsVisibleOnScreen("Atendimento iniciado com sucesso", "Validate if appointment started message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Atendimento iniciado!", "Validate if appointment started message is visible");
            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            await utils.Click("(" + gen.LocatorSpanText("Pausar") + ")[1]", "pause appointment");
            await utils.ValidateTextIsVisibleOnScreen("Atendimento pausado!", "Validate if call patient success message is visible");
            await utils.Click("(" + gen.LocatorSpanText("Retomar") + ")[1]", "Call patient to appointment");
            await utils.ValidateTextIsVisibleOnScreen("Atendimento retomado!", "Validate if call patient success message is visible");
            await utils.ValidateElementIsVisibleOnScreen(gen.StatusOnTable(status), $"Validate if status on table is {status}");

        }

        public async Task InProgress()
        {

            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            await utils.GetTextOfElementConvertToIntAndCompare(gen.InProgressCard,1, "Validate if status is in progress");

        }

        public async Task Canceled()
        {
            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            await utils.Click("(" + gen.LocatorSpanText("Cancelar") + ")[1]", "Click on cancel button");
            await utils.Click(gen.LocatorSpanText("Sim, cancelar"), "Confirm cancellation");
            await utils.ValidateTextIsVisibleOnScreen("Consulta cancelada com sucesso!", "Validate if cancellation message is visible");
        }

        public async Task Finalize()
        {
            string status = "CONCLUÍDA";
            await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "Insert patient name on search field");
            await utils.Click("(" + gen.LocatorSpanText("Finalizar") + ")[1]", "Click on finish button");
            await utils.ValidateTextIsVisibleOnScreen("Atendimento finalizado!", "Validate if appointment finished message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Atendimento finalizado com", "Validate if finish confirmation is visible");
            await utils.ValidateElementIsVisibleOnScreen(gen.StatusOnTable(status), $"Validate if status on table is {status}");

        }

    }
}
