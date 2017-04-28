using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutraCoisaConsole;
using System.IO;

namespace OutraCoisa.Tests
{
    [TestClass]
    public class TradutorDeArquivoTests
    {
        public TradutorDeArquivo Tradutor { get; set; }
        [TestInitialize]
        public void BeforeTests()
        {
            Tradutor = new TradutorDeArquivo();
        }

        [TestMethod]
        public void ReadFile_WhenFileHasLines_ShowReturnListCollection()
        {
            Tradutor.SetFilePath(@"C:\Users\User\Documents\Visual Studio 2017\Projects\OutraCoisa\race.log");

            var result = Tradutor.ReadFile();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadFile_WhenFilePathIsNull_ShowThrowAnException()
        {
            var result = Tradutor.ReadFile();
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ReadFile_WhenFilePathIsInvalid_ShowThrowAnException()
        {
            Tradutor.SetFilePath(@"C:\Users\User\Documents\Visual Studio 2017\Projects\OutroNegocio\race.log");

            var result = Tradutor.ReadFile();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadFile_WhenFileNotExists_ShowThrowAnException()
        {
            Tradutor.SetFilePath(@"C:\Users\User\Documents\Visual Studio 2017\Projects\OutraCoisa\otherRace.log");

            var result = Tradutor.ReadFile();

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
