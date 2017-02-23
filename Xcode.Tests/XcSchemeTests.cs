using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEditor.iOS.Xcode;

namespace UnityEditor.iOS.Xcode.Tests
{
    
    [TestFixture]
    public class XcSchemeUpdating : TextTester
    {
        public XcSchemeUpdating() : base("XcSchemeTestFiles", "XcSchemeTestOutput", debug:false)
        {
        }

        [Test]
        public void OutputWorks()
        {
            TestXmlUpdate("base1.xcscheme", "test1.xcscheme", text => 
            {
                var xcscheme = new XcScheme();
                xcscheme.ReadFromString(text);
                xcscheme.SetBuildConfiguration("ReleaseForRunning");
                return xcscheme.WriteToString();
            });
        }
    }
}
