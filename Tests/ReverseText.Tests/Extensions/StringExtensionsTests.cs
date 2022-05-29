using NUnit.Framework;
using ReverseText.Extensions;
using System;
using System.Linq;

namespace ReverseText.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [SetUp]
        public void Setup() { }

        [TestCase("", "")]
        public void Reverse_EmptyString_ShouldReverseSuccessfully(string text, string expectedReversedText)
        {
            var reversedText = text.Reverse();

            Assert.AreEqual(reversedText, expectedReversedText);
        }

        [TestCase("a", "a")]
        [TestCase("A", "A")]
        public void Reverse_SingleCharString_ShouldReverseSuccessfully(string text, string expectedReversedText)
        {
            var reversedText = text.Reverse();

            Assert.AreEqual(reversedText, expectedReversedText);
        }

        [TestCase("abc", "cba")]
        [TestCase("def ghi", "ihg fed")]
        [TestCase("DeF ghI", "Ihg FeD")]
        public void Reverse_MultipleCharString_ShouldReverseSuccessfully(string text, string expectedReversedText)
        {
            var reversedText = text.Reverse();

            Assert.AreEqual(reversedText, expectedReversedText);
        }
    }
}