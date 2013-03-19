using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicationsService.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static int CompareVersion(this string version, string versionToCompare)
        {
            Int32[] versionArray;

            try
            {
                versionArray = version.Split('.').Select(v => int.Parse(v)).ToArray();
            }
            catch
            {
                versionArray = new Int32[1];
            }

            Int32[] versionToCompareArray;
            try
            {
                versionToCompareArray = versionToCompare.Split('.').Select(v => int.Parse(v)).ToArray();
            }
            catch
            {
                versionToCompareArray = new Int32[1];
            }

            var lenght = versionArray.Length;
            if (lenght < versionToCompareArray.Length)
                lenght = versionToCompareArray.Length;

            for (int i = 0; i < lenght; i++)
            {
                if (i >= versionArray.Length)
                    return -1;

                if (i >= versionToCompareArray.Length)
                    return 1;

                if (versionArray[i] > versionToCompareArray[i])
                    return 1;

                if (versionArray[i] < versionToCompareArray[i])
                    return -1;
            }

            return 0;
        }
    }
}