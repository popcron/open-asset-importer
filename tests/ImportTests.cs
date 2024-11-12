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
    }
}
