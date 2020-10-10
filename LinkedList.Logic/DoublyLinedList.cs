namespace LinkedList.Logic
{
    public class DoublyLinedList
    {
        private DoublyListNode _head;

        public DoublyLinedList()
        {
            _head = null;
        }

        private DoublyListNode GetNode(int index)
        {
            DoublyListNode cur = _head;
            for (var i = 0; i < index && cur != null; i++)
            {
                cur = cur.Next;
            }
            return cur;
        }

        private DoublyListNode GetTail()
        {
            DoublyListNode cur = _head;
            while (cur?.Next != null)
            {
                cur = cur.Next;
            }
            return cur;
        }

        public int Get(int index)
        {
            DoublyListNode cur = GetNode(index);
            return cur?.Val ?? -1;
        }

        public void AddAtHead(int val)
        {
            DoublyListNode cur = new DoublyListNode(val) { Next = _head };
            if (_head != null)
            {
                _head.Prev = cur;
            }
            _head = cur;
            return;
        }

        public void AddAtTail(int val)
        {
            if (_head == null)
            {
                AddAtHead(val);
                return;
            }
            DoublyListNode prev = GetTail();
            DoublyListNode cur = new DoublyListNode(val);
            prev.Next = cur;
            cur.Prev = prev;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index == 0)
            {
                AddAtHead(val);
                return;
            }
            var prev = GetNode(index - 1);
            if (prev == null)
            {
                return;
            }
            DoublyListNode cur = new DoublyListNode(val);
            DoublyListNode next = prev.Next;
            cur.Prev = prev;
            cur.Next = next;
            prev.Next = cur;
            if (next != null)
            {
                next.Prev = cur;
            }
        }

        public void DeleteAtIndex(int index)
        {
            DoublyListNode cur = GetNode(index);
            if (cur == null)
            {
                return;
            }
            DoublyListNode prev = cur.Prev;
            DoublyListNode next = cur.Next;
            if (prev != null)
            {
                prev.Next = next;
            }
            else
            {
                _head = next;
            }
            if (next != null)
            {
                next.Prev = prev;
            }
        }
    }
}