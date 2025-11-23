using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.locators
{
    public class GeneralElements
    {
        public string PatientsPage { get; } = "//a[text()='Pacientes']";

        public string LocatorSpanText(string textLocator) => $"//span[text()=' {textLocator} ']";
        public string LocatorPlaceholder(string textPlaceholder) => $"//input[@placeholder='{textPlaceholder}']";
        public string LocatorDiv(string text) => $"//div[text()='{text}']";
        public string LocatorA (string text) => $"//a[text()='{text}']";
        public string SelectOrder(string position) => $"(//div[@class='n-select'])[{position}]";
        public string RadioOrder(string position) => $"(//div[@class='n-radio__dot'])[{position}]";

    }
}
