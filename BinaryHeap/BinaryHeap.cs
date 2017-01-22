using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BinaryHeap<T> where T : IMax
    {
        private HeapNode<T>[] _nodes;
        private int _capacity;
        private int _currentPos;
        private IComparer<T> _comparer;

        public int Capacity
        {
            get
            {
                return _capacity;
            }

            set
            {
                _capacity = value;
            }
        }

        public HeapNode<T>[] Nodes
        {
            get
            {
                return _nodes;
            }

            set
            {
                _nodes = value;
            }
        }

        public IComparer<T> Comparer
        {
            get
            {
                return _comparer;
            }

            private set
            {
                _comparer = value;
            }
        }

        public BinaryHeap(int capacity, IComparer<T> comparer)
        {
            Nodes = new HeapNode<T>[capacity];
            Capacity = capacity;
            _currentPos = 0;
            Comparer = comparer;
        }

        private void Swap(int x, int y)
        {
            HeapNode<T> tmp = Nodes[x];

            Nodes[x] = Nodes[y];
            Nodes[x].Idx = x;

            Nodes[y] = tmp;
            Nodes[y].Idx = y;
        }

        public HeapNode<T> Insert(T item, string prop)
        {
            // Add the element to the bottom level of the heap
            Nodes[_currentPos] = new HeapNode<T>(item, prop);
            Nodes[_currentPos].Idx = _currentPos;

            HeapifyUp(_currentPos);

            _currentPos++;

            return Nodes[_currentPos];
        }

        private void HeapifyUp(int idx)
        {
            int parent = (idx - 1) / 2;

            // Compare the added element with its parent
            while (idx > 0 && Comparer.Compare(Nodes[idx].Data, Nodes[parent].Data) > 0)
            {
                // not in the correct order
                Swap(idx, parent);
                idx = parent;
                parent = (idx - 1) / 2;
            }            
        }

        public T Pop()
        {
            HeapNode<T> root = Nodes[0];

            // Replace the root of the heap with the last element on the last level
            Swap(0, --_currentPos);
            Nodes[_currentPos] = null;

            HeapifyDown(0);

            return root.Data;
        }

        public T RemoveAt(int idx)
        {
            HeapNode<T> root = Nodes[idx];
            root.SetMax();

            HeapifyUp(idx);

            return Pop();
        }

        private void HeapifyDown(int idx)
        {
            while (idx < _currentPos)
            {
                int left = idx * 2 + 1;
                int right = left + 1;

                // if no right child
                if (right > _currentPos)
                {
                    break;
                }
                
                // find bigger child
                int largestChild = left;
                if (Comparer.Compare(Nodes[right].Data, Nodes[left].Data) > 0)
                {
                    largestChild = right;
                }

                // compare bigger child with parent
                if (Comparer.Compare(Nodes[largestChild].Data, Nodes[idx].Data) > 0)
                {
                    Swap(largestChild, idx);
                    idx = largestChild;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
