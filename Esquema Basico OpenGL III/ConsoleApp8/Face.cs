using System;
using Newtonsoft.Json;
using OpenTK;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Runtime.Serialization;

namespace ConsoleApp8
{
    [DataContract]
    public class Face
    {
        [DataMember]
        private Dictionary<string, Vect3> vertices;
        [DataMember]
        private Vect3 centro;
        [DataMember]
        private Vect3 color;
        public Face()
        {
            vertices = new Dictionary<string, Vect3>();
        }

        public Face(Dictionary<string, Vect3> vertices)
        {
            this.vertices = vertices;
        }

        public void addVertice(string key, Vect3 vertice)
        {
            this.vertices.Add(key, vertice);
        }

        public void addVertices(Dictionary<string, Vect3> vertices)
        {
            this.vertices = vertices;
        }

        public void addColor(Vect3 color)
        {
            this.color = color;
        }

        public void addColor(Color color)
        {
            this.color = new Vect3(color.R, color.G, color.B);
        }

        public void addColor(double r, double a, double b)
        {
            this.color = new Vect3(r, a, b);
        }

        public void setCentro(Vect3 centro)
        {
            this.centro = centro;
        }

        public void dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(this.color.X, this.color.Y, this.color.Z);
            foreach (var vector in vertices.Values)
            {
                GL.Vertex3(this.centro.X + vector.X, this.centro.Y + vector.Y, this.centro.Z + vector.Z);
            }
            GL.End();
        }



        public void rotar(int s)
        {
            GL.Translate(this.centro.X, this.centro.Y, this.centro.Z);
            GL.Rotate(s, 0.0f, 1.0f, 0.0f);
            GL.Translate(-this.centro.X, -this.centro.Y, -this.centro.Z);
        } 


    }
}
