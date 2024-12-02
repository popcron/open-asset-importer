using System.IO;

namespace OpenAssetImporter.Tests;

public class ImportTests
{
    [Test]
    public void LoadApples()
    {
        using Scene scene = new("Assets/apples.fbx");
        Assert.That(scene.IsDisposed, Is.False);
    }

    [Test]
    public void LoadCubeAndCheckData()
    {
        using Scene scene = new("Assets/cube.fbx");
        Assert.That(scene.IsDisposed, Is.False);
        Assert.That(scene.Meshes.Length, Is.EqualTo(1));

        Mesh mesh = scene.Meshes[0];
        Assert.That(mesh.Name, Is.EqualTo("Cube"));
        Assert.That(mesh.VertexCount, Is.EqualTo(6 * 4));
        Assert.That(mesh.FaceCount, Is.EqualTo(6));

        Assert.That(mesh.Faces.Length, Is.EqualTo(6));
        Assert.That(mesh.Faces[0].Indices.Length, Is.EqualTo(4));
        Assert.That(mesh.Faces[1].Indices.Length, Is.EqualTo(4));
        Assert.That(mesh.Faces[2].Indices.Length, Is.EqualTo(4));
        Assert.That(mesh.Faces[3].Indices.Length, Is.EqualTo(4));
        Assert.That(mesh.Faces[4].Indices.Length, Is.EqualTo(4));
        Assert.That(mesh.Faces[5].Indices.Length, Is.EqualTo(4));
    }

    [Test]
    public void LoadCubeFromMemory()
    {
        byte[] bytes = File.ReadAllBytes("Assets/cube.fbx");
        using Scene scene = new(bytes);
        Assert.That(scene.IsDisposed, Is.False);
        Assert.That(scene.Meshes.Length, Is.EqualTo(1));

        Node rootNode = scene.RootNode;
        Assert.That(rootNode.Children.Length, Is.EqualTo(1));

        Node firstChild = rootNode.Children[0];
        Assert.That(firstChild.Name, Is.EqualTo("Cube"));
        Assert.That(firstChild.Meshes.Length, Is.EqualTo(1));
        Mesh mesh = scene.Meshes[firstChild.Meshes[0]];
    }
}
