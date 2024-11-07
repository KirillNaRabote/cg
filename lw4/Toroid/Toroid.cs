using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Toroid;

public class Toroid
{
    private readonly float _R;
    private readonly float _r;
    private readonly float _step;

    public Toroid(float R = 2f, float r = 1f, int segments = 60)
    {
        _R = R;
        _r = r;
        _step = 2 * MathF.PI / segments;
    } 

    private void SetVertexByAngles(float a, float b)
    {
        Vector3 p = new(
            (_R + _r * MathF.Cos(a)) * MathF.Cos(b),
            (_R + _r * MathF.Cos(a)) * MathF.Sin(b),
            _r * MathF.Sin(a)
        );

        Vector3 center = new(_R * MathF.Cos(b), _R * MathF.Sin(b), 0);
        Vector3 normal = new(p - center);
        normal.Normalize();
        GL.Normal3(normal);
        GL.Color3(MathF.Cos(p[2]), MathF.Cos(p[2]), MathF.Cos(p[2]));
        GL.Vertex3(p);
    }
    
    public void DrawNormals()
    {
        GL.Begin(PrimitiveType.Lines);

        for (float b = 0; b < 2 * MathF.PI; b += _step)
        {
            for (float a = 0; a < 2 * MathF.PI; a += _step)
            {
                Vector3 p = new(
                    (_R + _r * MathF.Cos(a)) * MathF.Cos(b),
                    (_R + _r * MathF.Cos(a)) * MathF.Sin(b),
                    _r * MathF.Sin(a)
                );

                Vector3 center = new(_R * MathF.Cos(b), _R * MathF.Sin(b), 0);

                Vector3 normal = (p - center).Normalized();

                GL.Color3(0f, 0f, 1f);

                GL.Vertex3(p);
                GL.Vertex3(p + normal * 0.2f);
            }
        }

        GL.End();
    }

    public void Draw()
    {
        GL.Begin(PrimitiveType.QuadStrip);
        SetVertexByAngles(0, 0);
        SetVertexByAngles(0, _step);

        for (float b = 0; b < 2 * MathF.PI; b += _step)
        {
            for (float a = 0; a < 2 * MathF.PI; a += _step)
            {
                SetVertexByAngles(a + _step, b);
                SetVertexByAngles(a + _step, b + _step);
            }
        }

        GL.End();
        
        //DrawNormals();
    }
}