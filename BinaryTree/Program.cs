using BinaryTree;

TreeNode root = new TreeNode(1,
    new TreeNode(2,
        new TreeNode(4),
        new TreeNode(5)
    ),
    new TreeNode(3,
        new TreeNode(6),
        new TreeNode(7)
    )
);

Console.WriteLine("Original Tree:");
PrintTree(root);

TreeNode invertedRoot = InvertTree(root);

Console.WriteLine("\nInverted Tree:");
PrintTree(invertedRoot);

/*
The time complexity of the InvertTree method is O(n), where n is the number of nodes in the binary tree. 
This is because the method visits each node exactly once to swap its children and recursively invert its subtrees.
*/
static TreeNode InvertTree(TreeNode root)
{
    if (root == null)
    {
        return null;
    }

    // Swap the left and right children
    TreeNode temp = root.Left;
    root.Left = root.Right;
    root.Right = temp;

    // Recursively invert the left and right subtrees
    InvertTree(root.Left);
    InvertTree(root.Right);

    return root;
}

static void PrintTree(TreeNode root)
{
    if (root == null)
    {
        return;
    }

    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int height = GetHeight(root);
    int maxWidth = (int)Math.Pow(2, height) - 1;

    for (int level = 0; level < height; level++)
    {
        int levelSize = queue.Count;
        int spaces = (int)Math.Pow(2, height - level - 1) - 1;
        int betweenSpaces = (int)Math.Pow(2, height - level) - 1;

        PrintSpaces(spaces);

        for (int i = 0; i < levelSize; i++)
        {
            TreeNode current = queue.Dequeue();
            if (current != null)
            {
                Console.Write(current.Value);
                queue.Enqueue(current.Left);
                queue.Enqueue(current.Right);
            }
            else
            {
                Console.Write(" ");
                queue.Enqueue(null);
                queue.Enqueue(null);
            }

            if (i < levelSize - 1)
            {
                PrintSpaces(betweenSpaces);
            }
        }

        Console.WriteLine();
    }
}

static int GetHeight(TreeNode root)
{
    if (root == null)
    {
        return 0;
    }

    return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
}

static void PrintSpaces(int count)
{
    for (int i = 0; i < count; i++)
    {
        Console.Write(" ");
    }
}


