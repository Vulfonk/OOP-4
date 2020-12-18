using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class VectorCCircle<Shape>
    {
        private Shape[] _shapes;    
        private uint _size;
        private uint _k;

        public VectorCCircle()
        {

        }
        public VectorCCircle(uint size)
        {
            _k = 0;
            _size = size;
            _shapes = new Shape[_size];
            for (int i = 0; i < size; i++)
            {
                _shapes[i] = default(Shape);
            
            }
        }
        public void resize(uint newSize)
        {
            Shape[] _shapes1 = new Shape[newSize];
            uint size = _size < newSize ? _size : newSize;
            for (int i = 0; i < size; i++)
            {
                _shapes1[i] = _shapes[i];
            }
            _shapes = _shapes1;
            _size = newSize;
        }
        public Shape this[int i]
        {
            set
            {
                if ((i < 0) || (i > _size))
                {

                }
                else
                {

                    if (_shapes[i] == null)
                    {
                        _k++;
                    }
                    _shapes[i] = value;
                }
            }
            get
            {
                if ((i < 0) || (i > _size))
                {
                    return default(Shape);
                }
                else
                {
                    return _shapes[i];
                }
            }
        }
        public void delCShape(uint i)
        {
            if (_shapes[i] != null)
            {
                _k--;
            }
            _shapes[i] = default(Shape);
        }
        public uint size()
        {
            return _size;
        }
        public uint getK()
        {
            return _k;
        }
        public VectorCCircle(VectorCCircle<Shape> a)
        {
            _k = a._k;
            _size = a._size;
            for (int i = 0; i < _size; i++)
            {
                _shapes[i] = a._shapes[i];
            }
        }
        ~VectorCCircle()
        {
            for (int i = 0; i < _size; i++)
            {

                _shapes[i] = default(Shape);
            }
        }
    }
}
