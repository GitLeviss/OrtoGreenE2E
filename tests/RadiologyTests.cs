
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.pages;
using OrtogreenE2E.runner;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using OrtoGreenE2E.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [AllureOwner("Islan")]
    [Category("Criticality: Critical")]
    [AllureSuite("Radiology")]
    [Category("Regression Tests")]
    [AllureNUnit]

    public class RadiologyTests : TestBase
    {
        Utils utils;
        GeneralElements gen = new GeneralElements();
        [SetUp]
        [AllureBefore]

        public async Task Setup()
        {
            page = await OpenBrowserAsync();
            utils = new Utils(page);
            var login = new LoginPage(page);
            await login.Login();
            await utils.Click(gen.LocatorA("Radiologia"), "Click on Radiology on main menu");
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }
        [Test, Order(1)]
        [AllureName("Should Register a Radiology Exam")]
        public async Task Should_Register_a_Radiology_Exam()
        {
            var radiology = new RadiologyPage(page);
            await radiology.RegisterNewRadiologyExam();

        }
        [Test, Order(2)]
        [AllureName("Should Consult a Radiology Exam")]
        public async Task Should_Consult_a_Radiology_Exam()
        {
            var radiology = new RadiologyPage(page);
            await radiology.ConsultRadiologyExam();
        }
        [Test, Order(3)]
        [AllureName("Should Edit a Radiology Exam")]
        public async Task Should_Edit_a_Radiology_Exam()
        {
            var radiology = new RadiologyPage(page);
            await radiology.EditRadiologyExam();
        }
        [Test, Order(4)]
        [AllureName("Should Delete a Radiology Exam")]
        public async Task Should_Delete_a_Radiology_Exam()
        {
            var radiology = new RadiologyPage(page);
            await radiology.DeleteRadiologyExam();
        }
        [Test, Order(5)]
        [AllureName("Should Validate Required Fields on New Radiology Exam")]
        public async Task Should_Validate_Required_Fields_on_New_Radiology_Exam()
        {
            var radiology = new RadiologyPage(page);
            await radiology.ValidateRequiredFieldsOnNewRadiologyExam();

        }
        [Test, Order(6)]
        [AllureName("Should Validate Duplicate Radiology Exam Name")]
        public async Task Should_Validate_Duplicate_Radiology_Exam_Name()
        {
            var radiology = new RadiologyPage(page);
            await radiology.Should_Validate_Duplicate_Radiology_Exam_Name();
        }
    }
}
