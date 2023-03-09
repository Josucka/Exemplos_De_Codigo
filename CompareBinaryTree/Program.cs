using CompareBinaryTree;

Node tree1 = new Node(1, new(2), new(3));
Node tree2 = new Node(1, new(2), new(3));
Node tree3 = new Node(1, new(2, new(4), new(5)), new(3));
Node tree4 = new Node(1, new(2, new(4), new(5)), new(3));

Console.WriteLine("Comparing Binary Trees");

Console.WriteLine($"Test 1 = equals = {(Solution.IsEquals(tree1, tree2) ? "Ok" : "X")}");
Console.WriteLine($"Test 2 = not equals = {(!Solution.IsEquals(tree2, tree3) ? "Ok" : "X")}");
Console.WriteLine($"Test 2 = equals = {(Solution.IsEquals(tree3, tree4) ? "Ok" : "X")}");
Console.WriteLine($"Test 2 = not equals = {(!Solution.IsEquals(tree4, tree1) ? "Ok" : "X")}");

