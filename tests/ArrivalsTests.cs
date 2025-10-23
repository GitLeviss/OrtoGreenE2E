
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
    [Category("Suite: Patients")]
    [Category("Regression Tests")]
    public class ArrivalsTests : TestBase
    {
        

        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            await login.Login();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Register_a_New_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.ScheduleAppointment();
        }
        [Test, Order(2)]
        public async Task Should_Consult_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.ConsultExistingAppointment();
        }
        [Test, Order(3)]
        public async Task Should_Contain_CheckIn_in_Arrivals()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.Checkin();
        }
        [Test, Order(4)]
        public async Task Should_Contain_Started_In_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.Started();
        }
        [Test, Order(5)]
        public async Task Should_Contain_InProgress_In_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.InProgress();
        }
        [Test, Order(6)]
        public async Task Should_Contain_Canceled_In_Arrival()
        {
            var arrivals = new ArrivalsPage(page);
            await arrivals.Canceled();
        }

    }
}
