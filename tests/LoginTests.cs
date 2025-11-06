
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
    [Category("Suite: Login")]
    [Category("Regression Tests")]
    public class LoginTests : TestBase
    {
        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
        }
        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        public async Task Should_Do_Login_With_Valid_Credentials()
        {
            var login = new LoginPage(page);
            await login.DoLogin();
        }
        [Test, Order(2)]
        public async Task Should_Do_Logout()
        {
            var login = new LoginPage(page);
            await login.Logout();
        }
        [Test, Order(3)]
        public async Task Shouldnt_Login_With_Incorrect_Email()
        {
            var login = new LoginPage(page);
            await login.LoginNegative("Invalid Email");
        }
        [Test, Order(4)]
        public async Task Shouldnt_Login_With_Incorrect_Password()
        {
            var login = new LoginPage(page);
            await login.LoginNegative("Invalid Password");
        }
        [Test, Order(5)]
        public async Task Shouldnt_Login_With_EmptyFields()
        {
            var login = new LoginPage(page);
            await login.LoginNegative("Empty Fields");
        }
    }
}
