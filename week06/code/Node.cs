public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Do not insert duplicates
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base case: found the value
        if (value == Data)
            return true;
            
        // Recursively search left or right subtree
        if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Base case: leaf node has height 1
        int leftHeight = Left?.GetHeight() ?? 0;   // 0 if null
        int rightHeight = Right?.GetHeight() ?? 0; // 0 if null
        
        // Height is 1 + maximum height of subtrees
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}