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

        public async Task RegisterSpecialityOrto()
        {

            await utils.Click(gen.LocatorSpanText("Nova Especialidade"), "Click on New Speciality button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.OrtoName, "Insert orthodontics speciality name");
            await utils.Write(gen.LocatorPlaceholder("Breve descrição sobre a"), data.Description + " ortodontia", "Insert description");
            await utils.Write(gen.LocatorPlaceholder("Observações adicionais sobre"), data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText("Salvar Especialidade"), "Click on save speciality button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade criada com", "Validate if success message is visible on screen");

        }

        public async Task ConsultSpecialityOrto()
        {

            await utils.ValidateTextIsVisibleOnScreen(data.OrtoName, "Validate if orthodontics speciality is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is active");
            await utils.ValidateTextIsVisibleOnScreen("Ativas1", "Validate if active count is 1");
            await utils.Click("div:has-text('Total de Especialidades1')", "Click on total specialities count");

        }

        public async Task EditSpecialityOrto()
        {

            await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.OrtoName + " teste Edição", "Edit speciality name");
            await utils.Click(gen.LocatorSpanText("Salvar Alterações"), "Click on save changes button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade atualizada com", "Validate if success message is visible on screen");
            await utils.ValidateTextIsVisibleOnScreen(data.OrtoName + " teste Edição", "Validate if edited name is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is still active");

        }

        public async Task DeleteSpecialityOrto()
        {

            await utils.Click(gen.LocatorSpanText("Excluir"), "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade deletada com", "Validate if deletion message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Total de Especialidades0", "Validate if total count is 0");
            await utils.ValidateTextIsVisibleOnScreen("Ativas0", "Validate if active count is 0");
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.OrtoName + " teste Edição", "Search for deleted speciality");
            await utils.ValidateTextIsVisibleOnScreen("Não há dados", "Validate if speciality was deleted");

        }

        public async Task RegisterSpecialityGen()
        {

            await utils.Click(gen.LocatorSpanText("Nova Especialidade"), "Click on New Speciality button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.GeneralClinicName, "Insert general clinic speciality name");
            await utils.Write(gen.LocatorPlaceholder("Breve descrição sobre a"), data.Description + " clínico geral", "Insert description");
            await utils.Write(gen.LocatorPlaceholder("Observações adicionais sobre"), data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText("Salvar Especialidade"), "Click on save speciality button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade criada com", "Validate if success message is visible on screen");

        }

        public async Task ConsultSpecialityGen()
        {

            await utils.ValidateTextIsVisibleOnScreen(data.GeneralClinicName, "Validate if general clinic speciality is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is active");
            await utils.ValidateTextIsVisibleOnScreen("Ativas1", "Validate if active count is 1");
            await utils.Click("div:has-text('Total de Especialidades1')", "Click on total specialities count");

        }

        public async Task EditSpecialityGen()
        {

            await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.GeneralClinicName + " teste Edição", "Edit speciality name");
            await utils.Click(gen.LocatorSpanText("Salvar Alterações"), "Click on save changes button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade atualizada com", "Validate if success message is visible on screen");
            await utils.ValidateTextIsVisibleOnScreen(data.GeneralClinicName + " teste Edição", "Validate if edited name is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is still active");

        }

        public async Task DeleteSpecialityGen()
        {

            await utils.Click(gen.LocatorSpanText("Excluir"), "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade deletada com", "Validate if deletion message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Total de Especialidades0", "Validate if total count is 0");
            await utils.ValidateTextIsVisibleOnScreen("Ativas0", "Validate if active count is 0");
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.GeneralClinicName + " teste Edição", "Search for deleted speciality");
            await utils.ValidateTextIsVisibleOnScreen("Não há dados", "Validate if speciality was deleted");

        }

        public async Task RegisterSpecialityEndo()
        {

            await utils.Click(gen.LocatorSpanText("Nova Especialidade"), "Click on New Speciality button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.EndoName, "Insert endodontics speciality name");
            await utils.Write(gen.LocatorPlaceholder("Breve descrição sobre a"), data.Description + " endodontia", "Insert description");
            await utils.Write(gen.LocatorPlaceholder("Observações adicionais sobre"), data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText("Salvar Especialidade"), "Click on save speciality button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade criada com", "Validate if success message is visible on screen");


        }

        public async Task ConsultSpecialityEndo()
        {

            await utils.ValidateTextIsVisibleOnScreen(data.EndoName, "Validate if endodontics speciality is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is active");
            await utils.ValidateTextIsVisibleOnScreen("Ativas1", "Validate if active count is 1");
            await utils.Click("div:has-text('Total de Especialidades1')", "Click on total specialities count");

        }

        public async Task EditSpecialityEndo()
        {

            await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.EndoName + " teste Edição", "Edit speciality name");
            await utils.Click(gen.LocatorSpanText("Salvar Alterações"), "Click on save changes button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade atualizada com", "Validate if success message is visible on screen");
            await utils.ValidateTextIsVisibleOnScreen(data.EndoName + " teste Edição", "Validate if edited name is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is still active");

        }

        public async Task DeleteSpecialityEndo()
        {

            await utils.Click(gen.LocatorSpanText("Excluir"), "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade deletada com", "Validate if deletion message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Total de Especialidades0", "Validate if total count is 0");
            await utils.ValidateTextIsVisibleOnScreen("Ativas0", "Validate if active count is 0");
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.EndoName + " teste Edição", "Search for deleted speciality");
            await utils.ValidateTextIsVisibleOnScreen("Não há dados", "Validate if speciality was deleted");

        }

        public async Task RegisterSpecialityImpla()
        {

            await utils.Click(gen.LocatorSpanText("Nova Especialidade"), "Click on New Speciality button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.ImplaName, "Insert implantodontics speciality name");
            await utils.Write(gen.LocatorPlaceholder("Breve descrição sobre a"), data.Description + " implantodontia", "Insert description");
            await utils.Write(gen.LocatorPlaceholder("Observações adicionais sobre"), data.Observation, "Insert observation");
            await utils.Click(gen.LocatorSpanText("Salvar Especialidade"), "Click on save speciality button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade criada com", "Validate if success message is visible on screen");

        }

        public async Task ConsultSpecialityImpla()
        {

            await utils.ValidateTextIsVisibleOnScreen(data.ImplaName, "Validate if implantodontics speciality is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is active");
            await utils.ValidateTextIsVisibleOnScreen("Ativas1", "Validate if active count is 1");
            await utils.Click("div:has-text('Total de Especialidades1')", "Click on total specialities count");

        }

        public async Task EditSpecialityImpla()
        {

            await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Ortodontia,"), data.ImplaName + " teste Edição", "Edit speciality name");
            await utils.Click(gen.LocatorSpanText("Salvar Alterações"), "Click on save changes button");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade atualizada com", "Validate if success message is visible on screen");
            await utils.ValidateTextIsVisibleOnScreen(data.ImplaName + " teste Edição", "Validate if edited name is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativa", "Validate if speciality status is still active");

        }

        public async Task DeleteSpecialityImpla()
        {

            await utils.Click(gen.LocatorSpanText("Excluir"), "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
            await utils.ValidateTextIsVisibleOnScreen("Especialidade deletada com", "Validate if deletion message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Total de Especialidades0", "Validate if total count is 0");
            await utils.ValidateTextIsVisibleOnScreen("Ativas0", "Validate if active count is 0");
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.ImplaName + " teste Edição", "Search for deleted speciality");
            await utils.ValidateTextIsVisibleOnScreen("Não há dados", "Validate if speciality was deleted");

        }
    }
}