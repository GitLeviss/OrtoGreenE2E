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
    public class SpecialityPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly SpecialityData data;

        public SpecialityPage(IPage page, SpecialityData data = null)
        {
            this.page = page;
            this.data = data ?? new SpecialityData();
            utils = new Utils(page);
        }

        public async Task RegisterSpeciality(string specialityName)
        {

            await utils.Click(gen.LocatorSpanText(" Nova Especialidade "), "Click on New Speciality button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia, Implantodontia, Endodontia"), specialityName, $"Insert {specialityName} speciality name");
            await utils.Click(gen.LocatorSpanText(" Salvar Especialidade"), "Click on save speciality button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade criada com sucesso!", "Validate if success message is visible on screen");

        }

        public async Task ConsultSpeciality(string specialityName)
        {
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), specialityName, "Search to orto name on search bar");
            await utils.GetTextOfElementAndCompare(gen.FirstTdOnTable, specialityName, "Get Name of active speciality");
            await utils.GetTextOfElementConvertToIntAndCompare(gen.ActiveCard, 1, "Validate if value of active specialities is 1");
        }

        public async Task EditSpeciality(string specialityName)
        {
            await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia, Implantodontia, Endodontia"), specialityName + " teste Edição", $"Edit speciality {specialityName} name");
            await utils.Click(gen.LocatorSpanText(" Salvar Alterações"), "Click on save changes button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade atualizada com sucesso!", "Validate if success message is visible on screen");
            await utils.GetTextOfElementAndCompare(gen.FirstTdOnTable, specialityName + " teste Edição", $"Get Name of active speciality {specialityName} edited");
        }

        public async Task DeleteSpeciality(string specialityName)
        {
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), specialityName, "Search to orto name on search bar");
            await utils.Click(gen.LocatorSpanText("Excluir"), "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), $"Confirm deletion of speciality {specialityName}");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade deletada com sucesso!", "Validate if deletion message is visible");
            await utils.GetTextOfElementConvertToIntAndCompare(gen.ActiveCard, 0, "Validate if value of active specialities is 0 after excluded all");
            await utils.ValidateTextIsNotVisibleOnScreen(data.OrtoName + " teste Edição", $"Search for deleted {specialityName} speciality");

        }
        
    }
}