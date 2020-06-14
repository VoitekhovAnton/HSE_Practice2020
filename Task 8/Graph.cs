using System;
using System.Collections.Generic;
using System.Text;

namespace Task_8
{
    class Graph
    {
        
        private readonly int V;
        private readonly List<List<int>> adj;

        public bool IsConnected() 
        {
          for (int i = 0; i < adj.Count; i++)
            {
                int CountTheSmae = 0;
                if (adj[i].Count == 0)
                {
                    CountTheSmae = -1;
                    bool lonly = toEdge(i);
                    if (lonly)
                        return false;
                }                    
                for(int j = 0; j < adj[i].Count; j++)
                {
                    if (adj[i][j] == i)
                        CountTheSmae++;
                }
                if (CountTheSmae == adj[i].Count)
                    return false;
            }
            return true;
        }// Проверка графа на связность
        private bool toEdge(int Edge)
        {
            for (int i = 0; i < adj.Count; i++)
            {
                if (adj[i].Count != 0)
                {
                    for (int j = 0; j < adj[i].Count; j++)
                    {
                        if (adj[i][j] == Edge)
                            return false;
                    }
                }
            }
            return true;
        } // Проверка на концевую вершину
        public Graph(int V)
        {
            this.V = V;
            adj = new List<List<int>>(V);

            for (int i = 0; i < V; i++)
                adj.Add(new List<int>());
        }

     
        private bool isCyclicUtil(int i, bool[] visited,
                                        bool[] recStack)
        {
                // Отмечаем текущий узел, как посещённый 
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (isCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

        public void addEdge(int sou, int dest) 
        {
            adj[sou].Add(dest);
        }

       // Возвращает true, если граф содержит цикл
        public bool isCyclic()
        {

            // Помечаем все вершины, как непосещённые
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];


            
            for (int i = 0; i < V; i++)
                if (isCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }

      


    }
}
