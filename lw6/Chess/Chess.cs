using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;


namespace Chess;

public class Chess
{
    private readonly Model _rook;
    private readonly Model _knight;
    private readonly Model _bishop;
    private readonly Model _queen;
    private readonly Model _king;
    private readonly Model _pawn;
    private readonly Model _board;

    private readonly Color4 _blackColor = new Color4(0.2f, 0.2f, 0.2f, 1f);
    private readonly Color4 _whiteColor = new Color4(1f, 1f, 1f, 1f);
    private const float QuadSize = 40f;


    public Chess() 
    {
        _rook = new Model("models/Rook2.stl");

        _knight = new Model("models/Knight2.stl");

        _bishop = new Model("models/Bishop2.stl");

        _queen = new Model("models/Queen2.stl");

        _king = new Model("models/King2.stl");

        _pawn = new Model("models/Pawn2.stl");

        _board = new Model("models/ChessBoard.obj");
    }

    public void Draw()
    {
        DrawBoard();

        GL.PushMatrix();
        GL.Translate(0f, 20f, 0f);
        GL.Rotate(-90f, 1f, 0f, 0f);

        DrawWhiteRooks();
        DrawBlackRooks();

        DrawWhiteKnights();
        DrawBlackKnights();

        DrawWhiteBishops();
        DrawBlackBishops();

        DrawKings();
        DrawQueens();

        DrawPawns();

        GL.PopMatrix();

    }

    private void DrawKings()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize / 2, -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Rotate(180f, 0, 0, 1);
        GL.Color4(_whiteColor);
        _king.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(QuadSize / 2, (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _king.RenderModel();
        GL.PopMatrix();
    }

    private void DrawQueens()
    {
        GL.PushMatrix();
        GL.Translate(-(QuadSize / 2), -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Rotate(180f, 0, 0, 1);
        GL.Color4(_whiteColor);
        _queen.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize / 2), (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _queen.RenderModel();
        GL.PopMatrix();
    }

    private void DrawBoard()
    {
        GL.PushMatrix();
        GL.Scale(90f, 90f, 90f);
        _board.RenderModel();
        GL.PopMatrix();
    }

    private void DrawWhiteRooks()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize * 3 + QuadSize / 2, -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_whiteColor);
        _rook.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize * 3 + QuadSize / 2), -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_whiteColor);
        _rook.RenderModel();
        GL.PopMatrix();
    }

    private void DrawBlackRooks()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize * 3 + QuadSize / 2, (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _rook.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize * 3 + QuadSize / 2), (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _rook.RenderModel();
        GL.PopMatrix();
    }

    private void DrawWhiteKnights()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize * 2 + QuadSize / 2, -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Rotate(180f, 0f, 0f, 1f);
        GL.Color4(_whiteColor);
        _knight.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize * 2 + QuadSize / 2), -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Rotate(180f, 0f, 0f, 1f);
        GL.Color4(_whiteColor);
        _knight.RenderModel();
        GL.PopMatrix();
    }

    private void DrawBlackKnights()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize * 2 + QuadSize / 2, (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _knight.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize * 2 + QuadSize / 2), (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _knight.RenderModel();
        GL.PopMatrix();
    }

    private void DrawWhiteBishops()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize + QuadSize / 2, -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Rotate(180f, 0, 0, 1);
        GL.Color4(_whiteColor);
        _bishop.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize + QuadSize / 2), -(QuadSize * 3 + QuadSize / 2), 0f);
        GL.Rotate(180f, 0, 0, 1);
        GL.Color4(_whiteColor);
        _bishop.RenderModel();
        GL.PopMatrix();
    }

    private void DrawBlackBishops()
    {
        GL.PushMatrix();
        GL.Translate(QuadSize + QuadSize / 2, (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _bishop.RenderModel();
        GL.PopMatrix();

        GL.PushMatrix();
        GL.Translate(-(QuadSize + QuadSize / 2), (QuadSize * 3 + QuadSize / 2), 0f);
        GL.Color4(_blackColor);
        _bishop.RenderModel();
        GL.PopMatrix();
    }

    private void DrawPawns()
    {

        for (int i = -4; i < 4; i++)
        {
            GL.PushMatrix();
            GL.Translate(i * QuadSize + QuadSize / 2, (QuadSize * 2 + QuadSize / 2), 0f);
            GL.Color4(_blackColor);
            _pawn.RenderModel();
            GL.PopMatrix();
        }

        for (int i = -4; i < 4; i++)
        {
            GL.PushMatrix();
            GL.Translate(i * QuadSize + QuadSize / 2, -(QuadSize * 2 + QuadSize / 2), 0f);
            GL.Rotate(180f, 0, 0, 1);
            GL.Color4(_whiteColor);
            _pawn.RenderModel();
            GL.PopMatrix();
        }

    }
}