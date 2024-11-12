using System;

namespace OpenAssetImporter;

[Flags]
public enum DefaultLogStream
{
    File = 1,
    StdOut = 2,
    StdErr = 4,
    Debugger = 8
}
