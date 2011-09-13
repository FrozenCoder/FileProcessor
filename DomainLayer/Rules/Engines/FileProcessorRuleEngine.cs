using System.Collections.Generic;
using FileProcessor.DomainLayer.Entities;
using FileProcessor.DomainLayer.Rules.Rules;
using Framework.TRH.Command;

namespace FileProcessor.DomainLayer.Rules.Engines
{
    public abstract class FileProcessorRuleEngine
    {
        protected BaseEntity _entity;

        protected IList<FileProcessorRule> Rules { get; set; }

        public IList<string> Errors{ get; set;}

        public ParameterResolver ParameterResolver{ get; set;}

        protected FileProcessorRuleEngine()
        {
            Rules = new List<FileProcessorRule>();

            ParameterResolver = new ParameterResolver();

            Errors = new List<string>();
        }

        public void RunRules()
        {
            Rules.Clear();

            Errors.Clear();

            SetParameters();

            AddRules();

            foreach (FileProcessorRule rule in Rules)
            {
                rule.ParameterResolver.Register<BaseEntity>(_entity);

                rule.Run();

                Errors = rule.Errors;
            }
        }

        private void SetParameters()
        {
            _entity = ParameterResolver.Resolve<BaseEntity>();
        }

        protected abstract void AddRules();
    }
}
