using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ConsoleApp8
{
    class Game : GameWindow
    {

        float speed = 0.2f;
        int cubo = 0;
        int piramide = 0;
        Vector3 position = new Vector3(0.0f, 0.0f, 10.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);


        List<Escenario> escenarios;
        Escenario escenario;

        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "") 
        {
            VSync = VSyncMode.On;

            escenarios = new List<Escenario>();

            escenario = new Escenario();
        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.1f, 0.2f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            escenario.addObjeto("Cubo.json");
            escenario.addObjeto("Piramide.json");


            escenarios.Add(escenario);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            Matrix4 modelview = Matrix4.LookAt(position, position + front, up);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);


            for (int i = 0; i < escenario.getCountObjetos(); i++)
            {
                GL.PushMatrix();
                escenario.getObjeto(i).rotar(cubo);

                escenario.getObjeto(i).dibujar();

                GL.PopMatrix();
            }


            SwapBuffers();
            base.OnRenderFrame(e);
        }



        protected override void OnResize(EventArgs e)
        {
            
            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Z))
            {
                cubo++;
            }

            if (input.IsKeyDown(Key.X))
            {
                piramide++;
            }

            if (input.IsKeyDown(Key.W))
            {
                position += front * speed;
            }

            if (input.IsKeyDown(Key.S))
            {
                position -= front * speed;
            }

            if (input.IsKeyDown(Key.A))
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.D))
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.Space))
            {
                position += up * speed;
            }

            if (input.IsKeyDown(Key.LShift))
            {
                position -= up * speed;
            }

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (!Focused)
            {
                return;
            }

        }







        //GL.PushMatrix();
        //GL.Translate(5.0f, 0.0f, 0.0f);
        //GL.Scale(1.5f, 1.5f, 1.5f);


        //foreach(Objeto obj in escenario.objetos.Values)
        //{
        //    GL.PushMatrix();
        //    obj.rotar(s);
        //    obj.dibujar();
        //    GL.PopMatrix();
        //}


        //GL.PushMatrix();
        //escenario.getObjeto(i).rotar(s);

        //escenario.getObjeto(i).dibujar();

        //GL.PopMatrix();



        //foreach (Objeto obj in escenario.getObjetos().Values)
        //    {
        //        if(obj.getNombre() == "Cubo")
        //        {
        //            GL.PushMatrix();
        //            obj.rotar(cubo);
        //            obj.dibujar();
        //            GL.PopMatrix();
        //        } else
        //        {
        //            GL.PushMatrix();
        //            obj.rotar(piramide);
        //            obj.dibujar();
        //            GL.PopMatrix();
        //        }
        //    }

    }
}
