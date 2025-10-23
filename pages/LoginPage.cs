using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using OrtogreenE2E.utils;
using OrtoGreenE2E.locators;
using static Microsoft.Playwright.Assertions;


namespace OrtogreenE2E.pages
{
    public class LoginPage
    {
        Utils utils;

        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        public LoginPage(IPage page) 
        {
            this.page = page;
            utils = new Utils(page);
        }

        public async Task DoLogin()
        {
            //await page.PauseAsync();
            await page.GetByRole(AriaRole.Textbox, new() { Name = "seu@email.com" }).FillAsync("qa@teste.com");
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Sua senha" }).FillAsync("Teste@123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Entrar" }).ClickAsync();
            await Expect(page.GetByText("Bem-vindo, Levi da Paz!")).ToBeVisibleAsync();
            await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Dashboard" })).ToBeVisibleAsync();
            await utils.ValidateUrl("https://urboz.com/app/dashboard", "Validate Url on dash page");

        }
        public async Task Login()
        {
            await Task.Delay(500);
            await utils.Write(gen.LocatorPlaceholder("seu@email.com"), "qa@teste.com", "Write Email on email field on Login Page");
            await utils.Write(gen.LocatorPlaceholder("Sua senha"), "Teste@123", "Write password on password field on Login Page");
            await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on Submit button to do login");

        }

    }
}
