using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

namespace Wavefront2Roblox
{
    class WavefrontConverter
    {
        private string FileAsString = "";
        private string LuaTable = "";
        private StringBuilder luaTable2 = new StringBuilder();
        private MemoryStream meshMem = new MemoryStream();
        private MemoryStream faceMem = new MemoryStream();

        private List<Vertex> Vertices = new List<Vertex>();
        private List<VertexTexture> TextureVertices = new List<VertexTexture>();
        private List<VertexNormal> VerticesNormal = new List<VertexNormal>();
        private List<VertexParameterSpace> VerticesParameter = new List<VertexParameterSpace>();
        private List<Face> Faces = new List<Face>();

        private Thread ReaderThread;
        private Thread ConverterThread;
        public int ReadProgress { get; private set; }
        public int ConvertProgress { get; private set; }
        public void LoadFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            this.FileAsString = reader.ReadToEnd();
            reader.Close();
        }
        private Vertex ParseFaceComponent(string component)
        {
            if (component.Contains("/"))
            {
                string[] scom = component.Split('/');
                return this.Vertices[int.Parse(scom[0]) - 1];
            }
            else
            {
                return this.Vertices[int.Parse(component)];
            }
        }
        private void ReadLine(string theLine)
        {
            if (theLine.StartsWith("#"))
            {
                return;
            }

            if (theLine.Contains("  ")) {
                while (theLine.Contains("  ")) {
                    theLine = theLine.Replace("  ", " ");
                }
            }

            string[] components = theLine.Split(' ');
            if (components.Length < 1)
            {
                return;
            }

            switch (components[0])
            {
                case "v":
                    if (components.Length < 4)
                    {
                        Console.WriteLine("Invalid number of components");
                        return;
                    }

                    Vertex newVertex = new Vertex()
                    {
                        X = components[1],
                        Y = components[2],
                        Z = components[3]
                    };

                    if (components.Length > 5)
                    {
                        newVertex.W = components[4];
                    }
                    else
                    {
                        newVertex.W = "1";
                    }

                    newVertex.Index = this.Vertices.Count;
                    this.Vertices.Add(newVertex);
                    break;
                case "vt":
                    if (components.Length < 3)
                    {
                        Console.WriteLine("Invalid number of components");
                        return;
                    }

                    VertexTexture newTextureVertex = new VertexTexture()
                    {
                        U = components[1],
                        V = components[2]
                    };

                    if (components.Length > 4)
                    {
                        newTextureVertex.W = components[3];
                    }

                    this.TextureVertices.Add(newTextureVertex);
                    break;
                case "f":
                    Face newFace = new Face() { };
                    newFace.Vertices = new List<Vertex>();

                    for (int i = 1; i < components.Length; i++)
                    {
                        if (components[i] == "") { continue;  }
                        newFace.Vertices.Add(this.ParseFaceComponent(components[i]));
                    }

                    this.Faces.Add(newFace);
                    break;
                default:
                    // Unsupported
                    // Console.WriteLine("Unsupported type {0}", components[0]);
                    break;
            }
        }

