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
    public class AvailabilityTests : TestBase
    {
        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
            await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Disponibilidade" }).ClickAsync();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Do_Create_A_New_Availability()
        {
            var availability = new AvailabilityPage(page);
            await availability.CreateNewAvailability();
        }
    
    }
}
