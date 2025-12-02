
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrtogreenE2E.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [AllureOwner("Levi")]
    [Category("Criticality: Critical")]
    [AllureSuite("Speciality")]
    [Category("Regression Tests")]
    [AllureNUnit]
    public class SpecialityTests : TestBase
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
            await utils.Click(gen.LocatorDiv("Clínica"), "Click on Clinic on main menu");
            await utils.Click(gen.LocatorA("Especialidades"), "Click on Specialities on main menu");
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }
        SpecialityData positiveData = new SpecialityData();

        [Test, Order(1)]
        [AllureName("Should Register a New Speciality Orto")]
        public async Task Should_Register_a_New_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpeciality(positiveData.OrtoName);
        }
        [Test, Order(2)]
        [AllureName("Should Consult Speciality Orto")]
        public async Task Should_Consult_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpeciality(positiveData.OrtoName);
        }
        [Test, Order(3)]
        [AllureName("Should Edit Speciality Orto")]
        public async Task Should_Edit_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpeciality(positiveData.OrtoName);
        }
        [Test, Order(4)]
        [AllureName("Should Delete Speciality Orto")]
        public async Task Should_Delete_Speciality_Orto()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpeciality(positiveData.OrtoName);
        }
        [Test, Order(5)]
        [AllureName("Should Register a new Speciality Gen")]
        public async Task Should_Register_a_New_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpeciality(positiveData.GeneralClinicName);
        }
        [Test, Order(6)]
        [AllureName("Should Consult Speciality Gen")]
        public async Task Should_Consult_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpeciality(positiveData.GeneralClinicName);
        }
        [Test, Order(7)]
        [AllureName("Should Edit Speciality Gen")]
        public async Task Should_Edit_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpeciality(positiveData.GeneralClinicName);
        }
        [Test, Order(8)]
        [AllureName("Should_Delete_Speciality_Gen")]
        public async Task Should_Delete_Speciality_Gen()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpeciality(positiveData.GeneralClinicName);
        }
        [Test, Order(9)]
        [AllureName("Should Register Speciality Endo")]
        public async Task Should_Register_a_New_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpeciality(positiveData.EndoName);
        }
        [Test, Order(10)]
        [AllureName("Should Consult Speciality Endo")]
        public async Task Should_Consult_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpeciality(positiveData.EndoName);
        }
        [Test, Order(11)]
        [AllureName("Should Edit Speciality Endo")]
        public async Task Should_Edit_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpeciality(positiveData.EndoName);
        }
        [Test, Order(12)]
        [AllureName("Should Delete Speciality Endo")]
        public async Task Should_Delete_Speciality_Endo()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpeciality(positiveData.EndoName);
        }
        [Test, Order(13)]
        [AllureName("Should Register a New Speciality Impla")]
        public async Task Should_Register_a_New_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.RegisterSpeciality(positiveData.ImplaName);
        }
        [Test, Order(14)]
        [AllureName("Should Consult Speciality Impla")]
        public async Task Should_Consult_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.ConsultSpeciality(positiveData.ImplaName);
        }
        [Test, Order(15)]
        [AllureName("Should Edit Speciality Impla")]
        public async Task Should_Edit_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.EditSpeciality(positiveData.ImplaName);
        }
        [Test, Order(16)]
        [AllureName("Should Delete Speciality Impla")]
        public async Task Should_Delete_Speciality_Impla()
        {
            var arrivals = new SpecialityPage(page);
            await arrivals.DeleteSpeciality(positiveData.ImplaName);
        }


    }
}
