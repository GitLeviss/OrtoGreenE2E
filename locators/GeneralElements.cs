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

        public string LocatorSpanText(string textLocator) => $"//span[text()='{textLocator}']";
        public string LocatorPlaceholder(string textPlaceholder) => $"//input[@placeholder='{textPlaceholder}']";

    }
}
