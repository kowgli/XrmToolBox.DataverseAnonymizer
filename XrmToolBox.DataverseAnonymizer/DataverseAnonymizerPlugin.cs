using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox.DataverseAnonymizer
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Dataverse Data Anonymizer"),
        ExportMetadata("Description", "XrmToolBox tool for anonymizing data in the Dataverse"),
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAQVSURBVFhH1VdNiFtVFD7nvaTMJM+ikEILhWYxauYHqlDBhaUjdNFCCxXdabHFhVgXYzMZXEkMUsqYSYYubHU30IWKiF0UHLDQFl0MOAvFTlokYgqzaDGLQmM7THLv8Zz7bp5NG5OXlyr4QXLP/XnvfPfcc849DyECJrK5Y4DwKgCOIdAIEdYQYSXW2pz/+cyZO3ZZKAxEYOLECQ9GE5cRcI/0CeAOEmzwW7abBQB1pfHwjcWPV2y/LxzbhgKOJs+JciJaJ00HK6XiU2vl4g7SraeZjihNOai/2j0z86T/RH+EJvDszPtpbt4QGZGOVhYXlkUWVBYXq03Sh9kktxBxZzMWM+vCIDQBJ6YPWLG6VipdsXKAX8vlOiFdFBkJJ81gCIQmsKW1+QWAfplIHbdDj4CPJ+YLGNoRI0VBN0xlsxlC93sWU8Y/HjiiXhjICf8JRjm4l1lMsR9c2rY1ecmf6Y+hLRAo90PxB7r/58HK2bMNf7Y/hiJg8sJI4rp4PncHVi4Y7ghGkx+JcgJajaJcMBQBzoL7TQtUiqJcMBQB3nlGWiT6yQxEwHAWQDzFTcFV6pY/8j9E5Ch4JptNxdEtioyk5q+VyzfMxICIfASo4h43x+RHiO3reGBEJuDG1QYRXDG/AXJ/JEi2M0knJPbl87GJkyfHbLcnevrAeC63n2N9hm+5QxxyF7d5yVeuFgotO90Vu/L5Ee/uvfP85tfEOoj6s4bnXbhZKGzYJR3oSmAyO3eIm9M8O+WPBFhukjoqd7/td0CsxFXTtyy+5I9YcKECRPONrclPHybSQWAil9sOGj/nAnPaDMiDCJ/w9bqKDpzj5VIV1fmhJVDw5aajaqNKtZrxeBo0HOC88BbPi+nrBPodAiflELwbbITgGjlcTS0sBIkrIGCUE3LBCRmjGOCD1BOJpbbJ7e6YhF+W9cAyV0bHWUmQnMazc0d4U6fNuwEaHLYvtMP2bwKzuR9ttdvzVpucnZ0mwNd5rVipHX6ibEUTfH29XLzgD3XC30DiPKs8IgVsykvulc0ZAsLQQfiGxSorfz7qxdIPlsQv9igLa6XihyYP8F9eWi63T/1bygX+u8mvKQnelgZtSv2D5XrKS+zoF2aPA5Ozud/FCuwL404c3BdlkON85b9Q7gNNWa/QnXa0vdMFU+/N7Rkk4w0K+WISHZygRqTvEO1GyXYO4XdmRQCq2Q/OGndusnnWtUM1VKqm9JaW27xb7+YrJpSV8sh10xzSY+xbu/jZMQ5Ldjr5kIWOTzZNNGeiQEKL+bzJi59j5RmuNAzDxw4izoJY5eBfZYe/WikvLAV5oA25SG43GhmXnLRG2Cm7YJOl+XtQQsePe+K2O0lO0cSWwXWWxXq/aU1Vvg9q4DjVB5OTD4C/AB7tqDI1d8pWAAAAAElFTkSuQmCC"),
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class DataverseAnonymizerPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new DataverseAnonymizerPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public DataverseAnonymizerPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}