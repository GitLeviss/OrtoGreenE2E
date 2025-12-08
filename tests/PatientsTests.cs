
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
    [AllureSuite("Patients")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class PatientsTests : TestBase
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
            await utils.Click(gen.LocatorA("Pacientes"), "Click on Patients on main menu");
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register a Patient")]
        public async Task Should_Register_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.RegisterNewPatient();
        }
        [Test, Order(2)]
        [AllureName("Should Consult a Patient")]
        public async Task Should_Consult_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.ConsultPatient();
        }
        [Test, Order(3)]
        [AllureName("Should Edit a Patient")]
        public async Task Should_Edit_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.EditPatient();
        }
        [Test, Order(4)]
        [AllureName("Should Delete a Patient")]
        public async Task Should_Delete_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.DeletePatient();
        }

    }
}
