using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using OrtogreenE2E.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.pages
{
    public class ArrivalsPage
    {
        Utils utils;
        private readonly IPage page;

        public ArrivalsPage(IPage page)
        {
            this.page = page;
            utils = new Utils(page);
        }

        string patientName = "User Teste";

        public async Task ScheduleAppointment()
        {
            try
            {
                //await page.PauseAsync();
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Nova Consulta" }).ClickAsync();
                await page.Locator(".n-base-selection-input").First.ClickAsync();
                await page.GetByText(patientName).ClickAsync();
                await page.Locator("form").GetByRole(AriaRole.Textbox).First.ClickAsync();
                await page.GetByText("Dr. QA (CRO: 122435)").ClickAsync();
                await page.Locator("form").GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
                await page.GetByText("Canal (90 min)").ClickAsync();
                await page.Locator("(//div[@class='flex items-center justify-between']//label[@class='n-radio'])[1]").ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Sala 1, Consultório A" }).FillAsync("Sala 8 Consultorio B");
                await page.GetByTitle("Normal").Locator("div").ClickAsync();
                await page.GetByText("Alta").ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações sobre a consulta" }).FillAsync("Apenas Testando");
                await page.GetByRole(AriaRole.Button, new() { Name = "Confirmar Agendamento" }).ClickAsync();
                await Expect(page.GetByText("Consulta agendada com sucesso!")).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Create a new Appointment" + ex.Message);
            }




        }

        public async Task ConsultExistingAppointment()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).FillAsync(patientName);
                await page.Locator(".n-input__prefix > svg").ClickAsync();
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Agendada");
                await Expect(page.Locator("(//span[text()='User Teste'])[1]")).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Consult a Existing appointment" + ex.Message);
            }
        }
        public async Task Checkin()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).FillAsync(patientName);
                await page.GetByRole(AriaRole.Button, new() { Name = "Confirmar" }).ClickAsync();
                await Expect(page.GetByText("1").Nth(2)).ToBeVisibleAsync();
                await Expect(page.Locator("//span[text()='Confirmada']")).ToBeVisibleAsync();

                await page.GetByRole(AriaRole.Button, new() { Name = "Check-in" }).ClickAsync();
                await Expect(page.GetByText("Check-in realizado com sucesso")).ToBeVisibleAsync();
                await Expect(page.GetByText("Check-in realizado!")).ToBeVisibleAsync();

            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible validate check-in" + ex.Message);
            }

        }
        public async Task Started()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).FillAsync(patientName);
                await Expect(page.GetByTitle("Confirmada")).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Iniciar" }).ClickAsync();
                await Expect(page.GetByText("Atendimento iniciado com")).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible validate Started appointment" + ex.Message);
            }

        }
        public async Task InProgress()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).FillAsync(patientName);
                await Expect(page.GetByTitle("Em Atendimento")).ToBeVisibleAsync();
                await Expect(page.GetByText("1").Nth(1)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible validate appointment in progress" + ex.Message);
            }

        }
        public async Task Canceled()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).FillAsync(patientName);
                await page.GetByRole(AriaRole.Button, new() { Name = "Finalizar" }).ClickAsync();
                await Expect(page.GetByText("Atendimento finalizado!")).ToBeVisibleAsync();
                await Expect(page.GetByText("Atendimento finalizado com")).ToBeVisibleAsync();
                await page.GetByTitle("Concluída").ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Cancelar" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, cancelar" }).ClickAsync();
                await Expect(page.GetByText("Consulta cancelada com sucesso!")).ToBeVisibleAsync();
                await Expect(page.GetByText("Consulta cancelada com sucesso", new() { Exact = true })).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible validate canceled appointment" + ex.Message);
            }
        }

    }
}
