using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using NUnit.Framework;

namespace FileData
{
    public static class Program
    {
        /// <summary>
        /// Determine version and size of file.
        /// </summary>
        /// <param name="args">Functionality to perform and filename.</param>
        /// <returns>Version of file or size of file.</returns>
        public static void Main(string[] args)
        {
            var functionality = args[0];
            var filename = args[1];

            var result = string.Empty;
            var keyword = string.Empty;

            if(functionality.Contains("v"))
            {
                result = GetVersion(functionality, filename);
                keyword = "Version: ";
            }
            else
            {
                result = GetSize(functionality, filename);
                keyword = "Size: ";
            }

            Console.WriteLine(keyword + result);
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        /// <summary>
        /// Get file size.
        /// </summary>
        /// <param name="functionality">Funtionality to perform.</param>
        /// <param name="filename">Filename under test.</param>
        /// <returns>The size of the file.</returns>
        private static string GetSize(string functionality, string filename)
        {
            var result = string.Empty;

            if (functionality == "-s" || functionality == "--s" || functionality == "/s" ||
                 functionality == "--size")
            {
                FileDetails fd = new FileDetails();
                int iSize = fd.Size(filename);
                result = iSize.ToString() + "B";
            }

            return result;
        }

        /// <summary>
        /// Get file version.
        /// </summary>
        /// <param name="functionality">Funtionality to perform.</param>
        /// <param name="filename">Filename under test.</param>
        /// <returns>The version of the file.</returns>
        private static string GetVersion(string functionality, string filename)
        {
            var result = string.Empty;

            if (functionality == "-v" || functionality == "--v" ||
               functionality == "/v" || functionality == "--version")
            {
                FileDetails fd = new FileDetails();
                result = fd.Version(filename);
            }

            return result;
        }

        // Running low on time so will list unit tests

        // separate tests, which send the arguments and validate that a string is returned
        // -v
        //--v
        // /v
        // --version
        // -s
        // --s
        // /s
        // --size
        // null

        // eg:

        /// <summary>
        /// Test that a size string is returned if the input = -s
        /// </summary>
        [Test]
        public static void Test1stSize()
        {
            var testResult = GetSize("-s", "Test.txt");
            
            if(testResult == string.Empty)
            {
                Assert.Fail("String expected");
            }
        }

        /// <summary>
        /// Test that a version string is returned if the input = -v
        /// </summary>
        [Test]
        public static void Test1stVersion()
        {
            var testResult = GetVersion("-v", "Test.txt");

            if (testResult == string.Empty)
            {
                Assert.Fail("String expected");
            }
        }
    }
}
