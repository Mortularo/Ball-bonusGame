using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MF
{
    public class ListExecutiveObjectsController : IEnumerable, IEnumerator
    {
        private int _index = -1;
        private IExecute[] _interactiveObject;
        public int Length => _interactiveObject.Length;
        public object Current => _interactiveObject[_index];
         
        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }

        public ListExecutiveObjectsController(Additions[] adds)
        {
            for (int i = 0; i < adds.Length; i++)
            {
                if (adds[i] is IExecute intObject)
                {
                    AddExecutiveObject(intObject);
                }
            }
        }

        public void AddExecutiveObject(IExecute execute)
        {
            if(_interactiveObject == null)
            {
                _interactiveObject = new[] {execute};
                return;    
            }
            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;
        }
        public bool MoveNext()
        {
            if (_index == Length - 1)
            {
                return false;
            }
            _index++;
            return true;
        }
        public void Reset()
        {
            _index = -1;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}

