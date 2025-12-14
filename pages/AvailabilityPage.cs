using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace OrtogreenE2E.pages
{
    public class AvailabilityPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly AvailabilityData data;

        public AvailabilityPage(IPage page, AvailabilityData data = null)
        {
            this.page = page;
            this.data = data ?? new AvailabilityData();
            utils = new Utils(page);
        }


        public async Task CreateNewAvailability()
        {

            await utils.Click(gen.SelectOrder("1"), "Click on dentist selector");
            await utils.Click(data.DentistName, "Select dentist", true);
            await utils.Click(gen.LocatorSpanText(" Nova Regra "), "Click on New Rule button");
            await utils.Click(gen.SelectOrder("2"), "click on select days to expand options");
            await utils.Click(gen.LocatorDiv("Domingo"), "click on sunday on days options");
            await utils.Click("("+gen.LocatorClassDiv("n-switch__rail")+")[1]", "Click on morning period");
            await utils.Write("//textarea", data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText("Salvar"), "Click on save button");
            await utils.ValidateTextIsVisibleOnScreen("Regra de agenda criada com sucesso!", "Validate if success message is visible on screen");
        }

        public async Task DeleteAvailability()
        {
            await utils.Click(gen.SelectOrder("1"), "Click on dentist selector");
            await utils.Click(data.DentistName, "Select dentist", true);
            await utils.Click(gen.LocatorSpanText("teste") + "/ancestor::tr" + gen.LocatorSpanText("Remover"), "Click on remove test Availability");
        }


    }
}
