using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {


            guardarJsonCubo();
            guardarJsonPiramide();

            Game window = new Game(960, 720);
            window.Run();



        }






        public static void guardarJsonCubo()
        {
            Dictionary<string, Face> faces = new Dictionary<string, Face>();

            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            lista1.Add("v1", new Vect3(-1.0f, 1.0f, 1.0f));
            lista1.Add("v2", new Vect3(-1.0f, 1.0f, -1.0f));
            lista1.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            Face face = new Face(lista1);
            face.addColor(1.0, 1.0, 0.0);
            faces.Add("f1", face);

            Dictionary<string, Vect3> lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista2.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista2.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista2.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Face(lista2);
            face.addColor(1.0f, 0.0f, 1.0f);
            faces.Add("f2", face);

            Dictionary<string, Vect3> lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista3.Add("v4", new Vect3(-1.0f, -1.0f, 1.0f));
            face = new Face(lista3);
            face.addColor(0.0f, 1.0f, 1.0f);
            faces.Add("f3", face);

            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, 1.0f, -1.0f));
            lista4.Add("v3", new Vect3(-1.0f, 1.0f, -1.0f));
            lista4.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Face(lista4);
            face.addColor(1.0f, 0.0f, 0.0f);
            faces.Add("f4", face);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(1.0f, 1.0f, -1.0f));
            lista5.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(-1.0f, 1.0f, -1.0f));

            face = new Face(lista5);
            face.addColor(0.0f, 1.0f, 0.0f);
            faces.Add("f5", face);

            Dictionary<string, Vect3> lista6 = new Dictionary<string, Vect3>();
            lista6.Add("v1", new Vect3(1.0f, 1.0f, 1.0f));
            lista6.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista6.Add("v3", new Vect3(-1.0f, -1.0f, 1.0f));
            lista6.Add("v4", new Vect3(-1.0f, 1.0f, 1.0f));
            face = new Face(lista6);
            face.addColor(0.0f, 0.0f, 1.0f);
            faces.Add("f6", face);

            string nombre = "Cubo";
            Vect3 centro = new Vect3(-2.0, 0.0, 0.0);
            Objeto obj = new Objeto(nombre, centro, faces);

            string nombreArchivo = "Cubo.json";

            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            File.WriteAllText(nombreArchivo, jsonString);
            Console.WriteLine(File.ReadAllText(nombreArchivo));

        }

        public static void guardarJsonPiramide()
        {
            Dictionary<string, Face> faces = new Dictionary<string, Face>();

            Dictionary<string, Vect3> lista1 = new Dictionary<string, Vect3>();
            lista1.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista1.Add("v2", new Vect3(1.0f, -1.0f, -1.0f));
            lista1.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            Face face = new Face(lista1);
            face.addColor(Color.Green);
            faces.Add("f1", face);

            Dictionary<string, Vect3> lista2 = new Dictionary<string, Vect3>();
            lista2.Add("v1", new Vect3(-1.0f, -1.0f, -1.0f));
            lista2.Add("v2", new Vect3(-1.0f, -1.0f, 1.0f));
            lista2.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Face(lista2);
            face.addColor(Color.Yellow);
            faces.Add("f2", face);

            Dictionary<string, Vect3> lista3 = new Dictionary<string, Vect3>();
            lista3.Add("v1", new Vect3(1.0f, -1.0f, -1.0f));
            lista3.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista3.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Face(lista3);
            face.addColor(Color.HotPink);
            faces.Add("f3", face);

            Dictionary<string, Vect3> lista4 = new Dictionary<string, Vect3>();
            lista4.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista4.Add("v2", new Vect3(1.0f, -1.0f, 1.0f));
            lista4.Add("v3", new Vect3(0.0f, 1.0f, 0.0f));
            face = new Face(lista4);
            face.addColor(Color.Blue);
            faces.Add("f4", face);

            Dictionary<string, Vect3> lista5 = new Dictionary<string, Vect3>();
            lista5.Add("v1", new Vect3(-1.0f, -1.0f, 1.0f));
            lista5.Add("v2", new Vect3(-1.0f, -1.0f, -1.0f));
            lista5.Add("v3", new Vect3(1.0f, -1.0f, -1.0f));
            lista5.Add("v4", new Vect3(1.0f, -1.0f, 1.0f));
            face = new Face(lista5);
            face.addColor(Color.Aquamarine);
            faces.Add("f5", face);

            string nombre = "Piramide";
            Vect3 centro = new Vect3(2.0, 0.0, 0.0);
            Objeto obj = new Objeto(nombre, centro, faces);

            string nombreArchivo = "Piramide.json";

            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented,
                    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            File.WriteAllText(nombreArchivo, jsonString);
            Console.WriteLine(File.ReadAllText(nombreArchivo));


        }

    }
}
