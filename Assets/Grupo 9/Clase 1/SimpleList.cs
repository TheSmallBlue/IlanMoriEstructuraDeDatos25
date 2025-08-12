using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleList<T> : ISimpleList<T>, IEnumerable<T>
{
    T[] _dataArray;

    int _minArraySize = 5;
    int _arrayBufferSize = 2;

    // ---

    public SimpleList()
    {
        _dataArray = new T[_minArraySize];
    }

    public T this[int index] { get => GetIndex(index); set => SetIndex(index, value); }

    public int Count => GetFirstEmptyIndex();

    public void Add(T item)
    {
        int emptyIndex = GetFirstEmptyIndex();

        if( emptyIndex == -1 || emptyIndex > _dataArray.Length - _arrayBufferSize)
        {
            _dataArray = CloneArrayWithNewSize(_dataArray.Length + _arrayBufferSize);
        }

        _dataArray[emptyIndex] = item;
    }

    public void AddRange(T[] collection)
    {
        if(GetFirstEmptyIndex() + collection.Length > _dataArray.Length - _minArraySize)
        {
            _dataArray = CloneArrayWithNewSize(_dataArray.Length + collection.Length);
        }

        int emptyIndex = GetFirstEmptyIndex();
        for (int i = 0; i < collection.Length; i++)
        {
            _dataArray[emptyIndex + i] = collection[i];
        }
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < _dataArray.Length; i++)
        {
            T itemAtIndex = _dataArray[i];

            if(itemAtIndex != null && itemAtIndex.Equals(item))
            {
                _dataArray = ShiftArrayAtIndex(i, -1);
                return true; // Se pudo encontrar y se borr�
            }
        }

        return false; // No se pudo encontrar
    }

    

    public void Clear()
    {
        _dataArray = new T[_minArraySize];
    }

    // ---

    T[] CloneArrayWithNewSize(int desiredSize)
    {
        if (desiredSize < _dataArray.Length) throw new System.Exception("Cant make array smaller!");

        T[] newArray = new T[desiredSize];
        _dataArray.CopyTo(newArray, 0);

        return newArray;
    }

    T[] ShiftArrayAtIndex(int index, int times)
    {

        if (index < 0 || index >= _dataArray.Length) throw new System.Exception("Invalid index while shifting array!!");
        if (index + times + 1 < 0 || index + times + 1 > _dataArray.Length) throw new System.Exception("You cant shift that many spaces!!");

        T[] iterationArray = _dataArray.Clone() as T[];
        T[] output = _dataArray.Clone() as T[];
        for (int i = index + 1; i < iterationArray.Length; i++)
        {
            output[i + times] = iterationArray[i];
            output[i] = default(T);
        }

        return output;
    }

    // ---

    int GetFirstEmptyIndex()
    {
        for (int i = 0; i < _dataArray.Length; i++)
        {

            if (_dataArray[i] == null) return i;
        }

        return -1;
    }

    // ---

    T GetIndex(int index)
    {
        if (!IsIndexValid(index)) throw new System.Exception("Index is invalid!!");

        return _dataArray[index];
    }

    void SetIndex(int index, T value)
    {
        if (!IsIndexValid(index)) throw new System.Exception("Index is invalid!!");

        _dataArray[index] = value;
    }

    bool IsIndexValid(int index)
    {
        if (index > _dataArray.Length - _arrayBufferSize) return false;
        if (index < 0) return false;

        return true;
    }

    // ---

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return _dataArray[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
