using OpenAssetImporter.Native;
using System;
using System.Numerics;

namespace OpenAssetImporter;

public unsafe readonly struct Node
{
    private readonly AiNode* node;

    public readonly string Name => node->name.ToString();
    public readonly Metadata Metadata => new(node->metadata);
    public readonly bool HasParent => node->parent is not null;
    public readonly ref Matrix4x4 Transformation => ref node->transformation;

    public readonly Node Parent
    {
        get
        {
            ThrowIfParentIsNull();
            return new Node(node->parent);
        }
    }

    public readonly ReadOnlySpan<Node> Children => new ReadOnlySpan<Node>(node->children, (int)node->numChildren);
    public readonly ReadOnlySpan<int> Meshes => new ReadOnlySpan<int>(node->meshes, (int)node->numMeshes);

    internal Node(AiNode* node)
    {
        this.node = node;
    }

    public readonly override string ToString()
    {
        return Name.ToString();
    }

    public readonly bool TryGetParent(out Node parent)
    {
        if (node->parent is null)
        {
            parent = default;
            return false;
        }

        parent = new Node(node->parent);
        return true;
    }

    public readonly void ThrowIfParentIsNull()
    {
        if (node->parent is null)
        {
            throw new NullReferenceException("Parent node is null");
        }
    }
}