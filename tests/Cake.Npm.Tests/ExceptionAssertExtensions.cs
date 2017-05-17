namespace Cake.Npm.Tests
{
    using System;
    using Xunit;

    public static class ExceptionAssertExtensions
    {
        public static void IsArgumentException(this Exception exception, string parameterName)
        {
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal(parameterName, ((ArgumentException)exception).ParamName);
        }

        public static void IsArgumentNullException(this Exception exception, string parameterName)
        {
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal(parameterName, ((ArgumentNullException)exception).ParamName);
        }

        public static void IsUriFormatException(this Exception exception)
        {
            Assert.IsType<UriFormatException>(exception);
        }
    }
}
