using System;
using Castle.DynamicProxy;

namespace AutofacInterceptorPoc.Interceptors
{
    public class ConsoleLoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Containing class: {invocation.TargetType.Name}");
            Console.WriteLine($"Calling method: {invocation.Method.Name}");
            Console.WriteLine($"Arguments {string.Join(",",invocation.Arguments)}");
            invocation.Proceed();
            Console.WriteLine($"Leaving method {invocation.TargetType.Namespace}.{invocation.Method.Name}");
        }
    }
}