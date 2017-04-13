namespace Cake.Npm.Tests
{
    using System;
    using Xunit;

    public static class ExceptionAssertExtensions
    {
        public static void IsArgumentNullException(this Exception exception, string parameterName)
        {
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal(parameterName, ((ArgumentNullException)exception).ParamName);
        }
    }
}