        public void ReadFile()
        {
            this.FileAsString = this.FileAsString.Replace("\r", "");
            string[] lines = this.FileAsString.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                this.ReadLine(lines[i]);
                this.ReadProgress = ((i + 1) / lines.Length) * 100;
            }
        }
        public void ConvertFile()
        {
            // this.LuaTable = "{ ";
            this.luaTable2.Append("local faces = {");
            for (int i = 0; i < this.Faces.Count; i++)
            {
                if (this.Faces[i].Vertices.Count > 3)
                {
                    continue;
                }

                foreach (Vertex vertex in this.Faces[i].Vertices)
                {
                    this.luaTable2.Append(string.Format("{0},{1},{2},{3},", vertex.X, vertex.Y, vertex.Z, vertex.W));
                }

                this.ConvertProgress = ((i + 1) / this.Faces.Count) * 100;
            }
            this.luaTable2.Append("}\n\n");
            this.luaTable2.Append(Properties.Resources.rebuilder);
        }
        public int CountFaces()
        {
            return this.Faces.Count();
        }
        public void ConvertToCSG()
        {
            if (this.meshMem != null)
            {
                this.meshMem.Dispose();
                this.meshMem = new MemoryStream();
            }

            if (this.faceMem != null)
            {
                this.faceMem.Dispose();
                this.faceMem = new MemoryStream();
            }

            for (int i = 0; i < this.Faces.Count; i++)
            {
                if (this.Faces[i].Vertices.Count > 3)
                {
                    continue;
                }

                List<float> indexes = new List<float>();
                foreach (Vertex vertex in this.Faces[i].Vertices)
                {
                    byte[] xBytes = BitConverter.GetBytes(float.Parse(vertex.X));
                    byte[] yBytes = BitConverter.GetBytes(float.Parse(vertex.Y));
                    byte[] zBytes = BitConverter.GetBytes(float.Parse(vertex.Z));
                    byte[] padBytes = BitConverter.GetBytes(0x38F000);

                    this.meshMem.Write(xBytes, 0, xBytes.Length);
                    this.meshMem.Write(yBytes, 0, yBytes.Length);
                    this.meshMem.Write(zBytes, 0, zBytes.Length);
                    this.meshMem.Write(padBytes, 0, padBytes.Length);
                    this.meshMem.Write(padBytes, 0, padBytes.Length);
                    this.meshMem.Write(padBytes, 0, padBytes.Length);

                    indexes.Add(vertex.Index);
                }

                foreach (float idx in indexes)
                {
                    byte[] idxBytes = BitConverter.GetBytes(idx);
                    this.faceMem.Write(idxBytes, 0, idxBytes.Length);
                }
            }
        }
        public void ReadFileThreaded()
        {
            ThreadStart readerStart = new ThreadStart(this.ReadFile);
            this.ReaderThread = new Thread(readerStart);
            this.ReaderThread.Start();
        }
        public void WriteFile(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(this.luaTable2.ToString());
            writer.Close();
        }
        public void WriteCSGFile(string fileName)
        {
            string[] pathSplit = fileName.Split('\\');
            string[] extSplit = pathSplit[pathSplit.Length - 1].Split('.');
            string objectName = extSplit[0];

            this.meshMem.Write(new byte[8], 0, 8);

            this.meshMem.Seek(0, SeekOrigin.Begin);
            byte[] meshMemBuffer = new byte[this.meshMem.Length];
            this.meshMem.Read(meshMemBuffer, 0, (int)this.meshMem.Length);
            string base64Mesh = Convert.ToBase64String(meshMemBuffer);

            this.faceMem.Seek(0, SeekOrigin.Begin);
            byte[] faceMemBuffer = new byte[this.faceMem.Length];
            this.faceMem.Read(faceMemBuffer, 0, (int)this.faceMem.Length);
            string base64Faces = Convert.ToBase64String(faceMemBuffer);

            byte[] compositeBuffer = new byte[meshMemBuffer.Length + faceMemBuffer.Length];
            for (int i = 0; i < meshMemBuffer.Length; i++)
            {
                compositeBuffer[i] = meshMemBuffer[i];
            }
            for (int i = 0; i < faceMemBuffer.Length; i++)
            {
                compositeBuffer[meshMemBuffer.Length + i] = faceMemBuffer[i];
            }
            string base64Composite = Convert.ToBase64String(compositeBuffer);

            string completeFile = Properties.Resources.rbxmtemplate;
            completeFile = completeFile.Replace("%name%", objectName);
            completeFile = completeFile.Replace("%meshdata%", base64Composite);
            completeFile = completeFile.Replace("%physicsdata%", base64Faces);

            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(completeFile);
            sw.Flush(); sw.Close();
        }
        public void ConvertFileThreaded()
        {
            ThreadStart convertStart = new ThreadStart(this.ConvertFile);
            this.ConverterThread = new Thread(convertStart);
            this.ConverterThread.Start();
        }
    }
}
