using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class SearchSolution
    {
        public int MinMeetings(int[] start, int targetColor)
        {
            if ((start[0] == 0 && start[1] == 0) || (start[0] == 0 && start[2] == 0) || (start[1] == 0 && start[2] == 0))
            {
                if ((start[0] == 0 && targetColor == 1) || (start[1] == 0 && targetColor == 2) || (start[2] == 0 && targetColor == 0))
                {
                    return -1;
                }
                return 0;
            }

            Queue<Tuple<int, int, int, int>> queue = new Queue<Tuple<int, int, int, int>>();
            HashSet<string> visited = new HashSet<string>();
            queue.Enqueue(Tuple.Create(start[0], start[1], start[2], 0)); 
            visited.Add($"{start[0]},{start[1]},{start[2]}");

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int red = current.Item1;
                int green = current.Item2;
                int blue = current.Item3;
                int meetings = current.Item4;

                if ((targetColor == 0 && green == 0 && blue == 0) || (targetColor == 1 && red == 0 && blue == 0) || (targetColor == 2 && red == 0 && green == 0))
                {
                    return meetings;
                }

                if (red > 0 && green > 0)
                {
                    var newState = Tuple.Create(red - 1, green - 1, blue + 2);
                    string stateKey = $"{newState.Item1},{newState.Item2},{newState.Item3}";
                    if (!visited.Contains(stateKey))
                    {
                        visited.Add(stateKey);
                        queue.Enqueue(Tuple.Create(newState.Item1, newState.Item2, newState.Item3, meetings + 1));
                    }
                }

                if (red > 0 && blue > 0)
                {
                    var newState = Tuple.Create(red - 1, green + 2, blue - 1);
                    string stateKey = $"{newState.Item1},{newState.Item2},{newState.Item3}";
                    if (!visited.Contains(stateKey))
                    {
                        visited.Add(stateKey);
                        queue.Enqueue(Tuple.Create(newState.Item1, newState.Item2, newState.Item3, meetings + 1));
                    }
                }

                if (green > 0 && blue > 0)
                {
                    var newState = Tuple.Create(red + 2, green - 1, blue - 1);
                    string stateKey = $"{newState.Item1},{newState.Item2},{newState.Item3}";
                    if (!visited.Contains(stateKey))
                    {
                        visited.Add(stateKey);
                        queue.Enqueue(Tuple.Create(newState.Item1, newState.Item2, newState.Item3, meetings + 1));
                    }
                }
            }

            return -1;
        }
    }
}
