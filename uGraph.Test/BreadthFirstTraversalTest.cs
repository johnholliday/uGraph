﻿using System;
using Xunit;

namespace uGraph.Test
{
    public class BreadthFirstTraversalTest
    {
        [Fact]
        public void BFTWithNullInitialVertexArgumentShouldThrowArgumentNullException()
        {
            Graph<object, object> graph = new Graph<object, object>();

            string output = string.Empty;

            Assert.Throws<ArgumentNullException>(() => graph.BreadthFirstTraversal(null, (v) => output += v.Info.ToString()));
        }

        [Fact]
        public void BFTWithNullActionArgumentShouldThrowArgumentNullException()
        {
            Graph<object, object> graph = new Graph<object, object>();
            graph.AddVertex(new object());

            var firstVertex = graph.Vertices[0];

            Assert.Throws<ArgumentNullException>(() => graph.BreadthFirstTraversal(firstVertex, null));
        }

        [Fact]
        public void BFTDirectSampleTest1()
        {
            Graph<int, object> graph = new Graph<int, object>();

            for (int i = 0; i < 4; i++)
            {
                graph.AddVertex(i);
            }

            graph.AddEdge(0, 1, null);
            graph.AddEdge(0, 2, null);
            graph.AddEdge(1, 2, null);
            graph.AddEdge(2, 0, null);
            graph.AddEdge(2, 3, null);
            graph.AddEdge(3, 3, null);

            var firstVertex = graph.FirstOrDefault(v => v == 0);

            string output = string.Empty;

            graph.DepthFirstTraversal(firstVertex, (v) => output += v.Info.ToString());

            Assert.Equal("0231", output);
        }

        [Fact]
        public void BFTUndirectSampleTest2()
        {
            Graph<char, object> graph = new Graph<char, object>();

            for (char c = 'A'; c <= 'G'; c++)
            {
                graph.AddVertex(c);
            }

            graph.AddEdge('A', 'B', null);
            graph.AddEdge('B', 'D', null);
            graph.AddEdge('B', 'F', null);
            graph.AddEdge('A', 'C', null);
            graph.AddEdge('C', 'G', null);
            graph.AddEdge('A', 'E', null);
            graph.AddEdge('E', 'F', null);

            //Making graph undirected
            graph.AddEdge('B', 'A', null);
            graph.AddEdge('D', 'B', null);
            graph.AddEdge('F', 'B', null);
            graph.AddEdge('C', 'A', null);
            graph.AddEdge('G', 'C', null);
            graph.AddEdge('E', 'A', null);
            graph.AddEdge('F', 'E', null);

            var firstVertex = graph.FirstOrDefault(v => v == 'A');

            string output = string.Empty;

            graph.BreadthFirstTraversal(firstVertex, (v) => output += v.Info.ToString());

            Assert.Equal("ABCEDFG", output);
        }

        [Fact]
        public void BFTUndirectSampleTest3()
        {
            Graph<char, object> graph = new Graph<char, object>();

            for (char c = 'A'; c <= 'G'; c++)
            {
                graph.AddVertex(c);
            }

            graph.AddEdge('A', 'B', null);
            graph.AddEdge('B', 'D', null);
            graph.AddEdge('B', 'F', null);
            graph.AddEdge('A', 'C', null);
            graph.AddEdge('C', 'G', null);
            graph.AddEdge('A', 'E', null);
            graph.AddEdge('E', 'F', null);

            //Making graph undirected
            graph.AddEdge('B', 'A', null);
            graph.AddEdge('D', 'B', null);
            graph.AddEdge('F', 'B', null);
            graph.AddEdge('C', 'A', null);
            graph.AddEdge('G', 'C', null);
            graph.AddEdge('E', 'A', null);
            graph.AddEdge('F', 'E', null);

            var firstVertex = graph.FirstOrDefault(v => v == 'G');

            string output = string.Empty;

            graph.BreadthFirstTraversal(firstVertex, (v) => output += v.Info.ToString());

            Assert.Equal("GCABEDF", output);
        }
    }
}
