using System;
using System.Collections.Generic;

namespace WallyMapSpinzor2;

/// <summary>
/// A bucket-based priority queue. Used to handle drawing order.
/// </summary>
/// <typeparam name="T">The type of elements in the collection</typeparam>
public sealed class BucketPriorityQueue<T>
{
    private int _count;

    public int Count => _count;
    public Queue<T>[] Buckets { get; private set; }
    public int MinBucket { get; private set; }
    public int MaxBucket { get; private set; }

    public BucketPriorityQueue(int bucketCount)
    {
        _count = 0;
        Buckets = new Queue<T>[bucketCount]; for (int i = 0; i < bucketCount; ++i) Buckets[i] = new();
        MinBucket = bucketCount; MaxBucket = -1;
    }

    public void Push(T element, int priority)
    {
        if (priority < 0) throw new IndexOutOfRangeException($"Priority {priority} is negative");
        if (priority >= Buckets.Length) throw new IndexOutOfRangeException($"Priority {priority} is bigger than bucket count {Buckets.Length}");

        if (priority < MinBucket) MinBucket = priority;
        if (priority > MaxBucket) MaxBucket = priority;

        Buckets[priority].Enqueue(element);
        _count++;
    }

    private void UpdateMinBucket()
    {
        while (MinBucket < Buckets.Length && Buckets[MinBucket].Count == 0) MinBucket++;
    }

    public T PopMin()
    {
        UpdateMinBucket();
        if (MinBucket >= Buckets.Length) throw new IndexOutOfRangeException("Attempt to pop min from empty bucket queue");
        _count--;
        return Buckets[MinBucket].Dequeue();
    }

    private void UpdateMaxBucket()
    {
        while (MaxBucket >= 0 && Buckets[MaxBucket].Count == 0) MaxBucket--;
    }

    public T PopMax()
    {
        UpdateMaxBucket();
        if (MaxBucket < 0) throw new IndexOutOfRangeException("Attempt to pop max from empty bucket queue");
        _count--;
        return Buckets[MaxBucket].Dequeue();
    }
}