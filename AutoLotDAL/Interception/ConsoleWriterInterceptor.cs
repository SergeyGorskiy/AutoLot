using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace AutoLotDAL.Interception
{
    public class ConsoleWriterInterceptor : IDbCommandInterceptor
    {
        private void WriteInfo(bool isAsync, string commandText)
        {
            Console.WriteLine($"IsAsync: {isAsync}, Command Text: {commandText}");
        }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Console.WriteLine(command.CommandText, interceptionContext.IsAsync);
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Console.WriteLine(command.CommandText, interceptionContext.IsAsync);
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Console.WriteLine(command.CommandText, interceptionContext.IsAsync);
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Console.WriteLine(command.CommandText, interceptionContext.IsAsync);
        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Console.WriteLine(command.CommandText, interceptionContext.IsAsync);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Console.WriteLine(command.CommandText, interceptionContext.IsAsync);
        }
    }
}