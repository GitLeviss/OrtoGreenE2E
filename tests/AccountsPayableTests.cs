using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using OrtoGreenE2E.pages;
using OrtoGreenE2E.utils;


namespace OrtoGreenE2E.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [AllureOwner("Islan")]
    [Category("Criticality: Critical")]
    [AllureSuite("Account Payble")]
    [Category("Regression Tests")]
    [AllureNUnit]

    public class AccountPaybleTests : TestBase
    {
        Utils utils;
        GeneralElements gen = new GeneralElements();
        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            utils = new Utils(page);
            var login = new LoginPage(page);
            await login.DoLogin();
            await utils.Click(gen.LocatorA("Pagamentos"), "Click on Account Payble on menu");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            page = await OpenBrowserAsync();
            await CloseBrowserAsync();
        }
        [Test]
        [AllureName("Should create a new account payble")]
        public async Task Should_Create_A_New_Account_Payble()
        {
            //APAGA ISSO DAQUI, DADOS FICA NA CLASSE DE DADOS
            var accountPaybleData = new OrtoGreenE2E.data.AccountPaybleData
            {
                description = "Electricity Bill",
                value = "150.00",
                type = "Utilities",
                category = "Bills",
                paidDate = "15",
                successMessage = "Conta a pagar criada com sucesso"
            };
            var accountPayblePage = new OrtoGreenE2E.pages.AccountPayblePage(page, accountPaybleData);
            await accountPayblePage.OpenAccountPayble();

        }
    }
}