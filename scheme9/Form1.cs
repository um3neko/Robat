
using System.Drawing;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using SharpGL;
using System.Windows.Forms;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Cameras;

namespace scheme9
{
    public partial class Form1 : Form
    {

        Drawer Create;
        OpenGL openGL;
        private string fileDirectory;
        private OpenFileDialog openFileDialog1;

        public Form1()
        {
            InitializeComponent();
            openGL = new OpenGL();
            Create = new Drawer(openGL,fileDirectory);
            openFileDialog1 = new OpenFileDialog();
            
        }
        
        private float Camera1 = 20;
        private float Camera2 = 0;
        private float MouseWheelCamera = -13.0f;

        private float _CurrentX = 0.2f;
        public float CurrentX
        {
            get { return _CurrentX; }
            set
            {
                if (value > -0.6f && value < 0.4f)
                {
                    _CurrentX = value;
                }
            }
        }


        private float _CurrentY;
        public float CurrentY
        {
            get { return _CurrentY;  }
            set
            {
                if (value > -2.0f && value < 2.0f)
                {
                    _CurrentY = value;
                }
            }

        }


        private float _angle = 30;
        public float Angle
        {
            get { return _angle; }
            set
            {
                if (value >= 30 && value <= 60)
                {
                    _angle = value;
                }

            }
        }

        private float RotatorKabiny;

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            MGH(); // gravity
            
            openGL.ClearColor(0.1f,0.1f,0.1f,0.1f);
            MouseWheelCamera = vScrollBar1.Value;
            Camera2 = hScrollBar1.Value;
            Camera1 = vScrollBar2.Value;
            openGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
            openGL.Clear(OpenGL.GL_DEPTH_BUFFER_BIT);
            openGL.LoadIdentity();
            openGL.Translate(0.0f, Camera1, MouseWheelCamera);
            
           
            openGL.Rotate(Camera2, 0.0f, 1.0f, 0.0f);

            openGL.Color(1.0f, 1.0f, 1.0f);
            Create.Parallelepiped(0.0f, -7.0f, 0.0f, 20.0f, 0.0f, 20.0f);
            //stolb
            openGL.PushMatrix();
           
            Create.Polygon(0.0f, -3.0f, 0.0f, 2.5f, 2.5f, 1.0f, 1.0f, 11.0f);
            openGL.PopMatrix();
            openGL.Color(0.0, 0.0f, 0.0f);
            openGL.PushMatrix();
            Create.Parallelepiped(0.0f, 2.3f, 0.0f, 1.2f, 0.5f, 1.2f);
            openGL.Color(1.0, 1.0f, 1.0f);
            Create.Polygon(0.0f, 3.0f, 0.0f, 1.0f, 1.0f, 2.0f, 2.0f, 0.7f);
            //kabina

            openGL.PushMatrix();
            openGL.Rotate(RotatorKabiny, 0.0f,1.0f,0.0f);

            openGL.Translate(0.0f, 4.0f, 0.0);
            Create.Polygon(0.0f, 0.0f, 0.0f, 1.0f, 2.0f, 2.0f, 2.0f, 1.5f);
            openGL.Translate(0.0f, 1.5f, 0.0);
            Create.Polygon(0.0f, 0.0f, 0.0f, 2.0f, 2.0f, 1.0f, 2.0f, 1.5f);

            //door
            openGL.Color(0.0f, 0.0f, 0.0f);
            Create.Parallelepiped(0.0f, -0.5f, 1.0f, 1.1f, 1.8f, 0.5f);
            //Hand
            openGL.Color(0.7f, 0.6f, 0.5f);
            openGL.Translate(-1.0f, -1.0f, 0.0f);
            openGL.PushMatrix();
            openGL.Rotate(Angle, 0.0f, 0.0f, 1.0f);
            openGL.Translate(1.0f, 3.0f, 0.0f);
            
