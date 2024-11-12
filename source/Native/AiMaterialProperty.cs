namespace OpenAssetImporter.Native;

public unsafe struct AiMaterialProperty
{
    public AiString key;
    public TextureType semantic;
    public uint index;
    public uint dataLength;
    public PropertyType type;
    public char* data;
}
