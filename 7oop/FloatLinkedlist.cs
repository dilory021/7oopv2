using System.Collections;

namespace _7oop
{
    /// Клас, що описує вузол односпрямованого зв'язаного списку
    public class Node
    {
        public float Data { get; set; }
        public Node Next { get; set; }

        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    /// Односпрямований лінійний список для зберігання дійсних чисел
    public class FloatLinkedList : IEnumerable<float>
    {
        private Node _head;
        private Node _tail;
        private int _count;

        public int Count => _count;

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс поза межами.");
        }

        public void AddLast(float data)
        {
            Node newNode = new Node(data);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }
        //індексатор
        public float this[int index]
        {
            get
            {
                ValidateIndex(index);
                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            if (index == 0)
            {
                _head = _head.Next;
                if (_head == null) _tail = null;
            }
            else
            {
                Node previous = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    previous = previous.Next;
                }
                previous.Next = previous.Next.Next;
                if (previous.Next == null) _tail = previous;
            }
            _count--;
        }
        //знайти елемент більший за порогове значення
        public float? FindFirstGreaterThan(float threshold)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data > threshold) return current.Data;
                current = current.Next;
            }
            return null;
        }
//сума
        public float SumLessThanFirstNegative()
        {
            float? firstNegative = null;
            Node current = _head;
            
            while (current != null)
            {
                if (current.Data < 0)
                {
                    firstNegative = current.Data;
                    break;
                }
                current = current.Next;
            }

            if (!firstNegative.HasValue) return 0; 

            float sum = 0;
            current = _head;
            while (current != null)
            {
                if (current.Data < firstNegative.Value) sum += current.Data;
                current = current.Next;
            }
            return sum;
        }
//новий список більший за порогове
        public FloatLinkedList GetListGreaterThan(float threshold)
        {
            FloatLinkedList newList = new FloatLinkedList();
            Node current = _head;
            while (current != null)
            {
                if (current.Data > threshold) newList.AddLast(current.Data);
                current = current.Next;
            }
            return newList;
        }
        //форіч
        public IEnumerator<float> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}