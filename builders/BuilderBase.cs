using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtoGreenE2E.builders
{
    public class BuilderBase 
    {
        protected List<Func<Task>> Steps { get; private set; }
        
        protected BuilderBase()
        {
            Steps = new List<Func<Task>>();            
        }

        public BuilderBase AddStep(Func<Task> step)
        {
            Steps.Add(step);
            return this;
        }

        public async Task Execute()
        {
            foreach(var step in Steps)
            {
                await step();            
            }
        }

        public async Task Execute(params Func<Task>[] additionalSteps)
        {
            foreach( var step in additionalSteps)
            {
                Steps.Add(step);
            }

            foreach (var step in Steps)
            {
                await step();
            }
        }

        public async Task ClearSteps()
        {
            Steps.Clear();
        }







    }
}
