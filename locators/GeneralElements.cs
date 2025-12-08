using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.locators
{
    public class GeneralElements
    {
        public string LocatorSpanText (string textLocator) => $"//span[text()='{textLocator}']";
        public string LocatorPlaceholder (string textPlaceholder) => $"//input[@placeholder='{textPlaceholder}']";
        public string LocatorDiv (string text) => $"//div[text()='{text}']";
        public string LocatorClassDiv (string text) => $"//div[@class='{text}']";
        public string LocatorA (string text) => $"//a[text()='{text}']";
        public string SelectOrder (string position) => $"(//div[@class='n-select'])[{position}]";
        public string RadioOrder (string position) => $"(//div[@class='n-radio__dot'])[{position}]";
        public string ButtonExpand(string position) => $"(//tr//i[@class='n-base-icon'])[{position}]";
        public string ActiveCard { get; } = "//div[text()='Ativas']//following-sibling::div";
        public string InProgressCard { get; } = "//div[text()='Em Atendimento']//following-sibling::div";
        public string FirstTdOnTable { get; } = "(//td[1]//span//span//div)[1]";
        public string StatusOnTable(string status) => $"(//td[2]//span[text()='{status}'])[1]";


    }
}
