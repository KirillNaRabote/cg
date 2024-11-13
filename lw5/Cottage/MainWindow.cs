﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Cottage;

public class MainWindow : GameWindow
{
    private bool _leftButtonPressed = false;
    private float _mouseX = 0;
    private float _mouseY = 0;

    private Cottage _cottage;

    public MainWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings)
    {
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        VSync = VSyncMode.On;
        
        GL.ClearColor(0.5f, 0.5f, 0.5f, 1f);

        GL.Enable(EnableCap.Texture2D);

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.AlphaTest);

        GL.Enable(EnableCap.Blend);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        GL.Enable(EnableCap.Lighting);

        GL.Light(LightName.Light1, LightParameter.Position, new Vector4(0f, 0f, 1f, 0f));
        GL.Light(LightName.Light1, LightParameter.Diffuse, new Vector4(1f, 1f, 1f, 1f));
        GL.Light(LightName.Light1, LightParameter.Ambient, new Vector4(0.2f, 0.2f, 0.2f, 1f));
        GL.Light(LightName.Light1, LightParameter.Specular, new Vector4(1f, 1f, 1f, 1f));
        GL.Light(LightName.Light0, LightParameter.Position, new Vector4(-1f, -1f, -1f, 0f));
        GL.Light(LightName.Light0, LightParameter.Diffuse, new Vector4(1f, 1f, 1f, 1f));
        GL.Light(LightName.Light0, LightParameter.Ambient, new Vector4(0.2f, 0.2f, 0.2f, 1f));
        GL.Light(LightName.Light0, LightParameter.Specular, new Vector4(1f, 1f, 1f, 1f));


        GL.Enable(EnableCap.ColorMaterial);

        GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, new Vector4(0.8f, 0.8f, 0f, 1f));
        GL.Material(MaterialFace.Front, MaterialParameter.Ambient, new Vector4(0.2f, 0.2f, 0.2f, 1));
        GL.Material(MaterialFace.Front, MaterialParameter.Specular, new Vector4(0.7f, 0.7f, 0.7f, 1));
        GL.Material(MaterialFace.Front, MaterialParameter.Shininess, 100);


        GL.LoadIdentity();
        var matrix = Matrix4.LookAt(
            0f, 0f, 70f,
            0f, 0f, 0f,
            0, 1, 0);
        GL.LoadMatrix(ref matrix);

        _cottage = new Cottage();

    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        if (e.Button == MouseButton.Left)
        {
            _leftButtonPressed = true;

            _mouseX = MousePosition.X;
            _mouseY = MousePosition.Y;
        }


        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        if (!_leftButtonPressed) return;
        float dx = e.X - _mouseX;
        float dy = e.Y - _mouseY;

        float rotateX = dy * 180 / 1000;
        float rotateY = dx * 180 / 1000;
        RotateCamera(rotateX, rotateY);

        _mouseX = e.X;
        _mouseY = e.Y;

        base.OnMouseMove(e);

        OnRenderFrame(new FrameEventArgs());
    }

    private void RotateCamera(float x, float y)
    {
        GL.MatrixMode(MatrixMode.Modelview);

        GL.GetFloat(GetPName.ModelviewMatrix, out Matrix4 modelView);

        Vector3 xAxis = new(modelView[0, 0], modelView[1, 0], modelView[2, 0]);
        Vector3 yAxis = new(modelView[0, 1], modelView[1, 1], modelView[2, 1]);

        GL.Rotate(x, xAxis);
        GL.Rotate(y, yAxis);
        NormalizeModelViewMatrix();
    }

    private void NormalizeModelViewMatrix()
    {
        GL.GetFloat(GetPName.ModelviewMatrix, out Matrix4 modelView);

        Vector3 xAxis = new(modelView[0, 0], modelView[1, 0], modelView[2, 0]);
        xAxis.Normalize();
        Vector3 yAxis = new(modelView[0, 1], modelView[1, 1], modelView[2, 1]);
        yAxis.Normalize();

        Vector3 zAxis = Vector3.Cross(xAxis, yAxis);
        zAxis.Normalize();
        xAxis = Vector3.Cross(yAxis, zAxis);
        xAxis.Normalize();
        yAxis = Vector3.Cross(zAxis, xAxis);
        yAxis.Normalize();

        modelView[0, 0] = xAxis.X; modelView[1, 0] = xAxis.Y; modelView[2, 0] = xAxis.Z;
        modelView[0, 1] = yAxis.X; modelView[1, 1] = yAxis.Y; modelView[2, 1] = yAxis.Z;
        modelView[0, 2] = zAxis.X; modelView[1, 2] = zAxis.Y; modelView[2, 2] = zAxis.Z;

        GL.LoadMatrix(ref modelView);
    }


    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
        _leftButtonPressed = false;
        base.OnMouseUp(e);
        OnRenderFrame(new FrameEventArgs());
    }

    protected override void OnMouseLeave()
    {
        _leftButtonPressed = false;
        base.OnMouseLeave();
        OnRenderFrame(new FrameEventArgs());
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        int width = e.Width;
        int height = e.Height;

        GL.Viewport(0, 0, width, height);

        SetupProjectionMatrix(width, height);

        GL.MatrixMode(MatrixMode.Modelview);
        base.OnResize(e);

        OnRenderFrame(new FrameEventArgs());
    }

    void SetupProjectionMatrix(int width, int height)
    {
        double frustumSize = 2;
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        double aspectRatio = ((double)width) / ((double)height);
        double frustumHeight = frustumSize;
        double frustumWidth = frustumHeight * aspectRatio;
        if (frustumWidth < frustumSize && (aspectRatio != 0))
        {
            frustumWidth = frustumSize;
            frustumHeight = frustumWidth / aspectRatio;
        }
        GL.Frustum(
            -frustumWidth * 0.5, frustumWidth * 0.5, // left, right
            -frustumHeight * 0.5, frustumHeight * 0.5, // top, bottom
            frustumSize * 0.5, frustumSize * 150 // znear, zfar
            );
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.MatrixMode(MatrixMode.Modelview);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.LineWidth(2);
        
        GL.PushMatrix();
        GL.Light(LightName.Light2, LightParameter.Position, new Vector4(20f, 10f, -20f, 0f));
        GL.Light(LightName.Light2, LightParameter.Diffuse, new Vector4(1f, 1f, 1f, 1f));
        GL.Light(LightName.Light2, LightParameter.Ambient, new Vector4(0.2f, 0.2f, 0.2f, 1f));
        GL.Light(LightName.Light2, LightParameter.Specular, new Vector4(1f, 1f, 1f, 1f));
        GL.Enable(EnableCap.Light2);
        GL.PopMatrix();
        _cottage.Draw();

        SwapBuffers();
        base.OnRenderFrame(args);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        this.OnRefresh();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        if (e.Key == Keys.Escape)
        {
            Close();
        }
        
        if(e.Key == Keys.F)
        {
            _cottage.ShowFog = !_cottage.ShowFog;
        }
        
        base.OnKeyDown(e);
    }
}