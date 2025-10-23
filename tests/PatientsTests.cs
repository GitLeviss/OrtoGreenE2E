
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
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
    [Category("Suite: Patients")]
    [Category("Regression Tests")]
    public class PatientsTests : TestBase
    {
        

        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
            await page.GetByRole(AriaRole.Link, new() { Name = "Pacientes" }).ClickAsync();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Register_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.RegisterNewPatient();
        }
        [Test, Order(2)]
        public async Task Should_Consult_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.ConsultPatient();
        }
        [Test, Order(3)]
        public async Task Should_Edit_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.EditPatient();
        }
        [Test, Order(4)]
        public async Task Should_Delete_a_Patients()
        {
            var patients = new PatientsPage(page);
            await patients.DeletePatient();
        }

    }
}
