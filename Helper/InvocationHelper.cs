using System;


namespace BitheroesBot.Helper
{
    public static class InvocationHelper
    {
        //Uncomment if fault handling through service model. 
        //public static T ExecuteWithFaultHandling<T>(this Func<T> codeToInvoke)
        //{
        //    try
        //    {
        //        return codeToInvoke.Invoke();
        //    }
        //    catch (FaultException ex)
        //    {
        //        //ex.ToLog();
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ex.ToLog();
        //        throw new FaultException(ex.Message);
        //    }
        //}
        //public static void ExecuteWithFaultHandling(this Action codeToInvoke)
        //{
        //    try
        //    {
        //        codeToInvoke.Invoke();
        //    }
        //    catch (FaultException ex)
        //    {
        //        //ex.ToLog();
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ex.ToLog();
        //        throw new FaultException(ex.Message);
        //    }
        //}
        public static T ExecuteWithExceptionHandling<T>(this Func<T> codeToInvoke, string exceptionString = "", Func<T> codeToInvokeOnFail = null)
        {
            try
            {
                return codeToInvoke.Invoke();
            }
            catch (Exception ex)
            {
                if (codeToInvokeOnFail != null)
                {
                    return codeToInvokeOnFail.Invoke();
                }
                //ex.ToLog();
                throw;
            }
        }
        public static void ExecuteWithExceptionHandling(this Action codeToInvoke, string exceptionString = "", Action codeToInvokeOnFail = null)
        {
            try
            {
                codeToInvoke.Invoke();
            }
            catch (Exception ex)
            {
                if (codeToInvokeOnFail != null)
                {
                    codeToInvokeOnFail.Invoke();
                }
                //ex.ToLog();
                throw;
            }
        }

        public static void WithClient<T>(this T proxy, Action<T> codeToExecute)
        {
            codeToExecute.Invoke(proxy);
            var disposableClient = proxy as IDisposable;
            if (disposableClient != null)
            {
                disposableClient.Dispose();
            }
        }
        public static void ExecuteWithIgnoreException(this Action codeToInvoke, Action codeToInvokeOnFail = null)
        {
            try
            {
                codeToInvoke.Invoke();
            }
            catch (Exception ex)
            {
                if (codeToInvokeOnFail != null)
                {
                    codeToInvokeOnFail.Invoke();
                }
                //ex.ToLog();
            }
        }
        public static T ExecuteWithIgnoreException<T>(this Func<T> codeToInvoke, Func<T> codeToInvokeOnFail = null)
        {
            try
            {
                return codeToInvoke.Invoke();
            }
            catch (Exception ex)
            {
                //ex.ToLog();
                if (codeToInvokeOnFail != null)
                {
                    return codeToInvokeOnFail.Invoke();
                }

                return default(T);
            }
        }
        public static void ExecuteWithExceptionHandlingToConsole(this Action codeToInvoke, string ExceptionString = "")
        {
            try
            {
                codeToInvoke.Invoke();
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ExceptionString))
                {
                    System.Console.WriteLine(ExceptionString);
                }
                var output = ex.Message + ex.StackTrace;
                System.Console.WriteLine(output);
            }
        }


    }
}
