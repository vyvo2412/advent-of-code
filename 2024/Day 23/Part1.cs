namespace AdventOfCode._2024.Day23
{
    public class Part1
    {
        private Dictionary<string, HashSet<string>> _graph = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            var total = 0;
            var triangles = new HashSet<string>();

            foreach (var node in _graph.Keys)
            {
                foreach (var neighbor in _graph[node])
                {
                    foreach (var commonNeighbor in _graph[neighbor].Intersect(_graph[node]))
                    {
                        var triangle = new[] { node, neighbor, commonNeighbor }.OrderBy(x => x).ToArray();
                        triangles.Add(string.Join(",", triangle));
                    }
                }
            }

            foreach (var triangle in triangles)
            {                
                if (triangle[0] == 't' || triangle[3] == 't' || triangle[6] == 't') total++;
            }

            Console.WriteLine(total);
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                var pair = line.Split("-");
                var a = pair[0];
                var b = pair[1];

                if (!_graph.ContainsKey(a)) _graph[a] = new HashSet<string>();
                if (!_graph.ContainsKey(b)) _graph[b] = new HashSet<string>();

                _graph[a].Add(b);
                _graph[b].Add(a);
            }
        }
    }
}
