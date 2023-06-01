# Binary Tree Order Traversals in C#

This project provides an implementation of binary tree order traversal algorithms in C#. It supports three types of traversals: pre-order, in-order, and post-order. You can use these algorithms to traverse a binary tree and process the nodes in a specific order.

## Installation

To use this project, follow these steps:

1. Clone the repository:

```shell
    git clone https://github.com/Ilia-Abolhasani/binary-tree-order-traversals.git
```

2. Open the solution file (`BinaryTreeOrderTraversals.sln`) in your preferred IDE.

3. Build the solution to compile the code.

4. Use the `BinaryTree` class to create a binary tree and perform traversals:

```csharp
    BinaryTree tree = new BinaryTree();

    // Example: Adding nodes with integer values
    tree.AddNode(5);
    tree.AddNode(3);
    tree.AddNode(8);
    // Add more nodes as needed
    // Example: Pre-order traversal
    tree.PreOrderTraversal();
```

5. Customize the code to process the nodes as needed. For example, you can print the value of each node during traversal:
```csharp
    void ProcessNode(int value)
    {
        Console.WriteLine(value);
    }
```
6. Run the code to perform the traversal and process the nodes.

## Contributing

Contributions to this project are welcome. If you encounter any issues or have suggestions for improvements, please follow these steps:

1. Fork the repository.

2. Create a new branch for your contribution.

3. Make your changes and commit them.

4. Push your changes to your forked repository.

5. Submit a pull request to the main repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
