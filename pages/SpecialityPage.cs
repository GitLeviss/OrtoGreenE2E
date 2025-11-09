using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using OrtogreenE2E.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.pages
{
    public class SpecialityPage
    {
        Utils utils;
        private readonly IPage page;

        public SpecialityPage(IPage page)
        {
            this.page = page;
            utils = new Utils(page);
        }
        string specialistyOrtoName = "Ortodontia";
        string specialistyGeneralClinicName = "Clínico Geral";
        string specialistyEndoName = "Endodontia";
        string specialistyImplaName = "Implantodontia";

        public async Task RegisterSpecialityOrto()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Nova Especialidade" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyOrtoName);
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Breve descrição sobre a" }).FillAsync("teste cadastro especialidade ortodontia");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais sobre" }).FillAsync("teste");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Especialidade" }).ClickAsync();
                await Expect(page.GetByText("Especialidade criada com")).ToBeVisibleAsync(); 
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Create a new SpecialityOrto" + ex.Message);
            }




        }

        public async Task ConsultSpecialityOrto()
        {
            try
            {
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyOrtoName);
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas1$") }).Nth(1)).ToBeVisibleAsync();
                await page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades1$") }).Nth(1).ClickAsync();
}
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Consult a Existing SpecialityOrto" + ex.Message);
            }
        }
       
        
        public async Task EditSpecialityOrto()
        {
            try
            {

                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyOrtoName + " teste Edição");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Alterações" }).ClickAsync();
                await Expect(page.GetByText("Especialidade atualizada com")).ToBeVisibleAsync();
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyOrtoName + " teste Edição");
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Edit SpecialityOrto" + ex.Message);
            }
        }
        public async Task DeleteSpecialityOrto()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Excluir" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await Expect(page.GetByText("Especialidade deletada com")).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades0$") }).Nth(1)).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas0$") }).Nth(1)).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(specialistyOrtoName + " teste Edição");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Não há dados$") }).Nth(1)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Delete SpecialityOrto" + ex.Message);
            }
        }
        public async Task RegisterSpecialityGen()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Nova Especialidade" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyGeneralClinicName);
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Breve descrição sobre a" }).FillAsync("teste cadastro especialidade ortodontia");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais sobre" }).FillAsync("teste");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Especialidade" }).ClickAsync();
                await Expect(page.GetByText("Especialidade criada com")).ToBeVisibleAsync(); 
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Create a new SpecialityGen" + ex.Message);
            }




        }

        public async Task ConsultSpecialityGen()
        {
            try
            {
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyGeneralClinicName);
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas1$") }).Nth(1)).ToBeVisibleAsync();
                await page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades1$") }).Nth(1).ClickAsync();
}
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Consult a Existing SpecialityGen" + ex.Message);
            }
        }
       
        
        public async Task EditSpecialityGen()
        {
            try
            {

                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyGeneralClinicName + " teste Edição");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Alterações" }).ClickAsync();
                await Expect(page.GetByText("Especialidade atualizada com")).ToBeVisibleAsync();
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyGeneralClinicName + " teste Edição");
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Edit SpecialityGen" + ex.Message);
            }
        }
        public async Task DeleteSpecialityGen()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Excluir" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await Expect(page.GetByText("Especialidade deletada com")).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades0$") }).Nth(1)).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas0$") }).Nth(1)).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(specialistyGeneralClinicName + " teste Edição");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Não há dados$") }).Nth(1)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Delete SpecialityGen" + ex.Message);
            }
        }
        public async Task RegisterSpecialityEndo()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Nova Especialidade" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyEndoName);
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Breve descrição sobre a" }).FillAsync("teste cadastro especialidade ortodontia");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais sobre" }).FillAsync("teste");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Especialidade" }).ClickAsync();
                await Expect(page.GetByText("Especialidade criada com")).ToBeVisibleAsync(); 
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Create a new SpecialityEndo" + ex.Message);
            }




        }

        public async Task ConsultSpecialityEndo()
        {
            try
            {
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyEndoName);
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas1$") }).Nth(1)).ToBeVisibleAsync();
                await page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades1$") }).Nth(1).ClickAsync();
}
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Consult a Existing SpecialityEndo" + ex.Message);
            }
        }
       
        
        public async Task EditSpecialityEndo()
        {
            try
            {

                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyEndoName + " teste Edição");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Alterações" }).ClickAsync();
                await Expect(page.GetByText("Especialidade atualizada com")).ToBeVisibleAsync();
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyEndoName + " teste Edição");
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Edit SpecialityEndo" + ex.Message);
            }
        }
        public async Task DeleteSpecialityEndo()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Excluir" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await Expect(page.GetByText("Especialidade deletada com")).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades0$") }).Nth(1)).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas0$") }).Nth(1)).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(specialistyEndoName + " teste Edição");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Não há dados$") }).Nth(1)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Delete SpecialityEndo" + ex.Message);
            }
        }

    
        public async Task RegisterSpecialityImpla()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Nova Especialidade" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyImplaName);
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Breve descrição sobre a" }).FillAsync("teste cadastro especialidade ortodontia");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações adicionais sobre" }).FillAsync("teste");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Especialidade" }).ClickAsync();
                await Expect(page.GetByText("Especialidade criada com")).ToBeVisibleAsync(); 
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Create a new SpecialityImpla" + ex.Message);
            }




        }

        public async Task ConsultSpecialityImpla()
        {
            try
            {
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyImplaName);
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas1$") }).Nth(1)).ToBeVisibleAsync();
                await page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades1$") }).Nth(1).ClickAsync();
}
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Consult a Existing SpecialityImpla" + ex.Message);
            }
        }
       
        
        public async Task EditSpecialityImpla()
        {
            try
            {

                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Ortodontia," }).FillAsync(specialistyImplaName + " teste Edição");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Alterações" }).ClickAsync();
                await Expect(page.GetByText("Especialidade atualizada com")).ToBeVisibleAsync();
                await Expect(page.Locator("(//td)[1]//span//span//div")).ToHaveTextAsync(specialistyImplaName + " teste Edição");
                await Expect(page.Locator("(//td)[4]//div//sup//span")).ToHaveTextAsync("Ativa");
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Edit SpecialityImpla" + ex.Message);
            }
        }
        public async Task DeleteSpecialityImpla()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Excluir" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await Expect(page.GetByText("Especialidade deletada com")).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Total de Especialidades0$") }).Nth(1)).ToBeVisibleAsync();
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Ativas0$") }).Nth(1)).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(specialistyImplaName + " teste Edição");
                await Expect(page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Não há dados$") }).Nth(1)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException("Don´t possible Delete SpecialityImpla" + ex.Message);
            }
        }

    }
}
