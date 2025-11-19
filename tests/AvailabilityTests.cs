using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;

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
        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
            await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Disponibilidade" }).ClickAsync();
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Do Create A New Availability")]
        public async Task Should_Do_Create_A_New_Availability()
        {
            var availability = new AvailabilityPage(page);
            await availability.CreateNewAvailability();
        }

    }
}
