using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Cottage;

public class Garage
{
    private int WallTexture { get; set; }
    private int GarageDoorTexture { get; set; }
    private int RoofTexture { get; set; }
    private int WindowTexture { get; set; }
    private int AtticBoardsTexture { get; set; }

    public Garage(int wallTexture, int garageDoorTexture, int roofTexture,int windowTexture, int atticBoardsTexture)
    {
        WallTexture = wallTexture;
        GarageDoorTexture = garageDoorTexture;
        RoofTexture = roofTexture;
        WindowTexture = windowTexture;
        AtticBoardsTexture = atticBoardsTexture;
    }

    private Box2 WallTextureBox { get; set; } = new(0.25f, 0.25f, 1f, 1f);
    private Box2 GarageDoorTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 RoofTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 WindowTextureBox { get; set; } = new(0f, 0f, 1f, 1f);

    private Box3 WallBox { get; set; } = new(0f, -10f, 15f, 20f, 0f, -5f);
    private Box3 GarageDoorBox { get; set; } = new(5f, -10f, 15.1f, 15f, -1f, 15.1f);
    private Box3 RoofBox { get; set; } = new(0f, 0f, 17f, 21f, 5f, -7f);

    private Box3[] WindowsBoxes { get; set; } =
    {
        new Box3(20.1f, -8f, 5f, 20.1f, -1f, 9f),
        new Box3(20.1f, -8f, 1f, 20.1f, -1f, 5f),
    };


    public void Draw()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        DrawGarageBox();
        DrawGarageRoof();
        DrawGarageWindows();
        DrawGarageDoor();
    }

    private void DrawGarageBox()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, WallTexture);

        GL.Begin(PrimitiveType.Quads);
        //задняя сторона
        GL.Normal3(0f, 0f, -1f);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Min.Z);
        //------------------------------------------------------
        //левая сторона
        GL.Normal3(-1f, 0f, 0f);
        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Max.Z);
        //-------------------------------------------
        //передняя сторона
        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Max.Z);
        //--------------------------------------------------------
        //правая сторона
        GL.Normal3(1f, 0f, 0f);
        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Min.Z);

        GL.End();

    }

    private void DrawGarageRoof()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, RoofTexture);
        GL.Begin(PrimitiveType.Quads);

        GL.Normal3(1f, 1f, 0f);
        GL.TexCoord2(RoofTextureBox.Max.X, RoofTextureBox.Max.Y);
        GL.Vertex3(RoofBox.Max.X, RoofBox.Min.Y, RoofBox.Max.Z);

        GL.TexCoord2(RoofTextureBox.Min.X, RoofTextureBox.Max.Y);
        GL.Vertex3(RoofBox.Max.X, RoofBox.Min.Y, RoofBox.Min.Z);

        GL.TexCoord2(RoofTextureBox.Min.X, RoofTextureBox.Min.Y);
        GL.Vertex3(RoofBox.Min.X, RoofBox.Max.Y, RoofBox.Min.Z);


        GL.TexCoord2(RoofTextureBox.Max.X, RoofTextureBox.Min.Y);
        GL.Vertex3(RoofBox.Min.X, RoofBox.Max.Y, RoofBox.Max.Z);

        GL.End();
        
        GL.BindTexture(TextureTarget.Texture2D, AtticBoardsTexture);
        
        GL.Begin(PrimitiveType.Triangles);
        GL.Normal3(0f, 0f, 1f);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(
            WallTextureBox.Min.X,
            0);
        GL.Vertex3(RoofBox.Min.X, RoofBox.Max.Y, WallBox.Max.Z);
        //-------------------------------------------
        GL.Normal3(0f, 0f, -1f);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(
            WallTextureBox.Min.X,
            0);
        GL.Vertex3(RoofBox.Min.X, RoofBox.Max.Y, WallBox.Min.Z);
        
        GL.End();
    }

    private void DrawGarageWindows()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, WindowTexture);

        GL.Begin(PrimitiveType.Quads);

        foreach (var window in WindowsBoxes)
        {
            SetNormalForWindow(window);
            GL.TexCoord2(WindowTextureBox.Max.X, WindowTextureBox.Max.Y);
            GL.Vertex3(window.Min.X, window.Min.Y, window.Min.Z);

            GL.TexCoord2(WindowTextureBox.Max.X, WindowTextureBox.Min.Y);
            GL.Vertex3(window.Min.X, window.Max.Y, window.Min.Z);

            GL.TexCoord2(WindowTextureBox.Min.X, WindowTextureBox.Min.Y);
            GL.Vertex3(window.Max.X, window.Max.Y, window.Max.Z);

            GL.TexCoord2(WindowTextureBox.Min.X, WindowTextureBox.Max.Y);
            GL.Vertex3(window.Max.X, window.Min.Y, window.Max.Z);
        }

        GL.End();

    }

    private void SetNormalForWindow(Box3 window)
    {
        if (window.Max.Z >= WallBox.Max.Z)
        {
            GL.Normal3(0f, 0f, 1f);
        }
        else if (window.Min.Z <= WallBox.Min.Z)
        {
            GL.Normal3(0f, 0f, -1f);
        }
        else if (window.Max.X >= WallBox.Max.X)
        {
            GL.Normal3(1f, 0f, 0f);
        }
        else if (window.Min.X <= WallBox.Min.X)
        {
            GL.Normal3(-1f, 0f, 0f);
        }
        else
            GL.Normal3(1f, 0f, 0f);
    }

    private void DrawGarageDoor()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, GarageDoorTexture);

        GL.Begin(PrimitiveType.Quads);

        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(GarageDoorTextureBox.Max.X, GarageDoorTextureBox.Max.Y);
        GL.Vertex3(GarageDoorBox.Min.X, GarageDoorBox.Min.Y, GarageDoorBox.Max.Z);

        GL.TexCoord2(GarageDoorTextureBox.Max.X, GarageDoorTextureBox.Min.Y);
        GL.Vertex3(GarageDoorBox.Min.X, GarageDoorBox.Max.Y, GarageDoorBox.Max.Z);

        GL.TexCoord2(GarageDoorTextureBox.Min.X, GarageDoorTextureBox.Min.Y);
        GL.Vertex3(GarageDoorBox.Max.X, GarageDoorBox.Max.Y, GarageDoorBox.Max.Z);

        GL.TexCoord2(GarageDoorTextureBox.Min.X, GarageDoorTextureBox.Max.Y);
        GL.Vertex3(GarageDoorBox.Max.X, GarageDoorBox.Min.Y, GarageDoorBox.Max.Z);
        
        GL.End();
    }
}