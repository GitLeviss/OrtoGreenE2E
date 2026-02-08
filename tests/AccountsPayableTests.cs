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
        [Test, Order(1)]
        [AllureName("Should create a new account payble")]
        public async Task Should_Create_A_New_Account_Payble()
        {    
            var accountPayblePage = new AccountPayblePage(page);
             
        }
        [Test, Order(2)]
        [AllureName("Should AccountPayment")]

        public async Task Should_Account_Payment()
        {
            var accountPayblePage = new AccountPayblePage(page);
         


        }

        [Test, Order(3)]
        [AllureName("Should Consult a Account Payble")]
        public async Task Should_Consult_A_Account_Payble()
        {
            var accountPayblePage = new AccountPayblePage(page);
            
        } [Test, Order(4)]
        [AllureName("Should Payments")]
        public async Task Should_Payments()
        {
            var accountPayblePage = new AccountPayblePage(page);
           
        }
      
        }

    }

