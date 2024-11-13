using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Cottage;

public class Yard
{
    private int GrassTexture { get; set; }
    private int FenceTexture { get; set; }

    public Yard(int grassTexture, int fenceTexture)
    {
        GrassTexture = grassTexture;
        FenceTexture = fenceTexture;
    }

    private Box2 GrassTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 FenceTextureBox { get; set; } = new(0f, 0f, 1f, 1f);

    private Box3 GrassBox { get; set; } = new(-70f, -10f, -70f, 70f, -10f, 70f);
    private Box3 FenceBox { get; set; } = new(-35f, -10f, -25f, 35f, 0f, 25f);

    private const float Offset = 0.1f;


    public void Draw()
    {
        DrawGrass();

        GL.Enable(EnableCap.CullFace);
        GL.CullFace(CullFaceMode.Front);
        DrawFence();
        GL.CullFace(CullFaceMode.Back);
        DrawFence();
        GL.Disable(EnableCap.CullFace);
    }

    private void DrawGrass()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, GrassTexture);
        GL.Begin(PrimitiveType.Quads);

        GL.Normal3(0f, 1f, 0f);

        GL.TexCoord2(GrassTextureBox.Min.X, GrassTextureBox.Min.Y);
        GL.Vertex3(GrassBox.Min.X, GrassBox.Max.Y, GrassBox.Min.Z);

        GL.TexCoord2(GrassTextureBox.Min.X, GrassTextureBox.Max.Y);
        GL.Vertex3(GrassBox.Min.X, GrassBox.Min.Y, GrassBox.Max.Z);

        GL.TexCoord2(GrassTextureBox.Max.X, GrassTextureBox.Max.Y);
        GL.Vertex3(GrassBox.Max.X, GrassBox.Min.Y, GrassBox.Max.Z);

        GL.TexCoord2(GrassTextureBox.Max.X, GrassTextureBox.Min.Y);
        GL.Vertex3(GrassBox.Max.X, GrassBox.Max.Y, GrassBox.Min.Z);

        GL.End();

    }

    private void DrawFence()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, FenceTexture);
        GL.Begin(PrimitiveType.Quads);

        //левая сторона
        GL.Normal3(-1f, 0f, 0f);
        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Max.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Min.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Min.Y, FenceBox.Max.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Max.Y, FenceBox.Max.Z);

        GL.Normal3(1f, 0f, 0f);
        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Min.X + Offset, FenceBox.Max.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Min.X + Offset, FenceBox.Min.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Min.X + Offset, FenceBox.Min.Y, FenceBox.Max.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Min.X + Offset, FenceBox.Max.Y, FenceBox.Max.Z);

        //задняя сторона
        GL.Normal3(0f, 0f, -1f);
        GL.TexCoord2(FenceTextureBox.Min.X, FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Max.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Max.X, FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Max.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Max.X, FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Min.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Min.X, FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Min.Y, FenceBox.Min.Z);

        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(FenceTextureBox.Min.X, FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Max.Y, FenceBox.Min.Z + Offset);

        GL.TexCoord2(FenceTextureBox.Max.X, FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Max.Y, FenceBox.Min.Z + Offset);

        GL.TexCoord2(FenceTextureBox.Max.X, FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Min.Y, FenceBox.Min.Z + Offset);

        GL.TexCoord2(FenceTextureBox.Min.X, FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Min.X, FenceBox.Min.Y, FenceBox.Min.Z + Offset);

        //правая сторона
        GL.Normal3(1f, 0f, 0f);
        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Max.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Max.Y, FenceBox.Max.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Min.Y, FenceBox.Max.Z);

        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Max.X, FenceBox.Min.Y, FenceBox.Min.Z);

        GL.Normal3(-1f, 0f, 0f);
        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Max.X - Offset, FenceBox.Max.Y, FenceBox.Min.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Min.Y);
        GL.Vertex3(FenceBox.Max.X - Offset, FenceBox.Max.Y, FenceBox.Max.Z);

        GL.TexCoord2(FenceTextureBox.Max.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Max.X - Offset, FenceBox.Min.Y, FenceBox.Max.Z);

        GL.TexCoord2(FenceTextureBox.Min.X , FenceTextureBox.Max.Y);
        GL.Vertex3(FenceBox.Max.X - Offset, FenceBox.Min.Y, FenceBox.Min.Z);

        GL.End();
    }
}