using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] T prefab;
    [SerializeField] int startSize;

    private Queue<T> queue = new Queue<T>();

    public virtual void Awake()
    {
        for (int i = 0; i < startSize; i++)
        {
            CreateNewPoolObject();
        }
    }

    public abstract void EnqueueSettings(T pooledObject);
    public abstract void DequeueSettings(T pooledObject);

    public T Dequeue()
    {
        if (queue.Count < 0)
        {
            CreateNewPoolObject();

            return Dequeue();
        }

        T pooledObject = queue.Dequeue();
        DequeueSettings(pooledObject);

        return pooledObject;
    }

    public void Enqueue(T pooledObject)
    {
        EnqueueSettings(pooledObject);

        queue.Enqueue(pooledObject);
    }

    private void CreateNewPoolObject()
    {
        T pooledObject = Instantiate(prefab);

        Enqueue(pooledObject);
    }
}
