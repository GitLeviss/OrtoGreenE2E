using Allure.NUnit;
using Allure.NUnit.Attributes;
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
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [AllureOwner("Levi")]
    [Category("Criticality: Critical")]
    [AllureSuite("Dentists")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class DentistsTests : TestBase
    {


        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
            await page.GetByRole(AriaRole.Complementary).GetByText("Equipe").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Dentistas" }).ClickAsync();
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register a New Dentist")]
        public async Task Should_Register_a_New_Dentist()
        {
            var dentist = new DentistsPage(page);
            await dentist.RegisterDentist();
        }
        [Test, Order(2)]
        [AllureName("Should Consult a Existing Dentist")]
        public async Task Should_Consult_Dentist()
        {
            var dentist = new DentistsPage(page);
            await dentist.ConsultDentist();
        }
        [Test, Order(3)]
        [AllureName("Should Edit Dentist")]
        public async Task Should_Edit_Dentist()
        {
            var dentist = new DentistsPage(page);
            await dentist.EditDentist();
        }
        [Test, Order(4)]
        [AllureName("Should Delete Dentist")]
        public async Task Should_Delete_Dentist()
        {
            var dentist = new DentistsPage(page);
            await dentist.DeleteDentist();
        }


    }
}
