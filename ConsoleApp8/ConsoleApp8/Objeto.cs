using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    [DataContract]
    class Objeto
    {
        [DataMember]
        private string nombre;
        [DataMember]
        private Vect3 centro;
        [DataMember]
        private Dictionary<string, Face> faces;

        public Objeto()
        {
            faces = new Dictionary<string, Face>();
        }

        public Objeto(string nombre, Vect3 centro, Dictionary<string, Face> faces)
        {
            this.nombre = nombre;
            this.centro = centro;
            this.faces = faces;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public Dictionary<string, Face> getFaces()
        {
            return this.faces;
        }

        public Vect3 getCentro()
        {
            return this.centro;
        }


        public void dibujar()
        {
            foreach (var face in this.faces.Values)
            {
                face.dibujar();
            }
        }



        public void rotar(int s)
        {
            GL.Translate(this.centro.X, this.centro.Y, this.centro.Z);
            GL.Rotate(s, 0.0f, 1.0f, 0.0f);
            GL.Translate(-this.centro.X, -this.centro.Y, -this.centro.Z);
        }


    }
}
