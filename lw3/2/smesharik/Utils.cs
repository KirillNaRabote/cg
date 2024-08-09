using OpenTK.Graphics.OpenGL;

namespace smesharik;

public static class Utils
{
    public static void DrawEllipse(float xCenter, float yCenter, float rx, float ry, int points = 360)
    {
        GL.PushMatrix();
        
        float step = (float)(2 * Math.PI) / points;

        GL.Begin(PrimitiveType.TriangleFan);
        
        GL.Vertex2(xCenter, yCenter);

        for (float angle = 0; angle <= 2.1 * Math.PI; angle += step)
        {
            float a = Math.Abs((float)(angle - 2 * Math.PI)) < 1e-5 ? 0 : angle;
            
            float dx = rx * float.Cos(a);
            float dy = ry * float.Sin(a);
            
            GL.Vertex2(xCenter + dx, yCenter + dy);
        }
        
        GL.End();
        
        GL.PopMatrix();
    }
    
    public static void DrawEllipseHalf(float xCenter, float yCenter, float rx, float ry, float rotation = 0.0f, int points = 360)
    {
        GL.PushMatrix();

        GL.Rotate(rotation, 0.0f, 0.0f, 1.0f);

        float step = (float)(2 * Math.PI) / points;

        GL.Begin(PrimitiveType.TriangleFan);

        GL.Vertex2(xCenter, yCenter);

        for (float angle = 0; angle <= 2.1 * Math.PI; angle += step)
        {
            if (Math.Sin(angle) > 0)
            {
                float a = Math.Abs((float)(angle - 2 * Math.PI)) < 1e-5 ? 0 : angle;

                float dx = rx * float.Cos(a);
                float dy = ry * float.Sin(a);

                GL.Vertex2(xCenter + dx, yCenter + dy);
            }
        }

        GL.End();

        GL.PopMatrix();
    }
    
    public static void DrawRectangle(float x, float y, float width, float height, float rotation = 0.0f)
    {
        GL.PushMatrix();

        GL.Translate(x + width / 2.0f, y + height / 2.0f, 0.0f);

        GL.Rotate(rotation, 0.0f, 0.0f, 1.0f);

        GL.Begin(PrimitiveType.Quads);
        GL.Vertex2(-width / 2.0f, -height / 2.0f);
        GL.Vertex2( width / 2.0f, -height / 2.0f);
        GL.Vertex2( width / 2.0f,  height / 2.0f);
        GL.Vertex2(-width / 2.0f,  height / 2.0f);
        GL.End();

        GL.PopMatrix();
    }
}