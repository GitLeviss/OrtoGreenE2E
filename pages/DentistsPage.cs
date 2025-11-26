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
    public class DentistsPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly DentistsData data;

        public DentistsPage(IPage page, DentistsData data = null)
        {
            this.page = page;
            this.data = data ?? new DentistsData();
            utils = new Utils(page);
        }

public static string UniqueNumber()
        {
            Random random = new Random();
            int uniqueNumber = random.Next(0, 9999);
            return uniqueNumber.ToString();
        }        

        public static string number = UniqueNumber();
        public string Email { get; } = $"teste{number}@email.com";

        public async Task RegisterDentist()
        {
            try
            {
                await utils.Click(gen.LocatorSpanText("Novo Dentista"), "Click on New Dentist button");
                await utils.Write(gen.LocatorPlaceholder("Dr(a). Nome Completo"), data.DentistName, "Insert dentist name");
                await utils.Write(gen.LocatorPlaceholder("-00"), data.CPF, "Insert CPF");
                await utils.Click(gen.LocatorPlaceholder("(11) 99999-"), "Click on phone field");
                await utils.Write(gen.LocatorPlaceholder("(11) 99999-"), data.Phone, "Insert phone");
                await utils.Click(gen.SelectOrder("1"), "Click on unit selector");
                await utils.Click(data.Unit, "Select unit", true);
                await utils.Write(gen.LocatorPlaceholder("123456"), data.CRO, "Insert CRO");
                await utils.Click(gen.SelectOrder("2"), "Click on CRO state selector");
                await utils.Click(data.CROState, "Select CRO state", true);
                await utils.Write(gen.LocatorPlaceholder("email@exemplo.com"), Email, "Insert email");
                await utils.Write(gen.LocatorPlaceholder("Mínimo 8 caracteres"), data.Password, "Insert password");
                await utils.Write(gen.LocatorPlaceholder("Digite a senha novamente"), data.Password, "Confirm password");
                await utils.Write(gen.LocatorPlaceholder("Informações adicionais sobre"), data.Observation, "Insert observation");
                await utils.Click(gen.LocatorSpanText("Criar Dentista"), "Click on create dentist button");
                await utils.ValidateTextIsVisibleOnScreen("Dentista criado com sucesso!", "Validate if success message is visible on screen");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible register a new dentist" + ex.Message);
            }
        }

public async Task ConsultDentist()
        {
            try
            {
                await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.DentistName, "Insert dentist name on search field");
                await utils.ValidateTextIsVisibleOnScreen(data.DentistName, "Validate if dentist name is visible on table");
                await utils.ValidateTextIsVisibleOnScreen("Ativo", "Validate if dentist status is active");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible consult dentist" + ex.Message);
            }
        }
public async Task EditDentist()
        {
            try
            {
                await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
                await utils.Write(gen.LocatorPlaceholder("Dr(a). Nome Completo"), data.DentistName + " edited", "Edit dentist name");
                await utils.Click(gen.LocatorSpanText("Salvar Alterações"), "Click on save changes button");
                await utils.ValidateTextIsVisibleOnScreen("Dentista atualizado com", "Validate if success message is visible on screen");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Edit dentist" + ex.Message);
            }
        }
public async Task DeleteDentist()
        {
            try
            {
                await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.DentistName + " edited", "Search for edited dentist");
                await utils.Click($"//tr[.//div[contains(@class,'font-medium') and normalize-space(text())='{data.DentistName} edited']]//button[.//span[normalize-space(text())='Excluir']]", "Click on delete button");
                await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
                await utils.ValidateTextIsVisibleOnScreen("Dentista excluído com sucesso", "Validate if deletion message is visible");
                await utils.ValidateTextIsVisibleOnScreen("Dentista deletado com sucesso!", "Validate if deletion confirmation is visible");
                await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.DentistName + " edited", "Search for deleted dentist");
                await utils.ValidateTextIsVisibleOnScreen("Não há dados", "Validate if dentist was deleted");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible delete dentist" + ex.Message);
            }
        }

       

    }
}
