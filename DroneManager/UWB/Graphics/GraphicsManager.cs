using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DroneManager.UWB.Graphics
{
    public class GraphicsManager
    {
        private Dictionary<string, ShaderProgram> shaders;
        private string activeShader;

        public GraphicsManager()
        {
            this.shaders = new Dictionary<string, ShaderProgram>();
            this.activeShader = "default";
        }
    }
}
