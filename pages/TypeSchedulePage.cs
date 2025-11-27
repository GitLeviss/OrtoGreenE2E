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
    public class TypeSchedulePage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly TypeScheduleData data;

        public TypeSchedulePage(IPage page, TypeScheduleData data = null)
        {
            this.page = page;
            this.data = data ?? new TypeScheduleData();
            utils = new Utils(page);
        }

        public async Task RegisterNewTypeShedule()
        {

            await utils.Click(gen.LocatorSpanText("Novo Tipo"), "Click on New Type button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Consulta Inicial, Limpeza"), data.TypeName, "Insert type name");
            await utils.Write(gen.LocatorPlaceholder("Ex: CONS-INICIAL"), data.Code, "Insert type code");
            await utils.Click(gen.LocatorSpanText("Salvar"), "Click on save button");
            await utils.ValidateTextIsVisibleOnScreen("Tipo de agendamento criado com sucesso", "Validate if success message is visible on screen");
            await utils.ValidateTextIsVisibleOnScreen("Tipo de agendamento criado com sucesso!", "Validate if success confirmation is visible on screen");

        }

        public async Task ConsultTypeSchedule()
        {
            await utils.Click(gen.LocatorPlaceholder("Buscar..."), "Click on search field");
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.TypeName, "Insert type name on search field");
            await utils.ValidateTextIsVisibleOnScreen(data.TypeName, "Validate if type name is visible on table");
            await utils.ValidateTextIsVisibleOnScreen("Ativo", "Validate if type status is active");

        }

        public async Task EditTypeSchedule()
        {

            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.TypeName, "Search for type");
            await utils.Click(gen.LocatorSpanText("Editar"), "Click on edit button");
            await utils.Write(gen.LocatorPlaceholder("Ex: Consulta Inicial, Limpeza"), data.TypeName + " Editado", "Edit type name");
            await utils.Click(gen.LocatorSpanText("Salvar"), "Click on save button");
            await utils.ValidateTextIsVisibleOnScreen("Tipo de agendamento atualizado com sucesso", "Validate if success message is visible on screen");
            await utils.ValidateTextIsVisibleOnScreen("Tipo de agendamento atualizado com sucesso!", "Validate if success confirmation is visible on screen");

        }

        public async Task DeleteTypeSchedule()
        {

            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.TypeName + " Editado", "Search for edited type");
            await utils.Click(gen.LocatorSpanText("Excluir"), "Click on delete button");
            await utils.Click(gen.LocatorSpanText("Sim, excluir"), "Confirm deletion");
            await utils.ValidateTextIsVisibleOnScreen("Tipo de agendamento deletado", "Validate if deletion message is visible");
            await utils.ValidateTextIsVisibleOnScreen("Tipo de agendamento excluído", "Validate if deletion confirmation is visible");
            await utils.Click(gen.LocatorPlaceholder("Buscar..."), "Click on search field");
            await utils.Write(gen.LocatorPlaceholder("Buscar..."), data.TypeName + " Editado", "Search for deleted type");
            await utils.ValidateTextIsVisibleOnScreen("Não há dados", "Validate if type was deleted");

        }
    }
}