
using Allure.NUnit;
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

namespace OrtogreenE2E.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [AllureOwner("Levi")]
    [Category("Criticality: Critical")]
    [AllureSuite("Arrivals")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class ArrivalsTests : TestBase
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
            await utils.Click(gen.LocatorA("Controle de chegadas"), "Click on Arrivals control on main menu");
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register a New Arrival")]
        public async Task Should_Register_a_New_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.ScheduleAppointment();
        }
        [Test, Order(2)]
        [AllureName("Should Consult a Arrival")]
        public async Task Should_Consult_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.ConsultExistingAppointment();
        }
        [Test, Order(3)]
        [AllureName("Should Contain CheckIn in Arrivals")]
        public async Task Should_Contain_CheckIn_in_Arrivals()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.Checkin();
        }
        [Test, Order(4)]
        [AllureName("Should Contain Started in Arrivals")]
        public async Task Should_Contain_Started_In_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.Started();
        }
        [Test, Order(5)]
        [AllureName("Should Contain InProgress in Arrivals")]
        public async Task Should_Contain_InProgress_In_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.InProgress();
        }
        [Test, Order(6)]
        [AllureName("Should Contain Canceled in Arrivals")]
        public async Task Should_Contain_Canceled_In_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.Canceled();
        }

    }
}
