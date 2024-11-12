namespace OpenAssetImporter.Native;

public unsafe struct AiMetadata
{
    public uint numProperties;
    public AiString* keys;
    public AiMetadataEntry* values;
}