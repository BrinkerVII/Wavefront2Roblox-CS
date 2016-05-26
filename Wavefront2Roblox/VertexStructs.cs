using System.Collections.Generic;

namespace Wavefront2Roblox
{
    struct Vertex
    {
        public string X;
        public string Y;
        public string Z;
        public string W;
        public int Index;
    }

    struct VertexNormal
    {
        public string X;
        public string Y;
        public string Z;
    }

    struct VertexParameterSpace
    {
        public string U;
        public string V;
        public string W;
    }

    struct VertexTexture
    {
        public string U;
        public string V;
        public string W;
    }

    struct Face
    {
        public List<Vertex> Vertices;
    }
}