using Microsoft.Playwright;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using OrtoGreenE2E.utils;

namespace OrtoGreenE2E.pages
{
    public class AccountPayblePage
    {
        Utils utils;
        GeneralElements gen = new GeneralElements();
        AccountPaybleData data = new AccountPaybleData();
        private readonly IPage page;

        public AccountPayblePage(IPage page, AccountPaybleData data = null)
        {
            this.page = page;
            this.utils = new Utils(page);
            //ISSO DAQUI É SÓ SE FOR USAR TESTE NEGATIVO! NÃO PRECISA FAZER AGR, TO REFATORANDO TODOS OS NEGATIVOS, SÓ MAPEIA
            this.data = data ?? new AccountPaybleData();
        }

        public async Task OpenAccountPayble()
        {
            await utils.Click(gen.LocatorA("Pagamentos"), "Click on Account Payble on menu");
            await utils.Click(gen.LocatorA("Contas a Pagar"), "click on Account Payble on menu");
            await utils.Click(gen.LocatorSpanText(" Nova Conta a Pagar "), "click on New Account Payble button");
            await utils.Write(gen.LocatorPlaceholder("Descrição"), data.description, "insert description on account payble");
            await utils.Write(gen.LocatorPlaceholder("Valor"), data.value, "insert value on account payble");
            await utils.Click(gen.SelectOrder("1"), "click on select account payble type");
            await utils.Click(gen.LocatorDiv(data.type), "select type of account payble");
            await utils.Click(gen.SelectOrder("2"), "click on select account payble category");
            await utils.Click(gen.LocatorDiv(data.category), "select category of account payble");
            await utils.Click(gen.RadioOrder("2"), "select paid radio button");
            await utils.Click(gen.ButtonExpand("1"), "expand paid date picker");
            await utils.Click(gen.LocatorDiv(data.paidDate), "select paid date");
            await utils.Click(gen.LocatorSpanText(" Salvar "), "click on save account payble button");
            await utils.ValidateTextIsVisibleOnScreen(data.successMessage, "Validate if message success be present on screen user");
        }
    }
}