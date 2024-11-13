using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Cottage;

public class House
{
    private int WallTexture { get; set; }
    private int DoorTexture { get; set; }
    private int RoofTexture { get; set; }
    private int GraffitiTexture { get; set; }
    private int WindowTexture { get; set; }
    private int AtticBoardsTexture { get; set; }
    
    public House(int wallTexture, int doorTexture, int roofTexture, int grafityTexture, int windowTexture, int atticBoardsTexture)
    {
        WallTexture = wallTexture;
        DoorTexture = doorTexture;
        RoofTexture = roofTexture;
        GraffitiTexture = grafityTexture;
        WindowTexture = windowTexture;
        AtticBoardsTexture = atticBoardsTexture;
    }

    private Box2 WallTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 DoorTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 RoofTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 GrafityTextureBox { get; set; } = new(0f, 0f, 1f, 1f);
    private Box2 WindowTextureCoord { get; set; } = new(0f, 0f, 1f, 1f);

    private Box3 WallBox { get; set; } = new(-20f, -10f, -15f, 0f, 10f, 15f);
    private Box3 DoorBox { get; set; } = new(-12f, -10f, 15.1f, -8f, -3f, 15.1f);
    private Box3 RoofBox { get; set; } = new(-22f, 8f, -17f, 2f, 20f, 17f);
    private Box3[] WindowsBoxes { get; set; } = 
    {
        new Box3(-16f, 2f, 15.1f, -12f, 9f, 15.1f),
        new Box3(-8f, 2f, 15.1f, -4f, 9f, 15.1f),

        new Box3(-20.1f, 0f, -12f, -20.1f, 7f, -8f),
        new Box3(-20.1f, 0f, 8f, -20.1f, 7f, 12f),
        new Box3(-20.1f, 0f, -2f, -20.1f, 7f, 2f),

        new Box3(-16f, 2f, -15.1f, -12f, 9f, -15.1f),
        new Box3(-8f, 2f, -15.1f, -4f, 9f, -15.1f),
        new Box3(-16f, -7f, -15.1f, -12f, 0f, -15.1f),
        new Box3(-8f, -7f, -15.1f, -4f, 0f, -15.1f),
    };



