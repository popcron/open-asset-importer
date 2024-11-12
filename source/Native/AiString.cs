using System.Runtime.InteropServices;

namespace OpenAssetImporter.Native;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public unsafe struct AiString
{
    public uint length;
    public fixed sbyte data[Assimp.MaxLength];

    public readonly override string ToString()
    {
        if (length > 0)
        {
            fixed (sbyte* dataPointer = data)
            {
                return new string(dataPointer, 0, (int)length);
            }
        }
        else
        {
            return string.Empty;
        }
    }
}