            Create.DifferentSizeParallelepiped(0.0f, -3.0f, 0.0f, 0.6f, 3.0f, 0.6f);
            Create.DifferentSizeParallelepiped(0.0f, 3.0f, 0.0f, 0.4f, Height1, 0.4f);
            Create.DifferentSizeParallelepiped(0.0f, 3.0f, 0.0f, 0.2f, Height2, 0.2f);

            openGL.Translate(0.0f,Height2 + Height2,0.0f);
            openGL.Color(0.1f, 0.1f, 0.1f);
            Create.Parallelepiped(0.0f, 2.6f, 0.0f, 0.8f, 1.0, 0.8f);
            openGL.Color(0.7f, 0.6f, 0.5f);
            // HAND 2
            openGL.PushMatrix();
            openGL.Rotate(Angle + 60, 0.0f, 0.0f,1.0f);
            openGL.Translate(2.5f,-1.0f,0.0f);
            Create.DifferentSizeParallelepiped(0.0f, 0.0f, 0.0f, 0.4f, 3.0f, 0.4f);
            Create.DifferentSizeParallelepiped(0.0f, 4.5f, 0.0f, 0.2f, Height3, 0.2f);
            //ROPE
            openGL.Color(1.0f,1.0f,1.0f);
            openGL.Translate(0.0f,4.5f + Height3 + Height3,0.0f);
            openGL.Rotate(AngleForDefault - 30, 0.0f,0.0f,1.0f);
            Create.Parallelepiped(0.0f,1.0f,0.0f,0.1f,2.1f,0.1f);
            

            //Pyramid

            openGL.Color(1.0f,0.0f,1.0f);
            Create.Polygon(0.0f,2.0f,0.0f,0.0f,0.0f,2.0f,2.0f,2.0f);

            openGL.PopMatrix();

            openGL.PopMatrix();


            openGL.PopMatrix();
            openGL.PopMatrix();
        }

        private float height1 = 0.0f;
        public float Height1
        {
            get { return height1; }
            set
            {
                if (value >= 0.0f && value <= 3.0f)
                {
                    height1 = value;
                }

            }
        }

        private float height2 = 0.0f;
        public float Height2
        {
            get { return height2; }
            set
            {
                if (value >= 0.0f && value <= 6.0f)
                {
                    height2 = value;
                }

            }
        }

        private float height3 = 0.7f;
        public float Height3
        {
            get { return height3; }
            set
            {
                if (value >= 0.7f && value <= 3.0f)
                {
                    height3 = value;
                }

            }
        }


        private float AngleForDefault;

        private float i;

        public float I
        {
            get { return i; }
            
            set
            {
                if (value >= 0 && value <= 30)
                {
                    i = value;
                }
            }
        }


        private void MGH()
        {
            AngleForDefault = Angle + 60 - i * 3;
        }
        
        
        





        private async void openGLControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            switch (e.KeyChar)
            {

                case '1':
                    await Task.Run(() =>
                    {
                        
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            Angle += 0.1f;
                            I += 0.1f;
                        }

                    });
                    break;
                case '2':
                    await Task.Run(() =>
                    {
                        
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            Angle -= 0.1f;
                            I -= 0.1f;
                        }

                    });
                    break;

                case 'd':
                    await Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            RotatorKabiny -= 1;
                        }
                        
                    });
                    break;
                case 'a':
                    await Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            RotatorKabiny += 1;
                        }

                    });
                    break;

                case 'w':
                    await Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            
                            Thread.Sleep(10);
                            Height1 += 0.02f;
                            Height2 += 0.02f;

                        }

                    });
                    break;
                case 'q':
                    await Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            Height1 -= 0.02f;
                            Height2 -= 0.02f;
                        }


                    });
                    break;
                case 'r':
                    await Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            Height3 += 0.01f;
                            
                        }

                    });
                    break;
                case 'e':
                    await Task.Run(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(10);
                            Height3 -= 0.01f;
                        }
                        
                    });
                    break;


            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Filter = "picture files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (myFile.ShowDialog() == DialogResult.OK)
            {
                fileDirectory = myFile.FileName;

            }
            Drawer.fileDirectory = fileDirectory;
            Drawer.Texture();
        }

        

       
    }
}
