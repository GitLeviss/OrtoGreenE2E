using Microsoft.Playwright;
using OrtoGreenE2E.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.builders
{
    public class ArrivalsBuilder : BuilderBase
    {
        protected readonly ArrivalsPage _arrivalsPage;
        public ArrivalsBuilder(ArrivalsPage arrivalsPage)
        {
            this._arrivalsPage = arrivalsPage;
        }

        public ArrivalsBuilder ClickOnNewArrival()
        {
            AddStep(async ()=> await _arrivalsPage.ClickOnNewArrival());
            return this;
        }

        public ArrivalsBuilder FillFormOfAppointment()
        {
            AddStep(async () => await _arrivalsPage.FillFormOfAppointment());
            return this;
        }

        public ArrivalsBuilder ValidateMessageVisible(string expectedTextIsVisible)
        {
            AddStep(async () => await _arrivalsPage.ValidateMessageVisible(expectedTextIsVisible));
            return this;
        }

        public ArrivalsBuilder ValidateStatusInTable(string status) 
        {
            AddStep(async ()=> await _arrivalsPage.ValidateStatusOnTable(status));
            return this;
        }

        public ArrivalsBuilder ConsultPatient()
        {
            AddStep(async () => await _arrivalsPage.ConsultExistingAppointment());
            return this;
        }






    }
}
