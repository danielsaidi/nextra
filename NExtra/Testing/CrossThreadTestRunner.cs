using System;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;

namespace NExtra.Testing
{
    /// <summary>
    /// This class can be used to test components that depend
    /// on STA, like WPF controls.
    /// 
    /// To use this class when testing, create an instance of
    /// it and call the RunInSTA or RunInMTA methods.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// Original:   http://www.hedgate.net/articles/2007/01/08/instantiating-a-wpf-control-from-an-nunit-test/
    /// </remarks>
    public class CrossThreadTestRunner
    {
        private Exception lastException;
        

        /// <summary>
        /// Run an operation in a certain apartment state.
        /// </summary>
        private void Run(ThreadStart userDelegate, ApartmentState apartmentState)
        {
            lastException = null;

            var thread = new Thread(delegate()
            {
                try
                {
                    userDelegate.Invoke();
                }
                catch (Exception e)
                {
                    lastException = e;
                }
            });
            
            thread.SetApartmentState(apartmentState);
            thread.Start();
            thread.Join();

            if (lastException != null)
                ThrowExceptionPreservingStack(lastException);
        }

        /// <summary>
        /// Run an operation in MTA apartment state.
        /// </summary>
        public void RunInMTA(ThreadStart userDelegate)
        {
            Run(userDelegate, ApartmentState.MTA);
        }

        /// <summary>
        /// Run an operation in STA apartment state.
        /// </summary>
        public void RunInSTA(ThreadStart userDelegate)
        {
            Run(userDelegate, ApartmentState.STA);
        }

        /// <summary>
        /// Operation that is called as soon as an exception is thrown.
        /// </summary>
        [ReflectionPermission(SecurityAction.Demand)]
        private static void ThrowExceptionPreservingStack(Exception exception)
        {
            var remoteStackTraceString = typeof(Exception).GetField("_remoteStackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
            if (remoteStackTraceString != null)
                remoteStackTraceString.SetValue(exception, exception.StackTrace + Environment.NewLine);
            throw exception;
        }
    }
}
