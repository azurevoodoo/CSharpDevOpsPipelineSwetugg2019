using System;
using HelloWorldApp.Common;
using Xunit;

namespace HelloWorldApp.Tests
{
    public sealed class GreeterTests
    {
        public sealed class TheGreaterMethod
        {
            [Fact]
            public void Should_Greet_World()
            {
                // Given
                const string name = "World";
                const string expect = "Hello World!";

                // When
                var result = Greeter.GetGreeting(name);

                // Then
                Assert.Equal(expect, result);
            }

            [Fact]
            public void Should_Throw_On_Null_Name()
            {
                // Given
                const string name = null;

                // When
                var result = Record.Exception(() => Greeter.GetGreeting(name));

                // Then
                Assert.NotNull(result);
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal($"Value cannot be null. (Parameter 'name')", result.Message);
            }
        }

        [Fact]
        public void Should_Not_Fail_Test()
        {
            Assert.NotEqual("true", Environment.GetEnvironmentVariable("hello_world_fail_test"));
        }
    }
}
