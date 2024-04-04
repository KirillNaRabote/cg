using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Platform.Native.Windows;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace func;

public class MainWindow: GameWindow
{
    private float _Factor = 0.0f;
    private float _SinFactor = 0.0f;
    private float _FrameTime = 0.0f;
    private int _Fps = 0;
    
    public MainWindow(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws)
    {
        Console.WriteLine(GL.GetString(StringName.Version));
        Console.WriteLine(GL.GetString(StringName.Vendor));
        Console.WriteLine(GL.GetString(StringName.Renderer));
        Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

        VSync = VSyncMode.On;
    }

    //инициализация ресурсов
    protected override void OnLoad()
    {
        base.OnLoad();
        //цвет задается один раз, поэтому можно не перетаскивать его в рендер кадра, если не нужно
        //чтобы цвет постоянно менялся
        //GL.ClearColor(Color4.Bisque);
        //GL.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
    }

    //игровой цикл
    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        //Title = $"FPS: {args.Time}";
        _FrameTime += (float)args.Time;
        _Fps++;
        
        if (_FrameTime > 1.0f)
        {
            Title = $"FPS: {_Fps}";
            _FrameTime = 0.0f;
            _Fps = 0;
        }

        var key = KeyboardState;

        if (key.IsKeyDown(Keys.Escape)) Close();
        
        _Factor += 0.001f;
        _SinFactor = (float)Math.Sin((double)_Factor);
        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.ClearColor(_SinFactor, 0.0f, 0.0f, 1.0f);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        SwapBuffers();
        base.OnRenderFrame(args);
    }

    //удаление ресурсов
    protected override void OnUnload()
    {
        base.OnUnload();
    }
}