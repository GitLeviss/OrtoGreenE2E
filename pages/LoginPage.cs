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
            try
            {
                await page.GetByRole(AriaRole.Textbox, new() { Name = "seu@email.com" }).FillAsync("qa@teste.com");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Sua senha" }).FillAsync("Teste@123");
                await page.GetByRole(AriaRole.Button, new() { Name = "Entrar" }).ClickAsync();
                await Expect(page.GetByText("Bem-vindo, Levi da Paz!")).ToBeVisibleAsync();
                await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Dashboard" })).ToBeVisibleAsync();
                await utils.ValidateUrl("https://urboz.com/app/dashboard", "Validate Url on dash page");
            }
            catch (Exception ex)
            {
                throw new Exception("don´t possible do login" + ex.Message);
            }
            //await page.PauseAsync();

        }
        public async Task Logout()
        {
            try
            {
                await page.GetByRole(AriaRole.Textbox, new() { Name = "seu@email.com" }).FillAsync("qa@teste.com");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Sua senha" }).FillAsync("Teste@123");
                await page.GetByRole(AriaRole.Button, new() { Name = "Entrar" }).ClickAsync();
                await Expect(page.GetByText("Bem-vindo, Levi da Paz!")).ToBeVisibleAsync();
                await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Dashboard" })).ToBeVisibleAsync();
                await utils.ValidateUrl("https://urboz.com/app/dashboard", "Validate Url on dash page");
                await page.GetByRole(AriaRole.Button, new() { Name = "LP" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sair" }).ClickAsync();
                await Expect(page.GetByText("Logout realizado com sucesso")).ToBeVisibleAsync();
                await Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Bem-vindo ao OrtoGreen" })).ToBeVisibleAsync();
                await utils.ValidateUrl("https://urboz.com/login", "Validate Url on home page");
            }
            catch (Exception ex)
            {
                throw new Exception("don´t possible do Logout" + ex.Message);
            }


        }
        public async Task Login()
        {
            try
            {
                await Task.Delay(500);
                await utils.Write(gen.LocatorPlaceholder("seu@email.com"), "qa@teste.com", "Write Email on email field on Login Page");
                await utils.Write(gen.LocatorPlaceholder("Sua senha"), "Teste@123", "Write password on password field on Login Page");
                await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on Submit button to do login");
            }
            catch (Exception ex)
            {
                throw new Exception("don´t possible do Login Negative" + ex.Message);
            }


        }
        public async Task LoginNegative(string testCase)
        {
            try
            {
                if (testCase == "Invalid Password")
                {
                    await utils.Write(gen.LocatorPlaceholder("seu@email.com"), "qa@teste.com", "Write Email on email field on Login Page");
                    await utils.Write(gen.LocatorPlaceholder("Sua senha"), "invalid", "Write password on password field on Login Page");
                    await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on Submit button to do login");
                    await Expect(page.GetByText("Email ou senha inválidos")).ToBeVisibleAsync();

                }
                else if (testCase == "Invalid Email")
                {
                    await utils.Write(gen.LocatorPlaceholder("seu@email.com"), "qateste.com", "Write Email on email field on Login Page");
                    await utils.Write(gen.LocatorPlaceholder("Sua senha"), "Teste@123", "Write password on password field on Login Page");
                    await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on Submit button to do login");
                    await Expect(page.GetByText("Erro ao fazer login")).ToBeVisibleAsync();
                    await page.GetByText("Email inválido").ClickAsync();

                }
                else if (testCase == "Empty Fields")
                {
                    await utils.Write(gen.LocatorPlaceholder("seu@email.com"), "", "Write Email on email field on Login Page");
                    await utils.Write(gen.LocatorPlaceholder("Sua senha"), "", "Write password on password field on Login Page");
                    await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on Submit button to do login");
                    await Expect(page.GetByText("Erro ao fazer login")).ToBeVisibleAsync();
                    await Expect(page.GetByText("Email é obrigatório")).ToBeVisibleAsync();
                    await Expect(page.GetByText("Senha é obrigatória")).ToBeVisibleAsync();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("don´t possible do Login Negative" + ex.Message);

            }




        }

    }
}
