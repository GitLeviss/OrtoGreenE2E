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



namespace OrtoGreenE2E.pages
{
    public class RadiologyPage
    {
        Utils utils;
        private readonly IPage page;
        GeneralElements gen = new GeneralElements();
        private readonly RadiologyData data;


        public RadiologyPage(IPage page, RadiologyData data = null)
        {
            this.page = page;
            this.data = data ?? new RadiologyData();
            utils = new Utils(page);
        }


        public async Task RegisterNewRadiologyExam()
        {

            await utils.Click(gen.LocatorSpanText(" Novo Exame Radiológico "), "Click on New Radiology Exam button");
            await utils.Write(gen.LocatorPlaceholder("Nome do exame"), data.name, "Insert exam name");
            await utils.Write(gen.LocatorPlaceholder("Descrição do exame"), data.description, "Insert exam description");
            await utils.Click(gen.LocatorSpanText(" Salvar Exame "), "Click on Save Radiology Exam button");
            await utils.ValidateTextIsVisibleOnScreen("Exame radiológico criado com sucesso!", "Validate if success message is visible on screen");
        }
        public async Task ConsultRadiologyExam()
        {
            await utils.Write(gen.LocatorPlaceholder("Nome do exame"), data.name, "Insert exam name on search field");
            await utils.ValidateTextIsVisibleOnScreen(data.name, "Validate if exam name is visible on table");
        }

        public async Task EditRadiologyExam()
        {
            await utils.Write(gen.LocatorPlaceholder("Nome do exame"), data.name, "Insert exam name on search field");
            await utils.Click(gen.LocatorSpanText(data.name), "Click on edit icon for the exam");
            await utils.Clear(gen.LocatorPlaceholder("Descrição do exame"), "Clear exam description field");
            await utils.Write(gen.LocatorPlaceholder("Descrição do exame"), data.description, "Insert new exam description");
            await utils.Click(gen.LocatorSpanText(" Salvar Exame "), "Click on Save Radiology Exam button");
            await utils.ValidateTextIsVisibleOnScreen("Exame radiológico atualizado com sucesso!", "Validate if success message is visible on screen");
        }

        public async Task DeleteRadiologyExam()
        {
            await utils.Write(gen.LocatorPlaceholder("Nome do exame"), data.name, "Insert exam name on search field");
            await utils.Click(gen.LocatorSpanText(data.name), "Click on delete icon for the exam");
            await utils.Click(gen.LocatorSpanText(" Sim, excluir "), "Confirm deletion of the exam");
            await utils.ValidateTextIsVisibleOnScreen("Exame radiológico excluído com sucesso!", "Validate if success message is visible on screen");
        }
        public async Task ValidateRequiredFieldsOnNewRadiologyExam()
        {
            await utils.Click(gen.LocatorSpanText(" Novo Exame Radiológico "), "Click on New Radiology Exam button");
            await utils.Click(gen.LocatorSpanText(" Salvar Exame "), "Click on Save Radiology Exam button without filling required fields");
            await utils.ValidateTextIsVisibleOnScreen("O nome do exame é obrigatório.", "Validate if required field message for exam name is visible");
        }

      public async Task Should_Validate_Duplicate_Radiology_Exam_Name ()
    
        {
            await utils.Click(gen.LocatorSpanText(" Novo Exame Radiológico "), "Click on New Radiology Exam button");
            await utils.Write(gen.LocatorPlaceholder("Nome do exame"), data.name, "Insert duplicate exam name");
            await utils.Write(gen.LocatorPlaceholder("Descrição do exame"), data.description, "Insert exam description");
            await utils.Click(gen.LocatorSpanText(" Salvar Exame "), "Click on Save Radiology Exam button");
            await utils.ValidateTextIsVisibleOnScreen("Já existe um exame radiológico com este nome.", "Validate if duplicate exam name message is visible");
}
}
}










