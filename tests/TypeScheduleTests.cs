
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
    [AllureSuite("TypeSchedule")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class TypeScheduleTests : TestBase
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
            await utils.Click(gen.LocatorA("Tipos de Agendamento"), "Click on Type Schedule on main menu");
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

[Test, Order(1)]
        [AllureName("Should Register a New Type Schedule")]
        public async Task Should_Register_a_New_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.RegisterNewTypeShedule();
        }
        [Test, Order(2)]
        [AllureName("Should Consult a Type Schedule")]
        public async Task Should_Consult_a_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.ConsultTypeSchedule();
        }
        [Test, Order(3)]
        [AllureName("Should Edit Type Schedule")]
        public async Task Should_Edit_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.EditTypeSchedule();
        }
        [Test, Order(4)]
        [AllureName("Should Delete Type Schedule")]
        public async Task Should_Delete_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.DeleteTypeSchedule();
        }

    }
}
