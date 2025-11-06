
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
    [Category("Suite: Type Schedule")]
    [Category("Regression Tests")]
    public class TypeScheduleTests : TestBase
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
        public async Task Should_Register_a_New_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.RegisterNewTypeShedule();
        }
        [Test, Order(2)]
        public async Task Should_Consult_a_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.ConsultTypeSchedule();
        }
        [Test, Order(3)]
        public async Task Should_Edit_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.EditTypeSchedule();
        }
        [Test, Order(4)]
        public async Task Should_Delete_Type_Schedule()
        {
            var typeSchedule = new TypeSchedulePage(page);
            await typeSchedule.DeleteTypeSchedule();
        }

    }
}
