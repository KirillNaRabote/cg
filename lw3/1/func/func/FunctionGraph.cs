using OpenTK.Graphics.OpenGL;

namespace func;

public class FunctionGraph
{
    private List<Coordinates> Coords { get; set; } = [];

    public FunctionGraph(float step, float xMin, float xMax)
    {
        FillXCoordinates(step, xMin, xMax);
        CalculateYCoordinates();
    }

    private void FillXCoordinates(float step, float xMin, float xMax)
    {
        for (var x = xMin; x <= xMax; x += step)
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
            GL.Vertex2(coordinate.X / 10, coordinate.Y / 10);
        }
        GL.End();
    }

    private void DrawDivisions()
    {
        const float axeLength = 2.0f;
        const float divisionStep = axeLength / 20;
        const float divisionWidth = 0.02f;
        
        GL.Begin(PrimitiveType.Lines);

        for (float coordinate = -1.0f; coordinate <= 1.0f; coordinate += divisionStep)
        {
            GL.Vertex2(coordinate, divisionWidth);
            GL.Vertex2(coordinate, -divisionWidth);
            
            GL.Vertex2(-divisionWidth, coordinate);
            GL.Vertex2(divisionWidth, coordinate);
        }
        
        GL.End();
    }

    public void DrawCoordinateAxes()
    {
        GL.Color3(0.0f, 0.0f, 0.0f);
        GL.Begin(PrimitiveType.Lines);
        
        GL.Vertex2(-1.0f,0.0f);
        GL.Vertex2(1.0f,0.0f);
        GL.Vertex2(1.0f,0.0f);
        GL.Vertex2(0.95f,0.05f);
        GL.Vertex2(1.0f,0.0f);
        GL.Vertex2(0.95f,-0.05f);
        
        GL.Vertex2(0.0f,-1.0f);
        GL.Vertex2(0.0f,1.0f);
        GL.Vertex2(0.0f,1.0f);
        GL.Vertex2(0.05f,0.95f);
        GL.Vertex2(0.0f,1.0f);
        GL.Vertex2(-0.05f,0.95f);
        
        GL.End();

        DrawDivisions();
    }
}