
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
using OrtoGreenE2E.data;
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
    [AllureSuite("Login")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class LoginTests : TestBase
    {
       

        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Do Login With Valid Credentials")]
        public async Task Should_Do_Login_With_Valid_Credentials()
        {
            var login = new LoginPage(page);
            await login.DoLogin();
        }
        [Test, Order(2)]
        [AllureName("Should Do Logout")]
        [Ignore ("test disabled")]
        public async Task Should_Do_Logout()
        {
            var login = new LoginPage(page);
            await login.Logout();
        }
        [AllureName("Shouldnt Login With Incorrect Email")]
        [Test, Order(3)]
        public async Task Shouldnt_Login_With_Incorrect_Email()
        {
            var testData = new LoginData { UserEmail = "incorrect" };
            var login = new LoginPage(page, testData);
            await login.LoginNegative("Invalid Email");
        }
        [Test, Order(4)]
        [AllureName("Shouldnt Login With Incorrect Password")]
        public async Task Shouldnt_Login_With_Incorrect_Password()
        {
            var testData = new LoginData { UserPassword = "incorrect" };
            var login = new LoginPage(page, testData);
            await login.LoginNegative("Invalid Password");
        }
        [Test, Order(5)]
        [AllureName("Shouldnt Login With EmptyFields")]
        public async Task Shouldnt_Login_With_EmptyFields()
        {
            var testData = new LoginData { UserEmail = string.Empty, UserPassword = string.Empty };
            var login = new LoginPage(page, testData);
            await login.LoginNegative("Empty Fields");
        }
    }
}
