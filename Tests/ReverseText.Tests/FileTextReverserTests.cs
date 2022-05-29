using Moq;
using NUnit.Framework;
using ReverseText.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseText.Tests
{
    public class FileTextReverserTests
    {
        private Mock<IFileProvider> _fileProvider;
        private FileTextReverser _fileTextReverser;
        private const string _filePath = "textfile.txt";

        [SetUp]
        public void Setup()
        {
            _fileProvider = new Mock<IFileProvider>();
            _fileTextReverser = new FileTextReverser(_fileProvider.Object);
        }

        public static IEnumerable<TestCaseData> SingleLineTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new List<string> { "tesT" },
                    new List<string> { "Tset" });

                yield return new TestCaseData(
                    new List<string> { "only one line" },
                    new List<string> { "enil eno ylno" });

                yield return new TestCaseData(
                    new List<string> { "" },
                    new List<string> { "" });
            }
        }

        public static IEnumerable<TestCaseData> MultipleLineTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new List<string> { "1st line", "2nd line" },
                    new List<string> { "enil ts1", "enil dn2" });

                yield return new TestCaseData(
                    new List<string> { "1st line", "2ND LINE", "3rd Line", "4th" },
                    new List<string> { "enil ts1", "ENIL DN2", "eniL dr3", "ht4" });

                yield return new TestCaseData(
                    new List<string> { "1st line", "", "3rd Line", "" },
                    new List<string> { "enil ts1", "", "eniL dr3", "" });
            }
        }

        [TestCaseSource("SingleLineTestCases")]
        public void ReverseFileContents_WithSingleLine_ShouldReturnSuccessfully(IEnumerable<string> fileContent, IEnumerable<string> expectedReverseContents)
        {
            _fileProvider.Setup(x => x.ReadLines(It.IsAny<string>(), It.IsAny<Encoding>())).Returns(fileContent);

            var reverseContents = _fileTextReverser.ReverseFileContents(_filePath);

            AssertReverseFileContentsResult(_filePath, reverseContents, expectedReverseContents);
        }

        [TestCaseSource("MultipleLineTestCases")]
        public void ReverseFileContents_WithMultipleLines_ShouldReturnSuccessfully(IEnumerable<string> fileContent, IEnumerable<string> expectedReverseContents)
        {
            _fileProvider.Setup(x => x.ReadLines(It.IsAny<string>(), It.IsAny<Encoding>())).Returns(fileContent);

            var reverseContents = _fileTextReverser.ReverseFileContents(_filePath);

            AssertReverseFileContentsResult(_filePath, reverseContents, expectedReverseContents);
        }

        private void AssertReverseFileContentsResult(string filePath, string reverseContents, IEnumerable<string> expectedReverseContents)
        {
            Assert.AreEqual(reverseContents, string.Join(Environment.NewLine, expectedReverseContents));

            _fileProvider.Verify(x => x.ReadLines(filePath, Encoding.UTF8), Times.Exactly(1));
            _fileProvider.Verify(x => x.WriteAllLines(filePath, expectedReverseContents.ToArray(), Encoding.UTF8), Times.Exactly(1));
        }
    }
}