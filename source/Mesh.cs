using OpenAssetImporter.Native;
using System;
using System.Numerics;

namespace OpenAssetImporter;

public unsafe readonly struct Mesh
{
    private readonly AiMesh* mesh;

    public readonly string Name => mesh->name.ToString();
    public readonly bool HasVertices => mesh->vertices is not null;
    public readonly bool HasNormals => mesh->normals is not null;
    public readonly bool HasTangents => mesh->tangets is not null;
    public readonly bool HasBiTangents => mesh->biTangents is not null;
    public readonly int VertexCount => (int)mesh->numVertices;
    public readonly int FaceCount => (int)mesh->numFaces;
    public readonly int BoneCount => (int)mesh->numBones;
    public readonly int MaterialIndex => (int)mesh->materialIndex;
    public readonly PrimitiveType PrimitiveType => mesh->primitiveTypes;
    public readonly MorphingMethod MorphMethod => mesh->morphMethod;

    public readonly (Vector3 min, Vector3 max) BoundingBox
    {
        get
        {
            AiAABB aabb = mesh->aabb;
            return (aabb.min, aabb.max);
        }
    }

    public readonly ReadOnlySpan<Vector3> Vertices
    {
        get
        {
            Vector3* vertices = mesh->vertices;
            return new ReadOnlySpan<Vector3>(vertices, (int)mesh->numVertices);
        }
    }

    public readonly ReadOnlySpan<Face> Faces
    {
        get
        {
            return new ReadOnlySpan<Face>(mesh->faces, (int)mesh->numFaces);
        }
    }

    public readonly ReadOnlySpan<Vector3> Normals
    {
        get
        {
            Vector3* normals = mesh->normals;
            return new ReadOnlySpan<Vector3>(normals, (int)mesh->numVertices);
        }
    }

    public readonly ReadOnlySpan<Vector3> Tangents
    {
        get
        {
            Vector3* tangents = mesh->tangets;
            return new ReadOnlySpan<Vector3>(tangents, (int)mesh->numVertices);
        }
    }

    public readonly ReadOnlySpan<Vector3> BiTangents
    {
        get
        {
            Vector3* biTangents = mesh->biTangents;
            return new ReadOnlySpan<Vector3>(biTangents, (int)mesh->numVertices);
        }
    }

    internal Mesh(AiMesh* mesh)
    {
        this.mesh = mesh;
    }

    public readonly override string ToString()
    {
        return Name;
    }

    public readonly ReadOnlySpan<Vector4> GetColors(int index)
    {
        Vector4* colors = mesh->colors[index];
        return new ReadOnlySpan<Vector4>(colors, (int)mesh->numVertices);
    }

    public readonly ReadOnlySpan<Vector3> GetTextureCoordinates(int index)
    {
        Vector3* uv = mesh->textureCoordinates[index];
        return new ReadOnlySpan<Vector3>(uv, (int)mesh->numVertices);
    }

    public readonly int GetUVComponentCount(int index)
    {
        return (int)mesh->uvComponentCounts[index];
    }

    public readonly string GetTextureCoordinateName(int index)
    {
        return mesh->textureCoordinateNames[index]->ToString();
    }
}