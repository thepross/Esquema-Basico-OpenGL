using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp8
{
    class Escenario
    {

        public Dictionary<string, Objeto> objetos;

        public Escenario()
        {
            this.objetos = new Dictionary<string, Objeto>();
        }

        public void addObjeto(string key, Objeto objeto)
        {
            this.objetos.Add(key, objeto);
        }

        public void addObjeto(string nombreArchivo)
        {
            using (StreamReader file = File.OpenText(nombreArchivo))
            {
                JsonSerializer serializer = new JsonSerializer();
                Objeto obj = (Objeto)serializer.Deserialize(file, typeof(Objeto));
                this.objetos.Add(obj.getNombre(), obj);
                foreach (var face in obj.getFaces().Values)
                {
                    face.setCentro(obj.getCentro());
                }
            }
        }

        public Objeto getObjeto(int index)
        {
            return this.objetos.ElementAt(index).Value;
        }

        public Objeto getObjeto(string key)
        {
            if (!this.objetos.ContainsKey(key))
            {
                return null;
            }
            return this.objetos[key];
        }

        public Dictionary<string, Objeto> getObjetos()
        {
            return this.objetos;
        }

        public int getCountObjetos()
        {
            return this.objetos.Count;
        }

        public void dibujar()
        {
            foreach(Objeto objeto in this.objetos.Values)
            {
                objeto.dibujar();
            }
        }

    }
}
