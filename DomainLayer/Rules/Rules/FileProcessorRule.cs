using System.Collections.Generic;
using Framework.TRH.Command;

namespace FileProcessor.DomainLayer.Rules.Rules
{
    public abstract class FileProcessorRule
    {
        public ParameterResolver ParameterResolver { get; set; }

        public IList<string > Errors{ get; set;}

        protected FileProcessorRule()
        {
            ParameterResolver = new ParameterResolver();
            Errors =  new List<string>();
        }

        public abstract void Run();

        protected abstract void SetParameters();
    }
}