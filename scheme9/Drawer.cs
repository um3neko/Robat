using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Assets;


namespace scheme9
{
    internal class Drawer
    {

        static Bitmap textureImage; 
        static Texture texture = new Texture();
        public static string fileDirectory;


        static  OpenGL Gl;

        public Drawer(OpenGL gl, string _fileDirectory)
        {
            Gl = gl;
            Gl.Enable(OpenGL.GL_TEXTURE_2D);
            fileDirectory = _fileDirectory;
        }

        public static void Texture()
        {
            textureImage = new Bitmap(fileDirectory.ToString());

            texture.Create(Gl, textureImage);

            texture.Bind(Gl);
        }

        public void Circle(double r, double x = 0, double y = 0, double z = 0)
        {
            Gl.Translate(x, y, z);

            Gl.Begin(OpenGL.GL_TRIANGLE_FAN);
            Gl.Vertex(0.0f, 0.0f);
            for (int i = 0; i <= 50; i++)
            {
                double a = i / 50.0f * 3.1415f * 2.0f;
                Gl.Vertex(Math.Cos(a) * r, Math.Sin(a) * r);
            }
            Gl.End();

            Gl.Translate(-x, -y, -z);
        }
        
        public void Parallelepiped(double x, double y, double z, double width, double height, double length)
        {
            double a = width / 2;
            double h = height / 2;
            double b = length / 2;

            Gl.Begin(OpenGL.GL_QUADS);
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z - b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z - b); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z + b); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x + a, y + h, z - b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z + b); Gl.TexCoord(0, 1);

            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z - b); Gl.TexCoord(1, 1);
            Gl.Vertex(x - a, y + h, z + b); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y + h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y + h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z + b); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 1);
            Gl.End();
        }

        public void DifferentSizeParallelepiped(double x, double y, double z, double width, double height, double length)
        {
            Gl.PushMatrix();
            Gl.Translate(0.0f, height, 0.0f);
            double a = width / 2;
            double h = height;
            double b = length / 2;
            
            Gl.Begin(OpenGL.GL_QUADS);
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z - b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z - b); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z + b); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x + a, y + h, z - b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z + b); Gl.TexCoord(0, 1);

            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z - b); Gl.TexCoord(1, 1);
            Gl.Vertex(x - a, y + h, z + b); Gl.TexCoord(0, 1);
            //upside
            Gl.Vertex(x + a, y + h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y + h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y + h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y + h, z + b); Gl.TexCoord(0, 1);
            //downside
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 1);

            Gl.End();
            Gl.PopMatrix();
        }
        public void Polygon(double x, double y, double z, double width, double length, double upWidth, double upLength,double height)
        {
            Gl.PushMatrix();
           
            double h = height / 2;

            double a = width / 2;
            double b = length / 2;

            double cWidth = upWidth / 2;
            double lLength = upLength / 2;

            Gl.Begin(OpenGL.GL_QUADS);
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - cWidth, y + h, z - lLength); Gl.TexCoord(1, 1);
            Gl.Vertex(x + cWidth, y + h, z - lLength); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - cWidth, y + h, z + lLength); Gl.TexCoord(1, 1);
            Gl.Vertex(x + cWidth, y + h, z + lLength); Gl.TexCoord(0, 1);

            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x + cWidth, y + h, z - lLength); Gl.TexCoord(1, 1);
            Gl.Vertex(x + cWidth, y + h, z + lLength); Gl.TexCoord(0, 1);

            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - cWidth, y + h, z - lLength); Gl.TexCoord(1, 1);
            Gl.Vertex(x - cWidth, y + h, z + lLength); Gl.TexCoord(0, 1);
            //upside
            Gl.Vertex(x + cWidth, y + h, z - lLength); Gl.TexCoord(0, 0);
            Gl.Vertex(x - cWidth, y + h, z - lLength); Gl.TexCoord(1, 0);
            Gl.Vertex(x - cWidth, y + h, z + lLength); Gl.TexCoord(1, 1);
            Gl.Vertex(x + cWidth, y + h, z + lLength); Gl.TexCoord(0, 1);
            //downside
            Gl.Vertex(x + a, y - h, z - b); Gl.TexCoord(0, 0);
            Gl.Vertex(x - a, y - h, z - b); Gl.TexCoord(1, 0);
            Gl.Vertex(x - a, y - h, z + b); Gl.TexCoord(1, 1);
            Gl.Vertex(x + a, y - h, z + b); Gl.TexCoord(0, 1);

            Gl.End();
            Gl.PopMatrix();
        }




    }
}
