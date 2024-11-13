using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Cottage;

public class Sky
{
    private int SkyTexture { get; set; }
    
    private Box3 _cubeBox = new Box3(-120f, -120f, -120f, 120f, 120f, 120f);
    private Box2 _skyTextureBox = new Box2(0f, 0f, 1f, 1f);

    public Sky(int skyTexture)
    {
        SkyTexture = skyTexture;
    }

    public void Draw()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, SkyTexture);
        
        
        GL.Begin(PrimitiveType.Quads);
        
        //Передняя грань
        GL.Normal3(0f, 0f, -1f);
        GL.TexCoord2(_skyTextureBox.Max.X * 3 / 4, _skyTextureBox.Max.Y *  2 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Min.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Min.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X, _skyTextureBox.Max.Y / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Max.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 3 / 4, _skyTextureBox.Max.Y / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Max.Y, _cubeBox.Max.Z);
        
        //Левая грань
        GL.Normal3(1f, 0f, 0f);
        GL.TexCoord2(_skyTextureBox.Min.X, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Min.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Min.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Max.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Min.X, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Max.Y, _cubeBox.Max.Z);
        
        //Задняя грань
        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(_skyTextureBox.Max.X * 1 / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Min.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Min.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Max.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 1 / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Max.Y, _cubeBox.Min.Z);
        
        //правая грань
        GL.Normal3(-1f, 0f, 0f);
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Min.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 3 / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Min.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 3 / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Max.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X  * 2 / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Max.Y, _cubeBox.Min.Z);
        
        //нижняя грань
        GL.Normal3(0f, 1f, 0f);
        GL.TexCoord2(_skyTextureBox.Max.X * 1 / 4, _skyTextureBox.Max.Y);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Min.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Max.Y);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Min.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Min.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 1 / 4, _skyTextureBox.Max.Y * 2 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Min.Y, _cubeBox.Min.Z);
        
        //верхняя грань
        GL.Normal3(0f, -1f, 0f);
        GL.TexCoord2(_skyTextureBox.Max.X * 1 / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Max.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Max.Y * 1 / 3);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Max.Y, _cubeBox.Min.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 2 / 4, _skyTextureBox.Min.Y);
        GL.Vertex3(_cubeBox.Max.X, _cubeBox.Max.Y, _cubeBox.Max.Z);
        
        GL.TexCoord2(_skyTextureBox.Max.X * 1 / 4, _skyTextureBox.Min.Y);
        GL.Vertex3(_cubeBox.Min.X, _cubeBox.Max.Y, _cubeBox.Max.Z);
        
        GL.End();
    }
}