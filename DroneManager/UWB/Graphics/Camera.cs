using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DroneManager.UWB.Graphics
{
    public class Camera
    {
        public Vector3 position;
        public Vector3 orientation;

        #region CONSTRUCTOR
        public Camera()
        {
            this.position = Vector3.zero;
            this.orientation = new Vector3((float)Math.PI, 0, 0);
        }

        public Camera(Vector3 pos, Vector3 rot)
        {
            this.position = pos;
            this.orientation = rot;
        }
        #endregion

        #region METHODS
        public Matrix4 GetViewMatrix()
        {
            Vector3 lookat = new Vector3();
            lookat.x = (float)(Math.Sin((float)orientation.x) * Math.Cos((float)orientation.y));
            lookat.y = (float)Math.Sin((float)orientation.y);
            lookat.z = (float)(Math.Cos((float)orientation.x) * Math.Cos((float)orientation.y));

            return Matrix4.LookAt((float)this.position.x, (float)this.position.y, (float)this.position.z,
                                    (float)(this.position.x + lookat.x),
                                    (float)(this.position.y + lookat.y),
                                    (float)(this.position.z + lookat.z),
                                    0f, 1f, 0f);
        }
        #endregion
    }
}