    public void Draw()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        DrawHouseBox();
        DrawHouseRoof();
        DrawHouseWindows();
        DrawDoor();
    }

    //разобраться с мультитекстурированием 
    //повторить формулы тумана
    private void DrawHouseBox()
    {
        GL.ActiveTexture(TextureUnit.Texture1);
        GL.Enable(EnableCap.Texture2D);
        GL.BindTexture(TextureTarget.Texture2D, GraffitiTexture);
        GL.TexEnv(TextureEnvTarget.TextureEnv,TextureEnvParameter.TextureEnvMode,(int)All.Decal);
        
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, WallTexture);

        GL.Begin(PrimitiveType.Quads);

        //задняя стена
        GL.Normal3(0f, 0f, -1f);
        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Min.Z);
        
        //передняя стена
        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Max.Z);
        
        //правая стена
        GL.Normal3(1f, 0f, 0f);
        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Min.Y, WallBox.Min.Z);

        //левая стена
        GL.Normal3(-1f, 0f, 0f);
        GL.MultiTexCoord2(TextureUnit.Texture0, WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.MultiTexCoord2(TextureUnit.Texture1, GrafityTextureBox.Min.X, GrafityTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Min.Z);
        
        GL.MultiTexCoord2(TextureUnit.Texture0, WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.MultiTexCoord2(TextureUnit.Texture1, GrafityTextureBox.Max.X, GrafityTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Min.Y, WallBox.Max.Z);

        GL.MultiTexCoord2(TextureUnit.Texture0, WallTextureBox.Min.X, WallTextureBox.Min.Y);
        GL.MultiTexCoord2(TextureUnit.Texture1, GrafityTextureBox.Max.X, GrafityTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Max.Z);
        
        GL.MultiTexCoord2(TextureUnit.Texture0, WallTextureBox.Max.X, WallTextureBox.Min.Y);
        GL.MultiTexCoord2(TextureUnit.Texture1, GrafityTextureBox.Min.X, GrafityTextureBox.Min.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.End();

    }

    private void DrawHouseRoof()
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
        GL.Vertex3(RoofBox.Center.X, RoofBox.Max.Y, RoofBox.Min.Z);


        GL.TexCoord2(RoofTextureBox.Max.X, RoofTextureBox.Min.Y);
        GL.Vertex3(RoofBox.Center.X, RoofBox.Max.Y, RoofBox.Max.Z);
        //---------------------------------------------------

        GL.Normal3(-1f, 1f, 0f);
        GL.TexCoord2(RoofTextureBox.Max.X, RoofTextureBox.Max.Y);
        GL.Vertex3(RoofBox.Min.X, RoofBox.Min.Y, RoofBox.Max.Z);

        GL.TexCoord2(RoofTextureBox.Max.X, RoofTextureBox.Min.Y);
        GL.Vertex3(RoofBox.Center.X, RoofBox.Max.Y, RoofBox.Max.Z);

        GL.TexCoord2(RoofTextureBox.Min.X, RoofTextureBox.Min.Y);
        GL.Vertex3(RoofBox.Center.X, RoofBox.Max.Y, RoofBox.Min.Z);

        GL.TexCoord2(RoofTextureBox.Min.X, RoofTextureBox.Max.Y);
        GL.Vertex3(RoofBox.Min.X, RoofBox.Min.Y, RoofBox.Min.Z);

        GL.End();

        GL.BindTexture(TextureTarget.Texture2D, AtticBoardsTexture);
        
        GL.Begin(PrimitiveType.Triangles);
        GL.Normal3(0f, 0f, 1f);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Max.Z);

        GL.TexCoord2(
            WallTextureBox.Center.X,
            0);
        GL.Vertex3(RoofBox.Center.X, RoofBox.Max.Y, WallBox.Max.Z);
        //-------------------------------------------
        GL.Normal3(0f, 0f, -1f);

        GL.TexCoord2(WallTextureBox.Min.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Min.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(WallTextureBox.Max.X, WallTextureBox.Max.Y);
        GL.Vertex3(WallBox.Max.X, WallBox.Max.Y, WallBox.Min.Z);

        GL.TexCoord2(
            WallTextureBox.Center.X,
            0);
        GL.Vertex3(RoofBox.Center.X, RoofBox.Max.Y, WallBox.Min.Z);

        GL.End();
    }

    private void DrawHouseWindows()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, WindowTexture);

        GL.Begin(PrimitiveType.Quads);

        foreach (var window in WindowsBoxes)
        {
            SetNormalForWindow(window);
            GL.TexCoord2(WindowTextureCoord.Max.X, WindowTextureCoord.Max.Y);
            GL.Vertex3(window.Min.X, window.Min.Y, window.Min.Z);

            GL.TexCoord2(WindowTextureCoord.Max.X, WindowTextureCoord.Min.Y);
            GL.Vertex3(window.Min.X, window.Max.Y, window.Min.Z);

            GL.TexCoord2(WindowTextureCoord.Min.X, WindowTextureCoord.Min.Y);
            GL.Vertex3(window.Max.X, window.Max.Y, window.Max.Z);

            GL.TexCoord2(WindowTextureCoord.Min.X, WindowTextureCoord.Max.Y);
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

    private void DrawDoor()
    {
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, DoorTexture);

        GL.Begin(PrimitiveType.Quads);

        GL.Normal3(0f, 0f, 1f);
        GL.TexCoord2(DoorTextureBox.Max.X, DoorTextureBox.Max.Y);
        GL.Vertex3(DoorBox.Min.X, DoorBox.Min.Y, DoorBox.Max.Z);

        GL.TexCoord2(DoorTextureBox.Max.X, DoorTextureBox.Min.Y);
        GL.Vertex3(DoorBox.Min.X, DoorBox.Max.Y, DoorBox.Max.Z);

        GL.TexCoord2(DoorTextureBox.Min.X, DoorTextureBox.Min.Y);
        GL.Vertex3(DoorBox.Max.X, DoorBox.Max.Y, DoorBox.Max.Z);

        GL.TexCoord2(DoorTextureBox.Min.X, DoorTextureBox.Max.Y);
        GL.Vertex3(DoorBox.Max.X, DoorBox.Min.Y, DoorBox.Max.Z);
        
        GL.End();
    }
}