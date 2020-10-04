namespace LinkedList.Logic
{
    public class MyLinkedList
    {
        public int Size { get; set; }
        public Node Head { get; set; }

        public MyLinkedList()
        {
            Size = 0;
            Head = new Node(0);
        }

        public int Get(int index)
        {
            if (index < 0 || index >= Size)
                return -1;

            var nodeToReturn = Head;
            for (int i = 0; i < index; i++)
            {
                nodeToReturn = nodeToReturn.Next;
            }

            return nodeToReturn.Value;
        }

        public void AddAtHead(int val)
        {
            AddAtIndex(0, val);
        }

        public void AddAtTail(int val)
        {
            AddAtIndex(Size, val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index >= Size)
            {
                return;
            }

            if (index < 0)
            {
                index = 0;
            }

            var pred = Head;

            for (int i = 0; i < index; i++)
            {
                pred = pred.Next;
            }

            var newNode = new Node(val) { Next = pred.Next };
            pred.Next = newNode;
            Size++;
        }

        public void DeleteAtIndex(int index, int val)
        {
            if (index >= Size || index < 0)
            {
                return;
            }

            var pred = Head;

            for (int i = 0; i < index; i++)
            {
                pred = pred.Next;
            }

            pred.Next = pred.Next.Next;
            Size--;
        }
    }
}