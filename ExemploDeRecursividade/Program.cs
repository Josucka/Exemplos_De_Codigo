using System;
using System.Collections.Generic;

namespace ExemploDeRecursividade
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class Error
    {
        private List<Error> _errors;

        private string message;
        public Error(string message)
        {
            this.message = message;
        }

        public void AddError(Exception e)
        {
            _errors.Add(new Error(e.Message));
            if (e.InnerException == null)
                return;
            AddError(e.InnerException);
        }
    }
}
