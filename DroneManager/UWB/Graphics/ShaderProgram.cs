using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DroneManager.UWB.Graphics
{
    public class ShaderProgram
    {
        private int programID;
        private int vshaderID;
        private int fshaderID;
        private int attributeCount;
        private int uniformCount;

        private Dictionary<string, AttributeInfo> attributes;
        private Dictionary<string, UniformInfo> uniforms;
        private Dictionary<string, uint> buffers = new Dictionary<string, uint>();

        #region CONSTRUCTOR
        public ShaderProgram()
        {
            this.programID = GL.CreateProgram();
            this.vshaderID = -1;
            this.fshaderID = -1;
            this.attributeCount = 0;
            this.uniformCount = 0;
        }

        public ShaderProgram(string vshader, string fshader, bool fromFile = false)
        {
            this.programID = GL.CreateProgram();
 
            if (fromFile)
            {
                LoadShaderFromFile(vshader, ShaderType.VertexShader);
                LoadShaderFromFile(fshader, ShaderType.FragmentShader);
            }
            else
            {
                LoadShaderFromString(vshader, ShaderType.VertexShader);
                LoadShaderFromString(fshader, ShaderType.FragmentShader);
            }
 
            Link();
            GenBuffers();
        }
        #endregion

        #region METHODS
        private void LoadShader(string code, ShaderType type, out int address)
        {
            address = GL.CreateShader(type);
            GL.ShaderSource(address, code);
            GL.CompileShader(address);
            GL.AttachShader(this.programID, address);
        }

        public void LoadShaderFromString(String code, ShaderType type)
        {
            if (type == ShaderType.VertexShader)
            {
                LoadShader(code, type, out vshaderID);
            }
            else if (type == ShaderType.FragmentShader)
            {
                LoadShader(code, type, out fshaderID);
            }
        }

        public void LoadShaderFromFile(String filename, ShaderType type)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                if (type == ShaderType.VertexShader)
                {
                    LoadShader(sr.ReadToEnd(), type, out vshaderID);
                }
                else if (type == ShaderType.FragmentShader)
                {
                    LoadShader(sr.ReadToEnd(), type, out fshaderID);
                }
            }
        }

        public void Link()
        {
            GL.LinkProgram(this.programID);

            Console.WriteLine(GL.GetProgramInfoLog(this.programID));

            GL.GetProgram(this.programID, GetProgramParameterName.ActiveAttributes, out this.attributeCount);
            GL.GetProgram(this.programID, GetProgramParameterName.ActiveUniforms, out this.uniformCount);

            for (int i = 0; i < this.attributeCount; i++)
            {
                AttributeInfo info = new AttributeInfo();
                int length = 0;

                StringBuilder name = new StringBuilder();

                GL.GetActiveAttrib(this.programID, i, 256, out length, out info.size, out info.type, name);

                info.name = name.ToString();
                info.address = GL.GetAttribLocation(this.programID, info.name);
                this.attributes.Add(name.ToString(), info);
            }

            for (int i = 0; i < this.uniformCount; i++)
            {
                UniformInfo info = new UniformInfo();
                int length = 0;

                StringBuilder name = new StringBuilder();

                GL.GetActiveUniform(this.programID, i, 256, out length, out info.size, out info.type, name);

                info.name = name.ToString();
                this.uniforms.Add(name.ToString(), info);
                info.address = GL.GetUniformLocation(this.programID, info.name);
            }
        }

        public void GenBuffers()
        {
            for (int i = 0; i < this.attributes.Count; i++)
            {
                uint buffer = 0;
                GL.GenBuffers(1, out buffer);

                this.buffers.Add(this.attributes.Values.ElementAt(i).name, buffer);
            }

            for (int i = 0; i < this.uniforms.Count; i++)
            {
                uint buffer = 0;
                GL.GenBuffers(1, out buffer);

                this.buffers.Add(this.uniforms.Values.ElementAt(i).name, buffer);
            }
        }

        public void EnableVertexAttribArrays()
        {
            for (int i = 0; i < this.attributes.Count; i++)
            {
                GL.EnableVertexAttribArray(this.attributes.Values.ElementAt(i).address);
            }
        }

        public void DisableVertexAttribArrays()
        {
            for (int i = 0; i < this.attributes.Count; i++)
            {
                GL.DisableVertexAttribArray(this.attributes.Values.ElementAt(i).address);
            }
        }

        public int GetAttribute(string name)
        {
            if (this.attributes.ContainsKey(name))
            {
                return this.attributes[name].address;
            }
            else
            {
                return -1;
            }
        }

        public int GetUniform(string name)
        {
            if (this.uniforms.ContainsKey(name))
            {
                return this.uniforms[name].address;
            }
            else
            {
                return -1;
            }
        }

        public uint GetBuffer(string name)
        {
            if (this.buffers.ContainsKey(name))
            {
                return this.buffers[name];
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }

    public class AttributeInfo
    {
        public String name = "";
        public int address = -1;
        public int size = 0;
        public ActiveAttribType type;
    }

    public class UniformInfo
    {
        public String name = "";
        public int address = -1;
        public int size = 0;
        public ActiveUniformType type;
    }
}
