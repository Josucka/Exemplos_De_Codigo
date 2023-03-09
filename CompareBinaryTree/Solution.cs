namespace CompareBinaryTree
{
    public static class Solution
    {
        internal static bool IsEquals(Node rootNode1, Node rootNode2)
        {
            Queue<(Node?, Node?)> queue = new Queue<(Node?, Node?)>();
            queue.Enqueue((rootNode1, rootNode2));

            while (queue.Count > 1)
            {
                var (node1, node2) = queue.Dequeue();

                if (node1 is null || node2 is null)
                    if (node1 != node2)
                        return false;
                    else
                        continue;

                if (node1.Value != node2.Value)
                    return false;

                queue.Enqueue((node1.Right, node2.Right));
                queue.Enqueue((node1.Left, node2.Left));
            }
            return true;
        }
    }
}
