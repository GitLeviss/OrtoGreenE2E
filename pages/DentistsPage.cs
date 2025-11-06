using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using OrtogreenE2E.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtogreenE2E.pages
{
    public class DentistsPage
    {
        Utils utils;
        private readonly IPage page;

        public DentistsPage(IPage page)
        {
            this.page = page;
            utils = new Utils(page);
        }

        string dentistName = "Test Dentist";

        public async Task RegisterDentist()
        {
            try
            {
                Random random = new Random();
                int randomNumber = random.Next();


                await page.GetByRole(AriaRole.Button, new() { Name = "Novo Dentista" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Dr(a). Nome Completo" }).FillAsync(dentistName);
                await page.GetByRole(AriaRole.Textbox, new() { Name = "-00" }).FillAsync("38188785873");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "(11) 99999-" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "(11) 99999-" }).FillAsync("(11) 9531-89062");
                await page.Locator("form div").Filter(new() { HasText = "Informações ProfissionaisUnidade *Selecione a unidadeCRO *123456UF do CRO *" }).GetByRole(AriaRole.Textbox).First.ClickAsync();
                await page.GetByText("QualityAssurance").Nth(1).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "123456" }).FillAsync("321456");
                await page.Locator("form div").Filter(new() { HasText = "Informações ProfissionaisUnidade *QualityAssuranceCRO *UF do CRO *StatusAtivo" }).GetByRole(AriaRole.Textbox).Nth(2).ClickAsync();
                await page.Locator("form div").Filter(new() { HasText = "Informações ProfissionaisUnidade *QualityAssuranceCRO *UF do CRO *StatusAtivo" }).GetByRole(AriaRole.Textbox).Nth(2).FillAsync("São Paulo");
                await page.GetByText("São Paulo (SP)").ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "email@exemplo.com" }).FillAsync($"teste{randomNumber}@email.com");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Mínimo 8 caracteres" }).FillAsync("Teste@123");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Mínimo 8 caracteres" }).PressAsync("Tab");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Digite a senha novamente" }).FillAsync("Teste@123");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Informações adicionais sobre" }).FillAsync("Teste");
                await page.GetByRole(AriaRole.Button, new() { Name = "Criar Dentista" }).ClickAsync();
                await Expect(page.GetByText("Dentista criado com sucesso!")).ToBeVisibleAsync();

                

            }
            catch
            {
                throw new PlaywrightException("Don´t possible register a new dentist");
            }

        }

        public async Task ConsultDentist()
        {
            try
            {

                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(dentistName);
                await Expect(page.Locator("(//td//span//span//div)[1]")).ToHaveTextAsync(dentistName);
                await Expect(page.Locator("(//td)[6]//div//sup//span[1]")).ToHaveTextAsync("Ativo");
            }
            catch
            {
                throw new PlaywrightException("Don´t possible consult dentist");
            }
        }
        public async Task EditDentist()
        {
            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).First.ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Dr(a). Nome Completo" }).FillAsync(dentistName + " edited");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Alterações" }).ClickAsync();
                await Expect(page.GetByText("Dentista atualizado com")).ToBeVisibleAsync();

            }
            catch
            {
                throw new PlaywrightException("");
            }
        }
        public async Task DeleteDentist()
        {
            try
            {
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(dentistName + " edited");
                await page.Locator("//tr[.//div[contains(@class,'font-medium') and normalize-space(text())='Test Dentist edited']]//button[.//span[normalize-space(text())='Excluir']]").ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await Expect(page.GetByText("Dentista excluído com sucesso")).ToBeVisibleAsync();
                await Expect(page.GetByText("Dentista deletado com sucesso!")).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(dentistName + " edited");
                await Expect(page.GetByText("Não há dados")).ToBeVisibleAsync();

            }
            catch
            {
                throw new PlaywrightException("Don´t possible delete dentist");
            }
        }

       

    }
}
