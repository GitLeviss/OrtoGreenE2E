
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
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
    [AllureSuite("Speciality")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class SpecialityTests : TestBase
    {


        private IPage page;

        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
            await page.GetByText("Clínica", new() { Exact = true }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Especialidades" }).ClickAsync();

        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register a New Speciality Orto")]
        public async Task Should_Register_a_New_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityOrto();
        }
        [Test, Order(2)]
        [AllureName("Should Consult Speciality Orto")]
        public async Task Should_Consult_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityOrto();
        }
        [Test, Order(3)]
        [AllureName("Should Edit Speciality Orto")]
        public async Task Should_Edit_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityOrto();
        }
        [Test, Order(4)]
        [AllureName("Should Delete Speciality Orto")]
        public async Task Should_Delete_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityOrto();
        }
        [Test, Order(5)]
        [AllureName("Should Register a new Speciality Gen")]
        public async Task Should_Register_a_New_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityGen();
        }
        [Test, Order(6)]
        [AllureName("Should Consult Speciality Gen")]
        public async Task Should_Consult_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityGen();
        }
        [Test, Order(7)]
        [AllureName("Should Edit Speciality Gen")]
        public async Task Should_Edit_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityGen();
        }
        [Test, Order(8)]
        [AllureName("Should_Delete_Speciality_Gen")]
        public async Task Should_Delete_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityGen();
        }
        [Test, Order(9)]
        [AllureName("Should Register Speciality Endo")]
        public async Task Should_Register_a_New_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityEndo();
        }
        [Test, Order(10)]
        [AllureName("Should Consult Speciality Endo")]
        public async Task Should_Consult_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityEndo();
        }
        [Test, Order(11)]
        [AllureName("Should Edit Speciality Endo")]
        public async Task Should_Edit_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityEndo();
        }
        [Test, Order(12)]
        [AllureName("Should Delete Speciality Endo")]
        public async Task Should_Delete_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityEndo();
        }
        [Test, Order(13)]
        [AllureName("Should Register a New Speciality Impla")]
        public async Task Should_Register_a_New_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityImpla();
        }
        [Test, Order(14)]
        [AllureName("Should Consult Speciality Impla")]
        public async Task Should_Consult_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityImpla();
        }
        [Test, Order(15)]
        [AllureName("Should Edit Speciality Impla")]
        public async Task Should_Edit_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityImpla();
        }
        [Test, Order(16)]
        [AllureName("Should Delete Speciality Impla")]
        public async Task Should_Delete_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityImpla();
        }


    }
}
