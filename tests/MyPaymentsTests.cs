using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
using OrtogreenE2E.utils;
using OrtoGreenE2E.locators;
using OrtoGreenE2E.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.tests
{
    public class MyPaymentsTests : TestBase
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
            await utils.Click(gen.LocatorA("Meu Caixa"), "Click on My box on menu");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }



        [Test]
        [AllureName ("Should open payment box")]
        public async Task Should_Open_Payment_Box()
        {
            var myPayments = new MyPaymentsPage(page);
            await myPayments.OpenPaymentBox();
        }



    }
}
