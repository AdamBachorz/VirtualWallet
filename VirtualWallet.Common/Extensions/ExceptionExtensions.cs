using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string FullMessage(this Exception exception)
        {
            string resultText = exception.Message;

            if (exception.InnerException != null)
                resultText += exception.InnerException.Message;

            return resultText;
        }
    }
}
