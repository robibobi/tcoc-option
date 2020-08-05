using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Tcoc.OptionType.UnitTests
{
    public class DictionaryExtensionTests
    {
        [Fact]
        public void GetOption_DictIsNull_ThrowsNullArgException()
        {
            Dictionary<string, string> dict = null;

            Should.Throw<ArgumentNullException>(() => dict.GetOption("key"));
        }

        [Fact]
        public void GetOption_KeyExists_ReturnsSomeValue()
        {
            var dict = new Dictionary<string, string>(){
                ["a"] = "Hello,",
                ["b"] = "World!"
            };

            var result = dict.GetOption("a");

            result.ShouldBeOfType<Some<string>>();
            result.AsSome().Value.ShouldBe("Hello,");
        }

        [Fact]
        public void GetOption_KeyDoesNotExist_ReturnsNone()
        {
            var dict = new Dictionary<string, string>();

            var result = dict.GetOption("a");

            result.ShouldBeOfType<None<string>>();
        }
    }
}