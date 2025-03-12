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

static void PrintTree(TreeNode root, string indent = "", bool isLeft = true)
{
    if (root != null)
    {
        Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + root.Value);
        indent += isLeft ? "│   " : "    ";
        PrintTree(root.Left, indent, true);
        PrintTree(root.Right, indent, false);
    }
}



