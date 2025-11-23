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

        public ArrivalsPage(IPage page, ArrivalsData data = null )
        {
            this.page = page;
            this.data = data ?? new ArrivalsData();
            utils = new Utils(page);
        }

        string patientName = "User Teste";
        [AllureStep("ScheduleAppointment")]
        public async Task ScheduleAppointment()
        {
            await utils.Click(gen.LocatorSpanText(" Nova Consulta "), "Click on New to create a new schedule");
            await utils.Click(gen.SelectOrder("1"), "Click on first select to select a patient");
            await utils.Click(data.PatientName, "Set patient on select patient",true);
            await utils.Click(gen.SelectOrder("3"), "Click on select to expand dentist");
            await utils.Click(data.DentistName, "Set dentist on select patient", true);
            await utils.Click(gen.SelectOrder("4"), "Click on select to expand type of appointment");
            await utils.Click(data.TypeOfConsult, "Set type of consult on select order", true);
            await utils.Click(gen.RadioOrder("3"), "select disponibility time");
            await utils.Click(gen.LocatorSpanText(" Salvar Agendamento"), "Click on sabe appointment");
            await utils.ValidateTextIsVisibleOnScreen("Consulta agendada com sucesso!", "Validate if success message is visible on screen of user");
        }
        [AllureStep("Consult Existing Appointment")]
        public async Task ConsultExistingAppointment()
        {
            try
            {
                await utils.Write(gen.LocatorPlaceholder("Buscar por paciente, dentista ou tipo de consulta..."), data.PatientName, "insert patient name on search bar");
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Agendada");
                await Expect(page.Locator("(//span[text()='User Teste'])[1]")).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Consult a Existing appointment" + ex.Message);
            }
        }
        [AllureStep("Checkin")]
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
        [AllureStep("Started")]
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
        [AllureStep("In Progress")]
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
        [AllureStep("Canceled")]
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
