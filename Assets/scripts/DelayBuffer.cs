using UnityEngine;
using System.Collections.Generic;

public class DelayBuffer<T>
{
    List<T> list = new List<T>();
    int capacity;

    public DelayBuffer(int capacity)
    {
        this.capacity = capacity;
    }

    public void Add(T value)
    {
        list.Add(value);
        if (list.Count > capacity)
        {
            list.RemoveAt(0);
        }
    }

    public bool HasEnoughCount()
    {
        return list.Count == capacity;
    }

    public T Get()
    {
        Debug.Assert(list.Count == capacity);
        return list[0];
    }
}