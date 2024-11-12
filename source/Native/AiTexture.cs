using System;

namespace OpenAssetImporter.Native;

public unsafe struct AiTexture
{
    public uint width;
    public uint height;
    public fixed sbyte formatHint[9];
    public AiTexel* data;
    public AiString fileName;

    public readonly ReadOnlySpan<char> FormatHintString
    {
        get
        {
            fixed (sbyte* charPtr = formatHint)
            {
                int maxLen = 9;
                int nonTerminatorCount = 0;
                for (int i = 0; i < maxLen; i++)
                {
                    if (formatHint[i] == '\0')
                    {
                        break;
                    }

                    nonTerminatorCount++;
                }

                if (nonTerminatorCount == 0)
                {
                    return default;
                }
                else
                {
                    return new ReadOnlySpan<char>(charPtr, nonTerminatorCount);
                }
            }
        }
    }
}
