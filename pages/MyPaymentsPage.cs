using Microsoft.Playwright;
using OrtogreenE2E.utils;
using OrtoGreenE2E.data;
using OrtoGreenE2E.locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.pages
{
    public class MyPaymentsPage
    {
        Utils utils;
        GeneralElements gen = new GeneralElements();
        MyPaymentsData data = new MyPaymentsData();
        private readonly IPage page;

        public MyPaymentsPage(IPage page, MyPaymentsData data = null)
        {            
            this.page = page;
            utils = new Utils(page);
            this.data = data ?? new MyPaymentsData();
        }

        public async Task OpenPaymentBox()
        {
            await utils.Click(gen.LocatorSpanText(" Abrir Caixa "), "click on open box payments button");
            await utils.Clear(gen.LocatorPlaceholder("100.00"), "clear value of payment box on modal");
            await utils.Write(gen.LocatorPlaceholder("100.00"), data.value, "insert value of payment box on modal");
            await utils.Click(gen.LocatorSpanText(" Abrir Meu Caixa "), "click on open box payments button after all flow");
            await utils.ValidateTextIsVisibleOnScreen(data.successMessage, "Validate if message success be present on screen user");
        }





    }
}
