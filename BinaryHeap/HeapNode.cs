using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public interface IMax
    {
        void SetToMax();
    }

    public class HeapNode<T> where T : IMax
    {
        private T _data;
        private int _idx;
        private string _property;

        public T Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public int Idx
        {
            get
            {
                return _idx;
            }

            set
            {
                _idx = value;
            }
        }

        public string Property
        {
            get
            {
                return _property;
            }

            set
            {
                _property = value;
            }
        }

        public void SetMax()
        {
            Data.SetToMax();
        }

        public HeapNode(T data, string property)
        {
            Idx = -1;
            Data = data;
            Property = property;

            //Data.PropertyChanged += Data_PropertyChanged;
        }

        private void Data_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == Property)
            {

            }
        }

        public override string ToString()
        {
            return $"{Data}";
        }
    }
}
