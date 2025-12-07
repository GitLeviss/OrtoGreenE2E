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

namespace OrtogreenE2E.pages
{
    public class PatientsPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly PatientsData data;

        public PatientsPage(IPage page, PatientsData data = null)
        {
            this.page = page;
            this.data = data ?? new PatientsData();
            utils = new Utils(page);
        }

        public async Task RegisterNewPatient()
        {

            await utils.Click(gen.LocatorSpanText(" Novo Paciente "), "Click on New Patient button");
            await utils.Write(gen.LocatorPlaceholder("Nome completo do paciente"), data.PatientName, "Insert patient name");
            await utils.Write(gen.LocatorPlaceholder("email@exemplo.com"), data.Email, "Insert patient email");
            await utils.Write(gen.LocatorPlaceholder("(11) 99999-9999"), data.Phone, "Insert patient phone");
            await utils.Write(gen.LocatorPlaceholder("Selecione a data"), data.BirthDate, "Insert birth date");
            await utils.Write(gen.LocatorPlaceholder("00000-000"), data.CEP, "Insert CEP");
            await utils.Write(gen.LocatorPlaceholder("Nome da rua"), data.Street, "Insert street name");
            await utils.Write(gen.LocatorPlaceholder("Número"), data.Number, "Insert number");
            await utils.Write(gen.LocatorPlaceholder("Apto, Bloco, etc"), data.Complement, "Insert complement");
            await utils.Write(gen.LocatorPlaceholder("Bairro"), data.Neighborhood, "Insert neighborhood");
            await utils.Write(gen.LocatorPlaceholder("Cidade"), data.City, "Insert city");            
            await utils.Click(gen.SelectOrder("1"), "Click on state selector");
            await utils.Write(gen.SelectOrder("1"), data.State, "Click on state selector");
            await utils.Click("São Paulo (SP)", "Select São Paulo state", true);
            await utils.Write(gen.LocatorPlaceholder("Informações adicionais sobre o paciente"), data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText(" Criar Paciente"), "Click on create patient button");
            await utils.ValidateTextIsVisibleOnScreen("Paciente criado com sucesso!", "Validate if success message is visible on screen");

        }

        public async Task ConsultPatient()
        {
            await utils.Write(gen.LocatorPlaceholder("Nome, código, CPF, email ou telefone..."), data.PatientName, "Insert patient name on search field");
            await utils.ValidateTextIsVisibleOnScreen(data.PatientName, "Validate if patient name is visible on table");


        }
        public async Task EditPatient()
        {

            await utils.Write(gen.LocatorPlaceholder("Nome, código, CPF, email ou telefone..."), data.PatientName, "Search for patient");
            await utils.Click($"//div[text()='{data.PatientName}']/ancestor::tr//span[text()='Editar']", "Click on edit button");
            await utils.Click(gen.LocatorPlaceholder("Nome completo do paciente"), "Click on patient name field");
            await utils.Write(gen.LocatorPlaceholder("Nome completo do paciente"), data.PatientName + " Editado", "Edit patient name");
            await utils.Click(gen.LocatorSpanText("Salvar Alterações"), "Click on save changes button");
            await utils.ValidateTextIsVisibleOnScreen("Paciente atualizado com sucesso!", "Validate if success message is visible on screen");

        }
        public async Task DeletePatient()
        {

            await utils.Click(gen.LocatorA("Pacientes"), "Click on Patients menu");
            await utils.Write(gen.LocatorPlaceholder("Nome, código, CPF, email ou telefone..."), data.PatientName + " Editado", "Search for edited patient");
            await utils.Click($"//div[text()='{data.PatientName}']/ancestor::tr//span[text()='Excluir']", "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
            await utils.ValidateTextIsVisibleOnScreen("Paciente deletado com sucesso!", "Validate if deletion message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Paciente excluído com sucesso", "Validate if deletion confirmation is visible");

        }

    }





}





