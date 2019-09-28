using ForAMomentIWasSoExcited_Code.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAMomentIWasSoExcited_Code.Problems
{
    class Graphs
    {
        //this code is built on top of this solution: https://leetcode.com/discuss/interview-question/347457/Amazon-or-OA-2019-or-Treasure-Island/317634
        internal static LinkedList<Point> FindShortestDistance(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return null;
            int steps = 0;
            Queue<Point> queue = new Queue<Point>();
            bool[,] visited = new bool[matrix.Length, matrix[0].Length];
            Tree<Point> tree = new Tree<Point>();
            LinkedList<Point> route = new LinkedList<Point>();
            TreeNode<Point> target = null;
            var head = new Point(0, 0);
            queue.Enqueue(head);
            visited[0, 0] = true;
            int[][] dirs = new int[][] { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };

            HashSet<TreeNode<Point>> parentsCache = new HashSet<TreeNode<Point>>();
            //BFS
            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Point point = queue.Dequeue();
                    TreeNode<Point> parent;
                    if (tree.Root == null)
                        parent = tree.Add(point, tree.Last);
                    else
                        parent = tree.Last;
                    int x = point.R;
                    int y = point.C;
                    if (matrix[x][y] == 'X')
                    {
                        var curr = target;
                        while (true)
                        {
                            if (curr != null)
                                route.AddLast(curr.Value);
                            else
                                break;
                            curr = curr.Parents.First();
                        }
                        return route;
                    }

                    foreach (int[] dir in dirs)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];

                        if (newX >= 0 && newX < matrix.Length && newY >= 0 && newY < matrix[0].Length &&
                                matrix[newX][newY] != 'D' && !visited[newX, newY])
                        {
                            var child = new Point(newX, newY);
                            queue.Enqueue(child);

                            var parents = parentsCache.Where(p => p.Value.IsParentTo(child));
                            TreeNode<Point> node;
                            if (parents != null && parents.Count() > 0)
                            {
                                node = tree.AddMultiParent(child, parents.ToList());
                            }
                            else
                            {
                                node = tree.Add(child, parent);
                            }
                            if (matrix[newX][newY] == 'X') target = node;
                            parentsCache.Add(node);
                            visited[newX, newY] = true;
                        }
                    }
                }
                steps++;
            }
            return null;
        }

    }
}
