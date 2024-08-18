using System.Collections.Generic;
using UnityEngine;

public class GameObjectMonoPool<T> where T : MonoBehaviour
{
    private T _object;
    private List<T> _freePool = new List<T>();
    private List<T> _busyPool = new List<T>();

    private int _poolSize;

    private MonoFactory<T> _factory;

    public IReadOnlyList<T> FreePool => _freePool;
    public IReadOnlyList<T> BusyPool => _busyPool;
    public IReadOnlyList<T> Pool
    {
        get
        {
            List<T> list = new List<T>();

            list.AddRange(_freePool);
            list.AddRange(_busyPool);

            return list;
        }
    }

    public int PoolSize => _poolSize;

    public GameObjectMonoPool(T poolableObject, Transform parent, int poolSize)
    {
        _object = poolableObject;
        _poolSize = poolSize;
        _factory = new MonoFactory<T>(poolableObject, parent);

        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            T newObject = _factory.Create();
            _freePool.Add(newObject);
            newObject.gameObject.SetActive(false);

            newObject.name += $"_{i}";
        }
    }

    public T Pop()
    {
        if (_freePool.Count == 0)
        {
            ReturnToPool();
        }

        T popedObject = _freePool[0];
        _freePool.Remove(popedObject);
        _busyPool.Add(popedObject);

        popedObject.gameObject.SetActive(true);

        return popedObject;
    }

    public void ForceReturnToPool(T target) 
    {
        if (target == null)
        {
            Debug.LogError($"Critical error -> {nameof(target)} is null");
            return;
        }

        if (_busyPool.Count == 0)
        {
            return;
        }

        if (_busyPool.Contains(target) == false)
        {
            return;
        }

        _busyPool.Remove(target);
        _freePool.Add(target);

        target.gameObject.SetActive(false);
    }

    public void ForceReturnAllToPool()
    {
        T[] busyCopy = _busyPool.ToArray();

        foreach (T busyObject in busyCopy)
        {
            ForceReturnToPool(busyObject);
        }
    }

    private void ReturnToPool()
    {
        if (_busyPool.Count == 0)
        {
            return;
        }

        for (int i = 0; i < _poolSize; i++)
        {
            T popedFromBusy = null;

            try
            {
                popedFromBusy = _busyPool[0];
            } catch { }
            

            if (popedFromBusy == null)
            {
                return;
            }

            _freePool.Add(popedFromBusy);
            _busyPool.Remove(popedFromBusy);

            popedFromBusy.transform.SetParent(null);
            popedFromBusy.transform.position = Vector3.zero;
            popedFromBusy.gameObject.SetActive(false);
        }
    }
}