using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace smesharik;

public class ParametersInPixels(float centerXInPixels, float centerYInPixels, float widthInPixels, float heightInPixels)
{
    public float CenterXInPixels = centerXInPixels;
    public float CenterYInPixels = centerYInPixels;
    public readonly float WidthInPixels = widthInPixels;
    public readonly float HeightInPixels = heightInPixels;
}

class ParametersInNcs
{
    public float XcenterNcs;
    public float YcenterNcs;
    public float WidthInNcs;
    public float HeightInNcs;
}

public class Kopatich
{
    private readonly int _windowWidth;
    private readonly int _windowHeight;

    private ParametersInPixels _paramsInPixels;
    private ParametersInNcs _paramsInNcs;

    public Kopatich(ParametersInPixels paramsInPixels, int windowWidth, int windowHeight)
    {
        _windowWidth = windowWidth;
        _windowHeight = windowHeight;

        _paramsInPixels = paramsInPixels;
        _paramsInNcs = new ParametersInNcs();
        
        ConvertCoordsFromPixelsToNcs(paramsInPixels, ref _paramsInNcs);
    }

    public bool IsClick(Vector2 coords)
    {
        if (coords.X >= _paramsInPixels.CenterXInPixels - _paramsInPixels.WidthInPixels / 1.7 &&
            coords.X <= _paramsInPixels.CenterXInPixels + _paramsInPixels.WidthInPixels / 1.7 &&
            coords.Y >= _paramsInPixels.CenterYInPixels - _paramsInPixels.HeightInPixels / 1.7 &&
            coords.Y <= _paramsInPixels.CenterYInPixels + _paramsInPixels.HeightInPixels / 1.7)
        {
            return true;
        }
        
        return false;
    }
    
    public void UpdateParams(ParametersInPixels paramsInPixels)
    {
        _paramsInPixels = paramsInPixels;
        ConvertCoordsFromPixelsToNcs(paramsInPixels, ref _paramsInNcs);
    }

    private void ConvertCoordsFromPixelsToNcs(
        ParametersInPixels paramsInPixels,
        ref ParametersInNcs paramsInNcs
        )
    {
        float widthScale = 2.0f / _windowWidth;
        float heightScale = 2.0f / _windowHeight;
        
        //Console.WriteLine($"Scale {widthScale} {heightScale}");

        paramsInNcs.WidthInNcs = paramsInPixels.WidthInPixels / _windowWidth;
        paramsInNcs.HeightInNcs = paramsInPixels.HeightInPixels / _windowHeight;

        paramsInNcs.XcenterNcs = (paramsInPixels.CenterXInPixels - (float)_windowWidth / 2) * widthScale;
        paramsInNcs.YcenterNcs = (paramsInPixels.CenterYInPixels - (float)_windowHeight / 2) * heightScale;
        
        //Console.WriteLine($"{paramsInNcs.WidthInNcs} - {paramsInNcs.HeightInNcs}");
    }
    
    public void DrawKopatich()
    {
        DrawHat();
        DrawBody();
        DrawEars();
        DrawEyes();
        DrawEyebrows();
        DrawNose();
        DrawLegs();
        DrawMouth();
        DrawHands();
    }

    private void DrawBody()
    {
        GL.Color4(0.9607f, 0.3882f,0.2078f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs,
            _paramsInNcs.YcenterNcs,
            _paramsInNcs.WidthInNcs,
            _paramsInNcs.HeightInNcs
            );
    }

    private void DrawLegs()
    {
        GL.Color4(0.9607f, 0.3882f,0.2078f, 1.0f);
        
        Utils.DrawEllipseHalf(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs * 0.35f,
            _paramsInNcs.YcenterNcs - _paramsInNcs.HeightInNcs * 1.1f,
            _paramsInNcs.WidthInNcs * 0.3f,
            _paramsInNcs.HeightInNcs * 0.25f
            );
        
        Utils.DrawEllipseHalf(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs * 0.35f,
            _paramsInNcs.YcenterNcs - _paramsInNcs.HeightInNcs * 1.1f,
            _paramsInNcs.WidthInNcs * 0.3f,
            _paramsInNcs.HeightInNcs * 0.25f
        );
    }

