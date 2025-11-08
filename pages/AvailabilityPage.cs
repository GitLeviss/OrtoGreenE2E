using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrtoGreenE2E.locators;

namespace OrtogreenE2E.pages
{
    public class AvailabilityPage
    {
        GeneralElements el = new GeneralElements();
        private IPage page;
        public AvailabilityPage(IPage page)
        {
            this.page = page;
        }


        public async Task CreateNewAvailability()
        {
            try
            {
                await page.Locator(".n-base-selection-label").ClickAsync();
                await page.Locator("//div[text()='Levi da Paz']").ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Nova Regra" }).ClickAsync();
                await page.GetByRole(AriaRole.Dialog).Locator("div").Filter(new() { HasTextRegex = new Regex("^Manhã$") }).Locator("div").Nth(1).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais sobre" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais sobre" }).FillAsync("teste");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar" }).ClickAsync();
                await Expect(page.GetByText("Regra de agenda criada com")).ToBeVisibleAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible register a new rule");
            }


            try
            {
                await page.Locator("//span[text()='teste']/ancestor::tr//span[text()='Remover']").ClickAsync();
                await Expect(page.GetByText("Regra de agenda removida com")).ToBeVisibleAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible Remove a rule");
            }

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
