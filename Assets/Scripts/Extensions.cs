using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static GameObject RecursiveFind(this Transform parent, string name)
    {

        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(parent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == name)
                return c.gameObject;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }

    public static GameObject RecursiveFindByTag(this Transform parent, string tag)
    {

        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(parent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.tag == tag)
                return c.gameObject;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }
}