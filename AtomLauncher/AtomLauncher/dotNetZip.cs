using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;

namespace AtomLauncher
{
    class dotNetZip
    {
        public static void Extract(string zipFileName, string outputDirectory, string excludeCard = "RandomExcludeString74")
        {
            bool exclude = true;
            if (excludeCard == "RandomExcludeString74")
            {
                exclude = false;
            }
            ZipFile zip = ZipFile.Read(zipFileName);
            Directory.CreateDirectory(outputDirectory);
            foreach (ZipEntry e in zip)
            {
                if (exclude)
                {
                    if (!e.FileName.Contains(excludeCard))
                    {
                        e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                else
                {
                    e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
