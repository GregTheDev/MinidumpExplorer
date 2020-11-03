using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbgHelp.Symbols.Tests
{
    [TestClass]
    public class SymbolDownloaderTests
    {
        private const string SEARCH_PATH = @"srv*{{temp_folder}}*https://msdl.microsoft.com/download/symbols";
        private static SymbolDownloader _symbolDownloader;
        private static string _targetFolder;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _targetFolder = Path.Combine(Path.GetTempPath(), "DbgHelp.Symbols.Tests");

            CleanTargetFolder(_targetFolder);

            Directory.CreateDirectory(_targetFolder);

            string searchPath = SEARCH_PATH.Replace("{{temp_folder}}", _targetFolder);

            _symbolDownloader = SymbolDownloader.Open(searchPath);
        }

        [ClassCleanup]
        public static void Shutdown()
        {
            _symbolDownloader.Close();

            CleanTargetFolder(_targetFolder);
        }

        private static void CleanTargetFolder(string targetFolder)
        {
            if (Directory.Exists(_targetFolder))
                Directory.Delete(_targetFolder, true);
        }

        [TestMethod]
        public void Download_Should_RetrieveFile()
        {
            uint timestamp = uint.Parse("4D8C16AC", NumberStyles.AllowHexSpecifier);
            uint imageSize = uint.Parse("005AB000", NumberStyles.AllowHexSpecifier);

            string downloadedImagePath =_symbolDownloader.DownloadImage("mscorwks.dll", timestamp, imageSize);

            Assert.IsNotNull(downloadedImagePath);
            Assert.IsTrue(File.Exists(downloadedImagePath));
        }
    }
}
