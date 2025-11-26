using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using OrtoGreenE2E.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtogreenE2E.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [AllureOwner("Levi")]
    [Category("Criticality: Critical")]
    [AllureSuite("Availability")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class AvailabilityTests : TestBase
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
            await login.Login();
            await utils.Click(gen.LocatorDiv("Agenda"), "Click on Schedule on main menu");
            await utils.Click(gen.LocatorA("Disponibilidade"), "Click on Availability on main menu");
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

[Test, Order(1)]
        [AllureName("Should Create A New Availability")]
        public async Task Should_Create_A_New_Availability()
        {
            var availability = new AvailabilityPage(page);
            await availability.CreateNewAvailability();
        }

    }
}
