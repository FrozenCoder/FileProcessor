using System;
using FileProcessor.DomainLayer.Entities;
using Framework.TRH.Data;
using Framework.TRH.ErrorHandling;
using Ninject;

namespace FileProcessor.DomainLayer.Services
{
    public class DomainErrorService:ErrorHandler
    {
        private readonly IWriteRepository<FileProcessorError> _repository;
        private readonly FileProcessorError _error;

        [Inject]
        public DomainErrorService(IWriteRepository<FileProcessorError> repository, FileProcessorError error)
        {
            _error = error;
            _repository = repository;
        }

        protected override void LogToDatabase()
        {
            try
            {
                _error.ApplicationName = "FileProcessor";
                _error.Exception = exceptionType;
                _error.MachineName = machineName;
                _error.StackTrace = stackTrace;
                _error.SystemTime = DateTime.Now;
                _error.UserAdded = Environment.UserName;

                _repository.Persist(_error);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
        }
    }
}