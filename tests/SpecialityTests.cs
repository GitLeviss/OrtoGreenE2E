
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
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Criticality: Critical")]
    [Category("Suite: Speciality")]
    [Category("Regression Tests")]
    public class SpecialityTests : TestBase
    {
        

        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
            await page.GetByText("Clínica", new() { Exact = true }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Especialidades" }).ClickAsync();

        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Register_a_New_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityOrto();
        }
        [Test, Order(2)]
        public async Task Should_Consult_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityOrto();
        }
        [Test, Order(3)]
        public async Task Should_Edit_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityOrto();
        }
        [Test, Order(4)]
        public async Task Should_Delete_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityOrto();
        }
        [Test, Order(5)]
        public async Task Should_Register_a_New_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityGen();
        }
        [Test, Order(6)]
        public async Task Should_Consult_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityGen();
        }
        [Test, Order(7)]
        public async Task Should_Edit_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityGen();
        }
        [Test, Order(8)]
        public async Task Should_Delete_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityGen();
        }
        [Test, Order(9)]
        public async Task Should_Register_a_New_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityEndo();
        }
        [Test, Order(10)]
        public async Task Should_Consult_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityEndo();
        }
        [Test, Order(11)]
        public async Task Should_Edit_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityEndo();
        }
        [Test, Order(12)]
        public async Task Should_Delete_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityEndo();
        }
        [Test, Order(13)]
        public async Task Should_Register_a_New_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpecialityImpla();
        }
        [Test, Order(14)]
        public async Task Should_Consult_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpecialityImpla();
        }
        [Test, Order(15)]
        public async Task Should_Edit_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpecialityImpla();
        }
        [Test, Order(16)]
        public async Task Should_Delete_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpecialityImpla();
        }
        

    }
}
