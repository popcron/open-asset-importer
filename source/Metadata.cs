using OpenAssetImporter.Native;

namespace OpenAssetImporter;

public unsafe readonly struct Metadata
{
    private readonly AiMetadata* metadata;

    public readonly int Count => (int)metadata->numProperties;

    public readonly (string key, MetadataEntry value) this[int index]
    {
        get
        {
            string key = metadata->keys[index].ToString();
            AiMetadataEntry value = metadata->values[index];
            return (key, new(value.dataType, value.data));
        }
    }

    internal Metadata(AiMetadata* metadata)
    {
        this.metadata = metadata;
    }
}
