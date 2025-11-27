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
    public class AvailabilityPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly AvailabilityData data;

        public AvailabilityPage(IPage page, AvailabilityData data = null)
        {
            this.page = page;
            this.data = data ?? new AvailabilityData();
            utils = new Utils(page);
        }


        public async Task CreateNewAvailability()
        {

            await utils.Click(".n-base-selection-label", "Click on dentist selector");
            await utils.Click(data.DentistName, "Select dentist", true);
            await utils.Click(gen.LocatorSpanText("Nova Regra"), "Click on New Rule button");
            await utils.Click(gen.LocatorDiv(data.Period), "Select period");
            await utils.Click(gen.LocatorPlaceholder("Observações adicionais sobre"), "Click on observation field");
            await utils.Write(gen.LocatorPlaceholder("Observações adicionais sobre"), data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText("Salvar"), "Click on save button");
            await utils.ValidateTextIsVisibleOnScreen("Regra de agenda criada com", "Validate if success message is visible on screen");



            await utils.Click($"//span[text()='{data.Observation}']/ancestor::tr//span[text()='Remover']", "Click on remove button");
            await utils.ValidateTextIsVisibleOnScreen("Regra de agenda removida com", "Validate if removal message is visible on screen");


            //try
            //{
            //    await page.GetByRole(AriaRole.Button, new() { Name = "Novo Bloqueio" }).ClickAsync();
            //    await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais" }).ClickAsync();
            //    await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais" }).FillAsync("teste");
            //    await page.GetByRole(AriaRole.Button, new() { Name = "Adicionar" }).ClickAsync();
            //    await Expect(page.GetByText("Bloqueio criado com sucesso!")).ToBeVisibleAsync();
            //}
            //catch
            //{
            //    throw new PlaywrightException("Don´t possible add a new block");
            //}
            //try
            //{
            //    await Expect(page.GetByText("teste")).ToBeVisibleAsync();
            //    //await page.PauseAsync();
            //    await page.Locator("//span[text()='teste']/ancestor::tr//span[text()='Remover']").ClickAsync();
            //    await Expect(page.GetByText("Bloqueio removido com sucesso!")).ToBeVisibleAsync();
            //}
            //catch
            //{
            //    throw new PlaywrightException("Don´t possible remove a block");
            //}



        }

    }
}