    private void DrawEars()
    {
        GL.Color4(0.9607f, 0.3882f,0.2078f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs / 2, 
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.9f, 
            _paramsInNcs.WidthInNcs / 7,
            _paramsInNcs.HeightInNcs / 7
            );
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs / 2, 
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.9f, 
            _paramsInNcs.WidthInNcs / 7,
            _paramsInNcs.HeightInNcs / 7
        );
    }

    private void DrawHat()
    {
        GL.Color4(0.8274f, 0.5764f,0.0235f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.9f,
            _paramsInNcs.WidthInNcs * 0.72f,
            _paramsInNcs.HeightInNcs * 0.62f
        );
        
        GL.Color4(0.9882f, 0.8862f,0.0980f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.9f,
            _paramsInNcs.WidthInNcs * 0.7f,
            _paramsInNcs.HeightInNcs * 0.6f
        );
        
        GL.Color4(0.8274f, 0.5764f,0.0235f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.85f,
            _paramsInNcs.WidthInNcs * 1.12f,
            _paramsInNcs.HeightInNcs * 0.32f
        );
        
        GL.Color4(0.9882f, 0.8862f,0.0980f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.85f,
            _paramsInNcs.WidthInNcs * 1.1f,
            _paramsInNcs.HeightInNcs * 0.3f
            );
    }

    private void DrawEyes()
    {
        GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs * 0.25f,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.2f,
            _paramsInNcs.WidthInNcs * 0.22f,
            _paramsInNcs.HeightInNcs * 0.25f
            );
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs * 0.25f,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.2f,
            _paramsInNcs.WidthInNcs * 0.22f,
            _paramsInNcs.HeightInNcs * 0.25f
        );
        
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f);
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs * 0.2f,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.3f,
            _paramsInNcs.WidthInNcs * 0.07f,
            _paramsInNcs.HeightInNcs * 0.1f
        );
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs * 0.2f,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.3f,
            _paramsInNcs.WidthInNcs * 0.07f,
            _paramsInNcs.HeightInNcs * 0.1f
        );
    }

    private void DrawEyebrows()
    {
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f);
        
        Utils.DrawRectangle(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs * 0.45f,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.45f,
            _paramsInNcs.WidthInNcs * 0.35f,
            _paramsInNcs.HeightInNcs * 0.15f,
            -15.0f
            );
        
        Utils.DrawRectangle(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs * 0.1f,
            _paramsInNcs.YcenterNcs + _paramsInNcs.HeightInNcs * 0.45f,
            _paramsInNcs.WidthInNcs * 0.35f,
            _paramsInNcs.HeightInNcs * 0.15f,
            15.0f
        );
    }

    private void DrawNose()
    {
        GL.Color4(0.5843f, 0.3294f, 0.0078f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs,
            _paramsInNcs.YcenterNcs - _paramsInNcs.HeightInNcs * 0.1f,
            _paramsInNcs.WidthInNcs * 0.25f,
            _paramsInNcs.HeightInNcs * 0.15f
            );
    }

    private void DrawMouth()
    {
        GL.Color4(0.0f, 0.0f, 0.0f, 1.0f);
        GL.LineWidth(5.0f);
        
        GL.Begin(PrimitiveType.Lines);
        
        GL.Vertex2(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs * 0.3f,
            _paramsInNcs.YcenterNcs - _paramsInNcs.HeightInNcs * 0.4f
            );
        
        GL.Vertex2(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs * 0.3f,
            _paramsInNcs.YcenterNcs - _paramsInNcs.HeightInNcs * 0.4f
        );
        
        GL.End();
    }

    private void DrawHands()
    {
        GL.Color4(0.9607f, 0.3882f,0.2078f, 1.0f);
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs - _paramsInNcs.WidthInNcs,
            _paramsInNcs.YcenterNcs,
            _paramsInNcs.WidthInNcs * 0.4f,
            _paramsInNcs.HeightInNcs * 0.2f
            );
        
        Utils.DrawEllipse(
            _paramsInNcs.XcenterNcs + _paramsInNcs.WidthInNcs * 0.9f,
            _paramsInNcs.YcenterNcs - _paramsInNcs.HeightInNcs * 0.1f,
            _paramsInNcs.WidthInNcs * 0.2f,
            _paramsInNcs.HeightInNcs * 0.4f
        );
    }
}