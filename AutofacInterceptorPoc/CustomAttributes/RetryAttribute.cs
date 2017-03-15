using System;

namespace AutofacInterceptorPoc.CustomAttributes
{
    public class RetryAttribute : Attribute
    {
        public int Times { get; }

        public RetryAttribute(int times = 1)
        {
            Times = times;
        }
    }
}