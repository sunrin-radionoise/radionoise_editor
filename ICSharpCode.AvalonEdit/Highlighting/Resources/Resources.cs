// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.IO;

namespace ICSharpCode.AvalonEdit.Highlighting
{
    static class Resources
    {
        static readonly string Prefix = typeof(Resources).FullName + ".";

        public static Stream OpenStream(string name)
        {
            Stream s = typeof(Resources).Assembly.GetManifestResourceStream(Prefix + name);
            if (s == null)
                throw new FileNotFoundException("The resource file '" + name + "' was not found.");
            return s;
        }

        internal static void RegisterBuiltInHighlightings(HighlightingManager.DefaultHighlightingManager hlm)
        {
            /*
             * Make a Theme
             * Register Name을 XmlDoc_Dark/XmlDoc_White식으로 관리하면 Theme별로 Syntax Highlighting을 관리할 수 있다.
             */
            #region Dark_Theme
            hlm.RegisterHighlighting("XmlDoc", null, "XmlDoc_Dark.xshd");
            hlm.RegisterHighlighting("C#", new[] { ".cs" }, "CSharp-Mode_Dark.xshd");

            hlm.RegisterHighlighting("JavaScript", new[] { ".js" }, "JavaScript-Mode_Dark.xshd");
            hlm.RegisterHighlighting("HTML", new[] { ".htm", ".html" }, "HTML-Mode_Dark.xshd");
            hlm.RegisterHighlighting("ASP/XHTML", new[] { ".asp", ".aspx", ".asax", ".asmx", ".ascx", ".master" }, "ASPX_Dark.xshd");

            hlm.RegisterHighlighting("Boo", new[] { ".boo" }, "Boo_Dark.xshd");
            hlm.RegisterHighlighting("Coco", new[] { ".atg" }, "Coco-Mode_Dark.xshd");
            hlm.RegisterHighlighting("CSS", new[] { ".css" }, "CSS-Mode_Dark.xshd");
            hlm.RegisterHighlighting("C++", new[] { ".c", ".h", ".cc", ".cpp", ".hpp" }, "CPP-Mode_Dark.xshd");
            hlm.RegisterHighlighting("Java", new[] { ".java" }, "Java-Mode_Dark.xshd");
            hlm.RegisterHighlighting("Patch", new[] { ".patch", ".diff" }, "Patch-Mode_Dark.xshd");
            hlm.RegisterHighlighting("PowerShell", new[] { ".ps1", ".psm1", ".psd1" }, "PowerShell_Dark.xshd");
            hlm.RegisterHighlighting("PHP", new[] { ".php" }, "PHP-Mode_Dark.xshd");
            hlm.RegisterHighlighting("TeX", new[] { ".tex" }, "Tex-Mode_Dark.xshd");
            hlm.RegisterHighlighting("VBNET", new[] { ".vb" }, "VBNET-Mode_Dark.xshd");
            hlm.RegisterHighlighting("XML", (".xml;.xsl;.xslt;.xsd;.manifest;.config;.addin;" +
                                             ".xshd;.wxs;.wxi;.wxl;.proj;.csproj;.vbproj;.ilproj;" +
                                             ".booproj;.build;.xfrm;.targets;.xaml;.xpt;" +
                                             ".xft;.map;.wsdl;.disco;.ps1xml;.nuspec").Split(';'),
                                     "XML-Mode_Dark.xshd");
            hlm.RegisterHighlighting("MarkDown", new[] { ".md" }, "MarkDown-Mode_Dark.xshd");
            #endregion
            #region White_Theme
            #endregion
        }
    }
}
