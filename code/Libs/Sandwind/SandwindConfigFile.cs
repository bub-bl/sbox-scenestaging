using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Sandbox.Extensions;
using Sandbox.Libs.Sandwind.Attributes;
using Sandbox.Libs.Sandwind.Css;
using Sandbox.UI;

namespace Sandbox.Libs.Sandwind;

[GameResource("Sandwind Config", FileExtension, "A sandwind config", Icon = "ballot", Category = "Sandwind")]
public class SandwindConfigFile : GameResource
{
    public const string FileExtension = "swcfg";

    public string ClassPrefix { get; set; } = "sw";
    public string OutputPath { get; set; } = "data/css/app.scss";
    public bool AutoCompile { get; set; } = true;

    public ThemeSettings Theme { get; set; }

    [Category("Classes")] public List<SandwindClassFile> Classes { get; set; } = new();

    public struct ClassList
    {
        public List<SandwindClassFile> List { get; set; }
    }
    
    public struct ThemeSettings
    {
        public List<FontSizeSettings> FontSize { get; set; }
        public List<FontFamilySettings> FontFamily { get; set; }
        public ExtendSettings Extend { get; set; }

        public struct FontSizeSettings
        {
            [Placeholder("xs")] public string Key { get; set; }
            [Placeholder("0.7rem")] public string Value { get; set; }
        }

        public struct FontFamilySettings
        {
            [Placeholder("xs")] public string Key { get; set; }
            [Placeholder("0.7rem")] public string Value { get; set; }
        }

        public struct ExtendSettings
        {
            public struct ColorSettings
            {
                [Placeholder("accent")] public string Key { get; set; }
                [Placeholder("hsl(235 45% 53%)")] public string Value { get; set; }
            }

            public List<ColorSettings> Color { get; set; }
        }
    }
}

[GameResource("Sandwind Class", FileExtension, "A sandwind class", Icon = "home", Category = "Sandwind")]
public class SandwindClassFile : GameResource
{
    public const string FileExtension = "swc";

    public string ClassName { get; set; }
    public PseudoClass PseudoClass { get; set; } = PseudoClass.None;
    public GeneratorSettings Generator { get; set; }
    // [ResourceType("swgen")] public ClassGenerator Generator { get; set; }

    public struct GeneratorSettings
    {
        [Range(1, 100, 1)] public int StepCount { get; set; }
        [Range(1, 100, 1)] public int StepValue { get; set; }
    }
}