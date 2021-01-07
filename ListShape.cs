using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP_4
{
    abstract public class ListShape<T> : IEnumerable<T> where T:ShapeViewer 
    {
        DoublyNode head; 
        DoublyNode tail; 
        int count;  
        private class DoublyNode
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode Previous { get; set; }
            public DoublyNode Next { get; set; }
        }
        
        public void Add(T data)
        {
            DoublyNode node = new DoublyNode(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode node = new DoublyNode(data);
            DoublyNode temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        
        public bool Remove(T data)
        {
            DoublyNode current = head;

            
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }
                
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
        abstract protected T CreateShape(string shapeString, string shapePosition, string shapeColor, int size);
        
        public void loadShapes(StreamReader reader)
        {
            //string[] readerString = reader.ReadToEnd().Split('\n');
            Regex regex = new Regex(@"Shape:(.+); Position:(.+); Color:(.+); Size:(\d+)");
            MatchCollection matches = regex.Matches(reader.ReadToEnd());
            foreach (Match match in matches)
            {
                GroupCollection collect = match.Groups;
                string shapeString = collect[1].Value;
                string shapePosition = collect[2].Value;
                string shapeColor = collect[3].Value;
                string shapeSize = collect[4].Value;
                int size = Int32.Parse(shapeSize);
                this.Add(CreateShape(shapeString, shapePosition, shapeColor, size));

            }
            
        }

    }
}
