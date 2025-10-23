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
    public class TypeSchedulePage
    {
        private readonly IPage page;

        public TypeSchedulePage(IPage page) 
        {
            this.page = page;            
        }

        public string typeName = "Agendamento Teste";
        public async Task RegisterNewTypeShedule()
        {
            //await page.PauseAsync();

            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Tipos de Agendamento" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Novo Tipo" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Consulta Inicial, Limpeza" }).FillAsync(typeName);
                
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: CONS-INICIAL" }).FillAsync("test");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar" }).ClickAsync();
                await Expect(page.GetByText("Tipo de agendamento criado com sucesso", new() { Exact = true })).ToBeVisibleAsync();
                await Expect(page.GetByText("Tipo de agendamento criado com sucesso!")).ToBeVisibleAsync();

            }
            catch
            {
                throw new PlaywrightException("Don´t possible create a new schedule type");
            }

        }

        public async Task ConsultTypeSchedule()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Tipos de Agendamento" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(typeName);
                await Expect(page.GetByText(typeName)).ToBeVisibleAsync();
                await Expect(page.GetByTitle("Ativo")).ToBeVisibleAsync();
            }
            catch
            {
               throw new  PlaywrightException("Don´t possible consult a type schedule");
            }
            
        }

        public async Task EditTypeSchedule()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Tipos de Agendamento" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(typeName);
                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Consulta Inicial, Limpeza" }).FillAsync("Agendamento Teste Editado");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar" }).ClickAsync();
                await Expect(page.GetByText("Tipo de agendamento atualizado com sucesso", new() { Exact = true })).ToBeVisibleAsync();
                await Expect(page.GetByText("Tipo de agendamento atualizado com sucesso!")).ToBeVisibleAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible consult a type schedule");
            }
        }
        public async Task DeleteTypeSchedule()
        {
            try
            {
                await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Tipos de Agendamento" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync(typeName + " Editado");
                await page.GetByRole(AriaRole.Button, new() { Name = "Excluir" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await Expect(page.GetByText("Tipo de agendamento deletado")).ToBeVisibleAsync();
                await Expect(page.GetByText("Tipo de agendamento excluído")).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar..." }).FillAsync("Agendamento Teste Editado");
                await Expect(page.GetByText("Não há dados")).ToBeVisibleAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible consult a type schedule");
            }
        }


    }
}
