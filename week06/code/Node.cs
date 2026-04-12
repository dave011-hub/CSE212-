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
        if (value == Data)
        {
            return;    
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }
            else
                return Left.Contains(value);
        }
            if(value > Data)
        {
            if (Right is null)
            {
                return false;
            }
            else
                return Right.Contains(value);
        }
      
        return false;
    } 

    public int GetHeight()
    {
        // TODO Start Problem 4
        int left_height;
        int right_height;
        if (Left is null)
        {
            left_height = 0;
        }
        else
        {
            left_height = Left.GetHeight();
        }
        if (Right is null)
        {
            right_height = 0;
        }
        else
        {
            right_height = Right.GetHeight();
        }
        return Math.Max(left_height, right_height) + 1; // Replace this line with the correct return statement(s)
    }
}