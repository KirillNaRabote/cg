using OpenTK.Graphics.OpenGL;

namespace func;

public class FunctionGraph
{
    private List<Coordinates> Coords { get; set; } = [];

    private readonly float _step;
    private readonly float _xMinForInterval;
    private readonly float _xMaxForInterval;
    private readonly float _windowMinX;
    private readonly float _windowMaxX;
    private readonly float _windowMinY;
    private readonly float _windowMaxY;
    
    public FunctionGraph(float step, float xMinForInterval, float xMaxForInterval, float windowMinX, float windowMaxX, float windowMinY, float windowMaxY)
    {
        _step = step;
        _xMinForInterval = xMinForInterval;
        _xMaxForInterval = xMaxForInterval;
        _windowMinX = windowMinX;
        _windowMaxX = windowMaxX;
        _windowMinY = windowMinY;
        _windowMaxY = windowMaxY;
        
        FillXCoordinates();
        CalculateYCoordinates();
    }

    private void FillXCoordinates()
    {
        for (var x = _xMinForInterval; x <= _xMaxForInterval; x += _step)
        {
            var coordinateX = new Coordinates
            {
                X = x
            };
            Coords.Add(coordinateX);
        }
    }

    private float ParabolaFunction(float x)
    {
        return 2 * x * x - 3 * x - 8;
    }

    private void CalculateYCoordinates()
    {
        foreach (var coordinate in Coords)
        {
            coordinate.Y = ParabolaFunction(coordinate.X);
        }
    }
    
    public void DrawFunction()
    {
        GL.Color3(1.0f, 0.0f, 0.0f);
        GL.LineWidth(3.0f);
        GL.Begin(PrimitiveType.LineStrip);
        foreach (var coordinate in Coords)
        {
            GL.Vertex2(coordinate.X, coordinate.Y);
        }
        GL.End();
    }

    private void DrawDivisions()
    {
        var axeXLength = _windowMaxX - _windowMinX;
        var divisionXStep = axeXLength / 20;
        
        var axeYLength = _windowMaxY - _windowMinY;
        var divisionYStep = axeYLength / 20;
        
        var divisionWidth = 0.1f;
        
        GL.Begin(PrimitiveType.Lines);

        for (float coordinateX = _windowMinX; coordinateX <= _windowMaxX; coordinateX += divisionXStep)
        {
            GL.Vertex2(coordinateX, divisionWidth);
            GL.Vertex2(coordinateX, -divisionWidth);
        }
        
        for (float coordinateY = _windowMinY; coordinateY <= _windowMaxY; coordinateY += divisionYStep)
        {
            GL.Vertex2(-divisionWidth, coordinateY);
            GL.Vertex2(divisionWidth, coordinateY);
        }
        
        GL.End();
    }

    public void DrawCoordinateAxes()
    {
        const float arrowLength = 0.25f;
        
        GL.Color3(0.0, 0.0, 0.0);
        GL.LineWidth(2.0f);
        GL.Begin(PrimitiveType.Lines);
        
        GL.Vertex2(_windowMinX,0.0);
        GL.Vertex2(_windowMaxX,0.0);
        GL.Vertex2(_windowMaxX,0.0);
        GL.Vertex2(_windowMaxX - arrowLength,arrowLength);
        GL.Vertex2(_windowMaxX,0.0);
        GL.Vertex2(_windowMaxX - arrowLength,-arrowLength);
        
        GL.Vertex2(0.0,_windowMinY);
        GL.Vertex2(0.0,_windowMaxY);
        GL.Vertex2(0.0,_windowMaxY);
        GL.Vertex2(arrowLength,_windowMaxY - arrowLength);
        GL.Vertex2(0.0,_windowMaxY);
        GL.Vertex2(-arrowLength,_windowMaxY - arrowLength);
        
        GL.End();

        DrawDivisions();
    }
}