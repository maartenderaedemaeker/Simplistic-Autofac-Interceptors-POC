using System;
using System.Linq;
using AutofacInterceptorPoc.CustomAttributes;
using Castle.DynamicProxy;
using Polly;

namespace AutofacInterceptorPoc.Interceptors
{
    public class RetryInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var retryAttribute = invocation
                                .MethodInvocationTarget
                                .GetCustomAttributes(typeof(RetryAttribute), false)
                                .Cast<RetryAttribute>()
                                .FirstOrDefault();

            if (retryAttribute == null)
            {
                invocation.Proceed();
            }
            else
            {
                Policy.Handle<Exception>()
                      .Retry(retryAttribute.Times)
                      .Execute(() =>
                      {
                          Console.WriteLine("Trying invocation...");
                          invocation.Proceed();
                      });
            }
        }
    }
}