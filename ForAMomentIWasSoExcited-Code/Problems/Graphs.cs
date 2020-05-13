using ForAMomentIWasSoExcited_Code.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace ForAMomentIWasSoExcited_Code.Problems
{

    /* The Problem:
     You have a map that marks the location of a treasure island. Some of the map area has jagged rocks and dangerous reefs. Other areas are safe to sail in.
There are other explorers trying to find the treasure. So you must figure out a shortest route to the treasure island.
Assume the map area is a two dimensional grid, represented by a matrix of characters.
You must start from the top-left corner of the map and can move one block up, down, left or right at a time.
The treasure island is marked as ‘X’ in a block of the matrix. ‘X’ will not be at the top-left corner.
Any block with dangerous rocks or reefs will be marked as ‘D’. You must not enter dangerous blocks. You cannot leave the map area.
Other areas ‘O’ are safe to sail in. The top-left corner is always safe.
Output the minimum number of steps to get to the treasure.
e.g.
Input
[
[‘O’, ‘O’, ‘O’, ‘O’],
[‘D’, ‘O’, ‘D’, ‘O’],
[‘O’, ‘O’, ‘O’, ‘O’],
[‘X’, ‘D’, ‘D’, ‘O’],
]

Output from aonecode.com
Route is (0, 0), (0, 1), (1, 1), (2, 1), (2, 0), (3, 0) The minimum route takes 5 steps.
         */
    class Graphs
    {
        //this code is built on top of this solution: https://leetcode.com/discuss/interview-question/347457/Amazon-or-OA-2019-or-Treasure-Island/317634
        internal static LinkedList<Point> FindShortestDistance(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return null;
            int steps = 0;
            //in BFS nodes are queued, unlike the DFS algorithm which uses stack
            Queue<Point> queue = new Queue<Point>();
            //we need to mark every visited nodes, so we don't scan it again
            bool[,] visited = new bool[matrix.Length, matrix[0].Length];
            //this tree is to represent the solution in a parent-child relationship to be able to get the route
            //BFS doesn't know which nodes led to the target one, it only can help count levels until the goal is reached
            Tree<Point> tree = new Tree<Point>();
            
            LinkedList<Point> route = new LinkedList<Point>();
            TreeNode<Point> goal = null;
            var head = new Point(0, 0);
            queue.Enqueue(head);
            visited[0, 0] = true;
            //down,up,right,left ({row, column})
            int[][] dirs = new int[][] { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
            //on every node visited, we save it in this HashSet, every node becomes a potential parent for the next iteration's nodes, so we need to register these relations
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
                        parent = tree.Add(point);
                    else
                        parent = tree.Last;
                    int x = point.R;
                    int y = point.C;
                    if (matrix[x][y] == 'X')
                    {
                        var curr = goal;
                        while (curr != null)
                        {
                            route.AddFirst(curr.Value);
                            curr = curr.Parents.First();
                        }
                        return route;
                    }

                    foreach (int[] dir in dirs)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];
                        //findng the available unvisited direction 
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
                            if (matrix[newX][newY] == 'X') goal = node;
                            parentsCache.Add(node);
                            visited[newX, newY] = true;
                        }
                    }
                }
                steps++;
            }
            return null;
        }

        public static void Execute()
        {
            var orders = new string[] { "zld 93 12", "fp iPad Mini", "10a Galaxy Note 10", "17g 12 25 6", "ab1 iPad Mini", "125 Galaxy Note 10 Plus" };
            var grid = new char[][]
         {
              new char[] { 'O', 'O', 'O', 'D' }, //0
              new char[] { 'D', 'O', 'D', 'O' }, //1
              new char[] { 'O', 'O', 'O', 'O' }, //2
              new char[] { 'O', 'O', 'O', 'O' }, //3
              new char[] { 'O', 'O', 'O', 'O' }, //4
              new char[] { 'O', 'O', 'D', 'D' }, //5
              new char[] { 'O', 'O', 'O', 'O' }, //6
              new char[] { 'O', 'O', 'O', 'O' }, //7
              new char[] { 'O', 'O', 'O', 'O' }, //8
              new char[] { 'O', 'O', 'D', 'X' }, //9
              new char[] { 'O', 'O', 'O', 'O' }, //10
              new char[] { 'O', 'O', 'O', 'O' }, //11
              new char[] { 'O', 'O', 'O', 'O' }, //12
              new char[] { 'O', 'O', 'O', 'O' }, //13
              new char[] { 'O', 'O', 'O', 'O' }, //14
              new char[] { 'O', 'O', 'O', 'O' }, //15
              new char[] { 'O', 'O', 'O', 'O' }, //16
              new char[] { 'O', 'O', 'O', 'O' }, //17
              new char[] { 'O', 'O', 'O', 'O' }, //18
              new char[] { 'D', 'D', 'D', 'O' }  //19
         };
            var result = Problems.Graphs.FindShortestDistance(grid);
        }

    }
}
