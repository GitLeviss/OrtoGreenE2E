using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using static Microsoft.Playwright.Assertions;


namespace OrtogreenE2E.pages
{
    public class LoginPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly LoginData data;
        public LoginPage(IPage page, LoginData data = null)
        {
            this.page = page;
            utils = new Utils(page);
            this.data = data ?? new LoginData();
        }

        public async Task DoLogin()
        {
            await utils.Write(gen.LocatorPlaceholder("seu@email.com"), data.UserEmail, "Insert user email to do login");
            await utils.Write(gen.LocatorPlaceholder("Sua senha"), data.UserPassword, "Insert user password to do login");
            await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on submit button to do login");
            await utils.ValidateUrl("https://urboz.com/app/dashboard", "Validate Url on dash page");
        }
        public async Task Logout()
        {

            await utils.Write(gen.LocatorPlaceholder("seu@email.com"), data.UserEmail, "Insert user email to do login");
            await utils.Write(gen.LocatorPlaceholder("Sua senha"), data.UserPassword, "Insert user password to do login");
            await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on submit button to do login");
            await utils.ValidateUrl("https://urboz.com/app/dashboard", "Validate Url on dash page");
            await utils.Click("//button[text()='LA']", "Click on menu login button");
            await utils.Click(gen.LocatorSpanText("Sair"), "Click on leave button");
            await utils.ValidateTextIsVisibleOnScreen("Logout realizado com sucesso", "Validate if success message is visible on scree");
            await utils.ValidateUrl("https://urboz.com/login", "Validate Url on home page");



        }
        [AllureStep("Do Login")]
        public async Task Login()
        {

            await Task.Delay(500);
            await utils.Write(gen.LocatorPlaceholder("seu@email.com"), data.UserEmail, "Insert user email to do login");
            await utils.Write(gen.LocatorPlaceholder("Sua senha"), data.UserPassword, "Insert user password to do login");
            await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on submit button to do login");



        }
        public async Task LoginNegative(string testCase)
        {

            if (testCase == "Invalid Password")
            {
                await utils.Write(gen.LocatorPlaceholder("seu@email.com"), data.UserEmail, "Insert user email to do login");
                await utils.Write(gen.LocatorPlaceholder("Sua senha"), data.UserPassword, "Insert user password to do login");
                await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on submit button to do login");
                await Expect(page.GetByText("Email ou senha inválidos")).ToBeVisibleAsync();

            }
            else if (testCase == "Invalid Email")
            {
                await utils.Write(gen.LocatorPlaceholder("seu@email.com"), data.UserEmail, "Insert user email to do login");
                await utils.Write(gen.LocatorPlaceholder("Sua senha"), data.UserPassword, "Insert user password to do login");
                await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on submit button to do login");
                await Expect(page.GetByText("Erro ao fazer login")).ToBeVisibleAsync();

            }
            else if (testCase == "Empty Fields")
            {
                await utils.Write(gen.LocatorPlaceholder("seu@email.com"), data.UserEmail, "Insert user email to do login");
                await utils.Write(gen.LocatorPlaceholder("Sua senha"), data.UserPassword, "Insert user password to do login");
                await utils.Click(gen.LocatorSpanText(" Entrar "), "Click on submit button to do login");
                await utils.ValidateTextIsVisibleOnScreen("Erro ao fazer login", "Validate if error message is visible on screen of user");
                await utils.ValidateTextIsVisibleOnScreen("Email é obrigatório", "Validate if message mandatory email is visible on screen of user");
                await utils.ValidateTextIsVisibleOnScreen("Senha é obrigatório", "Validate if message mandatory password is visible on screen of user");

            }





        }

    }
}
