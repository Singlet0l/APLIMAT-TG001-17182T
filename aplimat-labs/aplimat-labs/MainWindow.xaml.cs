﻿using aplimat_labs.Models;
using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplimat_labs
{
    public partial class MainWindow : Window
    {

        private const float LINE_SMOOTHNESS = 0.02f;
        private const float GRAPH_LIMIT = 15;
        private const int TOTAL_CIRCLE_ANGLE = 360;

        #region OldCode/PreviousActivities
        //private Vector3 a = new Vector3(15,15,0);
        //private Vector3 b = new Vector3(-2,10,0);

        /*private const int HEADS = 0;
        private const int TAILS = 1;

        private Randomizer rng = new Randomizer(-20, 20);*/

        //private List<CubeMesh> myCubes = new List<CubeMesh>();
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            #region OldCode/PreviousActivities
            //Console.WriteLine(myVector.GetMagnitude());

            /*Vector3 c = a + b;
            Console.WriteLine("Values: x: " + c.x + " y: " + c.y + " z: " + c.z);

            Vector3 d = a - b;
            Console.WriteLine("Values: x: " + d.x + " y: " + d.y + " z: " + d.z);*/
            #endregion
        }

        private CubeMesh LightCube = new CubeMesh()
        {
            Position = new Vector3(-25, 0, 0)
        };

        private CubeMesh MediumCube = new CubeMesh()
        {
            Position = new Vector3(-25, 0, 0),
            Mass = 3
        };

        private CubeMesh HeavyCube = new CubeMesh()
        {
            Position = new Vector3(-25, 0, 0),
            Mass = 5
        };

        private Vector3 Wind = new Vector3(0.01f, 0, 0);
        private Vector3 Gravity = new Vector3(0, -0.01f, 0);
        private Vector3 VerticalBounce = new Vector3(0, 0.3f, 0);
        private Vector3 HorizontalBounce = new Vector3(-0.15f, 0, 0);

        #region OldCode/PreviousActivities
        //private CubeMesh myCube = new CubeMesh(2, 1, 0);

        /*private CubeMesh myCube = new CubeMesh();
        private Vector3 velocity = new Vector3(1, 1, 0);
        private float speed = 2.0f;
        private Vector3 myVector = new Vector3();
        private Vector3 a = new Vector3();
        private Vector3 b = new Vector3(5, 10, 0);*/
#endregion
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            this.Title = "Bouncing Cubes";

            //Clear the Screen and the Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //Move left and into the scren.
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -40.0f);

            //LightCube Physics
            gl.Color(1.0f, 0.0f, 0.0f);
            LightCube.Draw(gl);
            LightCube.ApplyForce(Wind);
            LightCube.ApplyForce(Gravity);

            if (LightCube.Position.x >= 25.0f)
                LightCube.Velocity.x *= -1;
               
            if (LightCube.Position.y <= -10.0f)
                LightCube.Velocity.y *= -1;

            //MediumCube Physics
            gl.Color(0.0f, 1.0f, 0.0f);
            MediumCube.Draw(gl);
            MediumCube.ApplyForce(Wind);
            MediumCube.ApplyForce(Gravity);

            if (MediumCube.Position.x >= 25.0f)
                MediumCube.Velocity.x *= -1;

            if (MediumCube.Position.y <= -10.0f)
                MediumCube.Velocity.y *= -1;

            //HeavyCube Physics
            gl.Color(0.0f, 0.0f, 1.0f);
            HeavyCube.Draw(gl);
            HeavyCube.ApplyForce(Wind);
            HeavyCube.ApplyForce(Gravity);

            if (HeavyCube.Position.x >= 25.0f)
                HeavyCube.Velocity.x *= -1;

            if (HeavyCube.Position.y <= -10.0f)
                HeavyCube.Velocity.y *= -1;

            #region OldCode/PreviousActivities



            //myVector = a - b;
            //myCube.Draw(gl);
            //myCube.Position += velocity / speed;

            /*gl.Color(1.0f, 0.0f, 0.0f);
            gl.LineWidth(20);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 0);
            gl.Vertex(b.x, b.y);
            gl.End();

            gl.Color(1.0f, 1.0f, 1.0f);
            gl.LineWidth(3);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 0);
            gl.Vertex(b.x, b.y);
            gl.End();

            gl.DrawText(0, 0, 1, 1, 1, "Arial", 15, "Light saber magnitude is" + myVector.GetMagnitude());*/

            /*//Right side bounce
            if (myCube.Position.x >= 30.0f)
            {
                velocity.x = -1;
            }

            //Left side bounce
            if (myCube.Position.x <= -30.0f)
            {
                velocity.x = 1;
            }

            //Top bounce
            if (myCube.Position.y >= 20.0f)
            {
                velocity.y = -1;
            }

            //Bottom bounce
            if (myCube.Position.y <= -20.0f)
            {
                velocity.y = 1;
            }*/

            /*CubeMesh myCube = new CubeMesh();
            myCube.Position = new Vector3(Gaussian.Generate(0, 15), rng.GenerateInt() , 0);
            myCubes.Add(myCube);

            foreach (var cube in myCubes)
            {
                cube.ColorChange();
                cube.Draw(gl);
            }*/

            /*myCube.Draw(gl);

            switch (rng.GenerateInt())
            {
                case 0:
                    myCube.Position += new Vector3(0.1f, 0, 0);
                    break;

                case 1:
                    myCube.Position += new Vector3(-0.1f, 0, 0);
                    break;

                case 2:
                    myCube.Position += new Vector3(-0.1f, 0.1f, 0);
                    break;

                case 3:
                    myCube.Position += new Vector3(0.1f, -0.1f, 0);
                    break;

                case 4:
                    myCube.Position += new Vector3(-0.1f, -0.1f, 0);
                    break;

                case 5:
                    myCube.Position += new Vector3(0.1f, -0.1f, 0);
                    break;

                case 6:
                    myCube.Position += new Vector3(0, 0.1f, 0);
                    break;

                case 7:
                    myCube.Position += new Vector3(0, -0.1f, 0);
                    break;
            }*/



            //gl.Color(0, 1, 0);
            //DrawCartesianPlane(gl); //draw cartesian plane with unit lines
            //DrawPoint(gl, 1, 1); //draw a point with coordinates (1, 1)
            //DrawLinearFunction(gl);
            //DrawQuadraticFunction(gl);
            //DrawCircle(gl);
            #endregion
        }


        private void DrawCartesianPlane(OpenGL gl)
        {

            //draw y-axis
            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Color(1.0f, 0.0f, 1.0f);
            gl.Vertex(0, -GRAPH_LIMIT, 0);
            gl.Vertex(0, GRAPH_LIMIT, 0);
            gl.End();

            //draw x-axis
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(-GRAPH_LIMIT, 0, 0);
            gl.Vertex(GRAPH_LIMIT, 0, 0);
            gl.End();

            //draw unit lines
            for (int i = -15; i <= 15; i++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(-0.2f, i, 0);
                gl.Vertex(0.2f, i, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(i, -0.2f, 0);
                gl.Vertex(i, 0.2f, 0);
                gl.End();
            }
        }

        private void DrawPoint(OpenGL gl, float x, float y)
        {
            gl.PointSize(5.0f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
        }

        private void DrawLinearFunction(OpenGL gl)
        {
            /*
             * f(x) = x + 2;
             * Let x be 4, then y = 6 (4, 6)
             * Let x be -5, then y = -3 (-5, -3)
             * */
            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x+=LINE_SMOOTHNESS)
            {
                gl.Vertex(x, x + 2);
            }
            gl.End();

            DrawText(gl, "f(x) = x + 2", 500, 400);

        }


        private void DrawQuadraticFunction(OpenGL gl)
        {
            /*
             * f(x) = x^2 + 2x - 5;
             * Let x be 2, then y = 3
             * Let x be -1, then y = -6
             */

            //gl.PointSize(1.0f);
            //gl.Begin(OpenGL.GL_POINTS);
            //for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            //{
            //    gl.Vertex(x, Math.Pow(x, 2) + (2 * x) - 5);
            //}
            //gl.End();

            /*
             * f(x) = x^2
             * 
             */
            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            {
                gl.Vertex(x, Math.Pow(x, 2));
            }
            gl.End();

            DrawText(gl, "f(x) = x ^ 2", 360, 380);

        }

        private void DrawCircle(OpenGL gl)
        {
            float radius = 3.0f;

            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = 0; i <= TOTAL_CIRCLE_ANGLE; i++)
            {
                gl.Vertex(Math.Cos(i) * radius, Math.Sin(i) * radius);
            }
            gl.End();

            DrawText(gl, "(cos(x), sin(x))", 350, 200);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            #region KeyboardCode
            /*switch (e.Key)
            {
                case Key.W:
                    b.y++;
                    break;

                case Key.S:
                    b.y--;
                    break;

                case Key.A:
                    b.x--;
                    break;

                case Key.D:
                    b.x++;
                    break;
            }*/
#endregion
        } 
        #region opengl init
        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);

        }
        #endregion

        #region draw text
        private void DrawText(OpenGL gl, string text, int x, int y)
        {
            gl.DrawText(x, y, 1, 1, 1, "Arial", 12, text);
        }
        #endregion

        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(this);
        }
    }
}
