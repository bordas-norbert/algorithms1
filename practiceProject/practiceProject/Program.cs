using System.Collections;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Windows.Markup;

namespace practiceProject
{
    /*
    public class Array
    {
        private int size;
        private int currentSizeIndex = 0;
        private int[] elements;
        public Array(int number)
        {
            if (number <= 0)
                elements = new int[0];
            elements = new int[number];
            size = number;
        }

        public int length() { return currentSizeIndex; }
        public void insert(int elementToInsert)
        {
            if (currentSizeIndex >= size)
            {
                currentSizeIndex++;
                size += 3;
                int[] aux = new int[size];
                for (int i = 0; i < currentSizeIndex - 1; i++)
                {
                    aux[i] = elements[i];
                }
                aux[currentSizeIndex - 1] = elementToInsert;
                elements = aux;
            }
            else
            {
                elements[currentSizeIndex] = elementToInsert;
                currentSizeIndex++;
            }
        }
        public void removeAt(int delIndex)
        {
            if (delIndex >= currentSizeIndex) return;
            int[] aux = new int[size-1];
            for(int i= 0; i < delIndex; i++)
                aux[i] = elements[i];
            for(int i=delIndex + 1; i < size; i++)
                aux[i-1] = elements[i];
            size--;
            currentSizeIndex--;
            elements= aux;
        }
        public void print()
        {
            for(int i = 0; i < currentSizeIndex; i++)
                Console.Write(elements[i] + " ");
            Console.WriteLine();
        }
        public int indexOf(int toFind)
        {
            int found = -1;
            for (int i=0; i<currentSizeIndex; i++)
            {
                if (elements[i] == toFind)
                {
                    found = i;
                    break;
                }
            }
            return found;
        }

        public int max()
        {
            int max = elements[0];
            for (int i = 1; i< currentSizeIndex; i++)
            {
                if (max < elements[i])
                    max = elements[i];
            }
            return max;
        }
        public void intersect(Array v)
        {
            Array aux = new Array(0);
            for(int i = 0; i < currentSizeIndex; i++)
            {
             if (v.indexOf(elements[i]) != -1)
                 aux.insert(elements[i]);
            }
            aux.print();
        }

        public void reverse()
        {
            int[] aux = new int[currentSizeIndex];
            for(int i = 0; i < currentSizeIndex; i++)
            {
                aux[i] = elements[currentSizeIndex - 1 - i];
            }
            elements = aux;
        }

        public void insertAt(int item, int index)
        {
            if (index < 0 || index > size) return;

            int[] aux = new int[currentSizeIndex + 1];
            for(int i = 0; i < index; i++)
            {
                aux[i] = elements[i];
            }
            aux[index] = item;
            for(int i = index; i < currentSizeIndex; i++)
            {
                aux[i + 1] = elements[i];
            }
            elements = aux;
            currentSizeIndex++; 
        }
    }

    */
    public class LinkedList
    { 
        private class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }
        }
        private Node first;
        private Node last;

        private int count = 0;
        private bool isEmpty() { return first == null && last == null;}
        public void addLast(int value)
        {
            Node x = new Node(value);

            if (first == null)
                first = last = x;
            else
            {
                last.next = x;
                last = x;
            }
            count++;
        }
        public void addFirst(int value)
        {
            if(first == null)
            {
                Node x = new Node(value);
                first = x;
                last = x;
            }
            else 
            { 
                Node x = new Node(value);
                x.next = first;
                first = x;
            }
            count++;
        }

        public int indexOf(int value)
        {
            Node x = new Node(value);
            x = first;
            int index = -1;
            while(x != null)
            {
                index++;
                if (x.value == value)
                    return index;
                else
                    x = x.next;
            }
            return -1;
        }

        public bool contains(int value)
        {
            Node i = first;
            while (i != null)
            {
                if (i.value == value)
                    return true;
                else
                    i = i.next;
            }
            return false;
        }

        public int removeFirst()
        {
            if (isEmpty())
                throw new Exception("NoSuchElement");

            if (first == last)
            {
                int firstValue = first.value;
                first = last = null;
                count--;
                return firstValue;

            }
            else
            {
                int firstValue = 0;
                var aux = new Node(0);
                aux = first.next;
                first.next = null;
                firstValue = first.value;
                first = aux;
                count--;
                return firstValue;
            }
            
        }

        public int removeLast()
        {
            if (isEmpty())
                throw new Exception("isEmpty");

            if (last == first)
            {
                int value1 = last.value;
                last = first = null;
                count--;
                return value1; 
            }

            var x = first;
            while(x.next.next != null)
                x= x.next;

            last = x;
            int value = last.value;
            last.next = null;
            count--;
            return value;
        }

        public int size()
        {
            return count;
        }

        public int[] toArray()
        {
            int[] a = new int[count];
            var x = first;
            for(int i = 0; i < count; i++)
            {
                a[i] = x.value;
                x = x.next;
            }
            return a;
        }
        public void reverse()
        {
            if (isEmpty() || count == 1) return;
            Node current = first;
            Node aux = first.next;
            Node aux2 = aux.next;
            while(aux2 != null)
            {
                aux.next = current;
                current = aux;
                aux = aux2;
                aux2 = aux2.next;
            }
            aux.next = current;
            last = first;
            last.next = null;
            first = aux;
        }

        public int getKthNodeFromTheEnd(int k)
        {
            if (k > count || k <= 0 || isEmpty()) throw new Exception("InvalidKvalue");
            Node f, s;
            f = s = first;
            int i = 0;
            for(i = 0; i < k-1; i++)
                s = s.next;
            while(s.next != null)
            {
                s = s.next;
                f = f.next;
            }

            return f.value;
        }

        public void printMiddle()
        {
            Node a, b;
            a = first;
            b = a.next;
            while(b != null && b.next != null)
            {
                a = a.next;
                b = b.next;
                if (b != null)
                    b = b.next;
            }
            if (b != null)
            {
                Console.Write(a.value + " ");
                Console.WriteLine(a.next.value);
            }
            else
                Console.WriteLine(a.value);
        }
        private Node getRandomNodeFromTheList()
        {
            Random rnd = new Random();
            Node a = first;
            int rndNodeIndex = rnd.Next(0,count);
            for(int i = 0; i < rndNodeIndex; i++) 
                a = a.next;
            return a;
        }

        public bool hasLoop()
        {
            //comment out if you don't want to have a loop in your list
            //last.next = getRandomNodeFromTheList();
            Node fast, slow;
            fast = first.next;
            slow = first;
            while (fast != slow && (fast.next != null && fast != null))
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return fast == slow;
        }
    }
    /*
    public class myStack
    {
        private int[] values;
        private int count = 0;
        public myStack()
        {
            values = new int[10];
        }

        public void push(int value)
        {
            
            if(count == values.Length)
            {
                int[] aux = new int[count + 10];
                for (int i = 0; i < count; i++)
                    aux[i] = values[i];
                values[count] = value;
                count++;
            }
            else
            {
                values[count] = value;
                count++;
            }    
        }

        public int pop()
        {
            if (count == 0)
                throw new Exception("stack is empty");
            count--;
            return values[count];
        }

        public int peek()
        {
            if (count == 0) throw new Exception("the stack is empty");
            return values[count - 1];
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public void print()
        {
            for(int i = 0; i < count; i++)
                Console.Write(values[i] + " ");
            Console.WriteLine();
        }

    }
    public class twoInOneStack
    {
        private int[] array;
        private int count1 = 0, count2 = 0;
        private int bonusSize = 2;
        public twoInOneStack()
        {
            array = new int[2];
        }
        public void push1(int value)
        {
            if(count2 > array.Length - 1)
            {
                int[] aux = new int[array.Length + bonusSize];
                for (int i = 0; i < count1; i++)
                    aux[i] = array[i];
                aux[count1] = value;
                count1++;
                for (int i = count1; i <= count2; i++)
                    aux[i] = array[i-1];
                array = aux;
                count2++;
                return;
            }

            int[] aux1 = new int[array.Length];
            for (int i = 0; i < count1; i++)
                aux1[i] = array[i];

            aux1[count1] = value;
            count1++;

            for(int i = count1 ; i <= count2; i++)
            {
                aux1[i] = array[i-1];
            }
            array = aux1;
            count2++;
        }

        public void push2(int value)
        {
            if (count2 > array.Length - 1)
            {
                int[] aux = new int[array.Length + bonusSize];
                for (int i = 0; i < count2; i++)
                    aux[i] = array[i];
                array = aux;
                array[count2] = value;
                count2++;
                return;
            }
            array[count2] = value;
            count2++;
        }

        public int pop2()
        {
            if (count2 <= 0) throw new Exception("ures a 2 bro");
            count2--;
            int aux = array[count2];
            array[count2] = 0;
            return aux;
        }

        public int pop1()
        {
            if (count1 <= 0) throw new Exception("stack 1 is empty");

            int aux = array[count1 - 1];
            count1--;
            array[count1] = 0;
            for(int i = count1; i < count2 - 1; i++)
                array[i] = array[i+1];
            count2--;
            array[count2] = 0;
            return aux;
        }

        public bool isEmpty1() { return count1 == 0; }
        public bool isEmpty2() { return count2 == 0; }

    }

    public class minimStack
    {
        public myStack stack = new myStack();
        public myStack minStack = new myStack();

        public void push(int x) 
        { 
            stack.push(x);
            if (!minStack.isEmpty())
            {
                if (stack.peek() < minStack.peek())
                    minStack.push(x);
            }
            else
                minStack.push(x);
        }
        public void pop()
        {
            if (stack.peek() == minStack.peek())
            {
                stack.pop();
                minStack.pop();
            }
            else
                stack.pop();
        }

        public int min()
        {
            return minStack.pop();
        }
    }
    

    public class ArrayQueue
    {
        private int[] q = new int[10];
        private int F = 0, R = 0;
        public void enque(int item)
        {
            if (isFull())
            {
                throw new Exception("full");
            }
            else
            { 
                q[R] = item;
                R++;
            }
        }
        public int deque() 
        { 
            if(isEmpty()) 
            {
                throw new Exception("empty");
            }
            else
            {
                F++;
                return q[F-1];
            }
        }

        public bool isFull()
        {
            return (R == q.Length);
        }
        public bool isEmpty() { return F >= R; }
        public int peek() { return q[F]; }
    }
        public class PriorityQueue
        {
            private int end = 0;
            private int []items = new int[10];
            private int first = 0;
            public void enque(int item)
            {

                if (isEmpty())
                { 
                    items[0] = item; 
                    end++; 
                }
                else
                {
                    
                    int toInsertIndex = end;
                    for (int i = end - 1; i >= 0; i--)
                    {
                        if (item <= items[i])
                        {
                            items[i + 1] = items[i];
                            toInsertIndex = i;
                        }
                        else
                        { 
                            items[toInsertIndex] = item;
                            end++;
                            return; 
                        }
                    }
                    if (toInsertIndex == 0)
                        items[toInsertIndex] = item;
                    end++;
                }
            }
            public int deque()
            {
                if (isEmpty())
                    throw new Exception("empty");
                first++;
                return items[first - 1];
            }
            public bool isEmpty() { return end == first; }
            public bool isFull() { return end == items.Length;}
        }
        public class StackQueue
        {
            private Stack<int> queue = new Stack<int>();
            private Stack<int> auxStack = new Stack<int>();

            public void enque(int item)
            {
                while (queue.Count > 0) 
                { 
                    auxStack.Push(queue.Pop()); 
                }
                auxStack.Push(item);
                while(auxStack.Count > 0) 
                { 
                    queue.Push(auxStack.Pop()); 
                }
                
            }
            public int deque()
            {
                if (isEmpty())
                    throw new Exception("sorry de ures");
                return queue.Pop();

            }
            public int peek()
            {
                if (isEmpty())
                    throw new Exception("sorry de ures");
                return queue.Peek();
            }

            public bool isEmpty()
            {
                return queue.Count== 0 && auxStack.Count== 0;
            }
        }
    public class LinkedListQueue
    {
        LinkedList qlist = new();
        public void enqueue(int item)
        {
            qlist.addLast(item);
        }
        public int dequeue()
        {
            return qlist.removeFirst();
        }

        public int peek()
        {
            var x = qlist.removeFirst();
            qlist.addFirst(x);
            return x;
        }
        public int size() { return qlist.size(); }
        public bool isEmpty() { return qlist.size() == 0;  }
    }

    public class TwoQueueStack
    {
        Queue<int> q1 = new();
        Queue<int> q2 = new();
        private int count = 0;
        private int peekElement;
        public int size()
        {
            return count;
        }
        public void push(int value)
        {
            q1.Enqueue(value);
            count++;
            peekElement = value;
        }

        public int pop()
        {
            if (isEmpty())
                throw new Exception("empty");
            count--;
            int i1 = q1.Count;
            for(int i = 0;i < i1 - 1; i++)
            {
                q2.Enqueue(q1.Dequeue());
            }

            int toReturn = q1.Dequeue();
            int i2 = q2.Count;
            for (int i = 0; i < i2 - 1; i++)
                q1.Enqueue(q2.Dequeue());
            
            if(count != 0)
            {
                peekElement = q2.Dequeue();
                q1.Enqueue(peekElement);
            }    
            
            return toReturn;
        }
        public bool isEmpty()
        {
            return count == 0;
        }

        public int peek()
        {
            if (!isEmpty())
                return peekElement;
            else
                throw new Exception("Empty");
        }

    }*/
       public class Entry
        {
            public int key;
            public string value;
            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }
    public class MyHashTable
    {
        private LinkedList<Entry>[] list = new LinkedList<Entry>[5];
        public void put(int key, string value)
        {
            var index = hash(key);
            if (list[index] == null)
                list[index] = new LinkedList<Entry>();

            foreach(var item in list[index])
            {
                if (item.key == key)
                {
                    item.value = value;
                    return;
                }
            }
            var entry = new Entry(key, value);

            list[index].AddLast(entry);
        }
        private int hash(int key)
        {
            return key % list.Length;
        }
        public void remove(int key)
        {
            var index = hash(key);
            var bucket = list[index];
            if (bucket == null)
                throw new Exception("not valid");

            foreach (var entry in bucket)
            {
                if (entry.key == key)
                {
                    bucket.Remove(entry);
                    return;
                }
            }
            throw new Exception("IllegalState");
        }
        public string get(int key)
        {
            var index = hash(key);
            if (list[index] != null)
            foreach(Entry item in list[index])
                if(item.key == key)
                    return item.value;
            return null;
        }
    }
    public class HashMap
    {
        LinkedList<Entry>[] list = new LinkedList<Entry>[5];
        public void put(int key, string value)
        {
            var hash = key% list.Length;
            Entry x = new Entry(key, value);
            if (list[hash] != null)
            {
                for (int i = 0; i < 5; i++)
                    if (list[i] == null)
                        list[i].AddFirst(x);
            }
            else
                list[hash].AddLast(x);
        }
        public void remove(int key)
        { 
            var hash = key% list.Length;
            foreach(var item in list)
            {
                if(item != null)
                {
                    
                }
            }
        }
    }
    internal class Program
    {
        //public static bool paranthesis_balanced(string str)
        //{
        //    Stack<char> paranthesis = new();
        //    string para = "<>()[]{}";
        //    string closing = ">)]}";
        //    foreach (char ch in str)
        //    {
        //        if (para.Contains(ch))
        //        {
        //            paranthesis.Push(ch);
        //            if (closing.Contains(ch))
        //            {
        //                char top = paranthesis.Pop();
        //                if (paranthesis.Count == 0) return false;
        //                top = paranthesis.Pop();
        //                switch (top) 
        //                {
        //                    case '>': if (top != '<') return false; break; 
        //                    case ']': if (top != '[') return false; break;
        //                    case ')': if (top != '(') return false; break;
        //                    case '}': if (top != '{') return false; break;
        //                }
        //            }
        //        }
        //    }
        //    return paranthesis.Count == 0;
        //}
        //public static Queue<int> reverseQueue(Queue<int> q)
        //{
        //    Queue<int> reversedQueue = new Queue<int>();
        //    Stack<int> stack = new Stack<int>();
        //    while(q.Count > 0)
        //    {
        //        stack.Push(q.Dequeue());
        //    }
        //    while(stack.Count > 0)
        //        reversedQueue.Enqueue(stack.Pop());
        //    return reversedQueue;

        //}
        //public static void firstKinverter(Queue<int> queue, int k)
        //{
        //    Stack<int> stack = new Stack<int>();
        //    for (int i = 0; i < k; i++)
        //    {
        //        stack.Push(queue.Dequeue());
        //    }
        //    Queue<int> aux = new();
        //    for(int i = 0;i <k; i++)
        //        aux.Enqueue(stack.Pop());
        //    while(queue.Count> 0) { aux.Enqueue(queue.Dequeue()); }

        //    while(aux.Count > 0)
        //    {
        //        Console.Write(aux.Dequeue());
        //    }
        //}
        /*public static void firstNotRepeatedCharacter()
        {
            string str = "a green apple";
            Dictionary<char, int> dictionary = new();
            foreach (char ch in str)
                if (dictionary.ContainsKey(ch))
                    dictionary[ch]++;
                else
                    dictionary.Add(ch, 1);

            foreach (var item in dictionary)
                if (item.Value == 1)
                { Console.WriteLine(item.Key); return; }

            
        }
        public static void firstRepeatedCharacter()
        {
            string str = "a green apple";

            HashSet<char> set = new();
            foreach (char ch in str)
                if(set.Contains(ch))
                {
                    Console.WriteLine(ch);
                    return;
                }
                else
                set.Add(ch);

            Console.WriteLine("No repeated chars");
        }*/
        /*static void mostFrequentNrInArray(int[] v)
        {
            Dictionary<int, int> dict = new();
            foreach (int item in v)
            {
                if (!dict.ContainsKey(item))
                    dict.Add(item, 0);
                else
                    dict[item] = dict[item] + 1;
            }

            int maxValue = 0, maxKey = -1;
            foreach (var item in dict)
                if (item.Value > maxValue)
                {
                    maxKey = item.Key; 
                    maxValue = item.Value;
                }

            Console.WriteLine(maxKey);
        }
        static void uniquePairsKDif(int k, int[] v)
        {
            Dictionary<int, int> dict = new();
            foreach(var item in v)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict.Add(item, 0);
            }
            int count = 0;
            foreach(var item in dict)
            {
                if(dict.ContainsKey(item.Key + k))
                    count++;
            }
            Console.WriteLine(count);
        }
        public static void indicesHashTable(int target, int[] v)
        {
            Dictionary<int, int> dict = new();
            int index = 0;
            foreach (int item in v)
            {
                dict.Add(item, index); 
                ++index;
            }
            Dictionary<int, int> res = new();

            foreach(var item in dict)
            {
                findpair(item, ref dict, ref res, target);
            }

            foreach(var item in res)
                Console.WriteLine(item.Key + " " + item.Value);
        }

        private static void findpair(KeyValuePair<int,int> item,ref Dictionary<int, int> dict, ref Dictionary<int, int> res, int target)
        {
            foreach(var items in dict)
            {
                if(item.Key + items.Key == target)
                {
                    res.Add(item.Value, items.Value);
                    dict.Remove(item.Key);
                    dict.Remove(items.Key);
                    return;

                }
            }
        }
        */
        
        static void Main(string[] args)
        {

        }
    }
}