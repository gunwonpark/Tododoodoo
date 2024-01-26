using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool i;
    [Serializable]
    struct pool
    {
        public GameObject Prefab;
        public string tag;
        public int size;
    }
    [SerializeField]pool[] pools;
    Dictionary<string, Queue<GameObject>> myDic = new Dictionary<string, Queue<GameObject>>();
    private void Awake()
    {
        if (i == null)
        {
            i = this;
            for (int i = 0; i < pools.Length; i++)
            {
                Queue<GameObject> queue = new Queue<GameObject>();
                for (int p = 0; p < pools[i].size; p++)
                {
                    GameObject temp = Instantiate(pools[i].Prefab);
                    temp.SetActive(false);
                    queue.Enqueue(temp);
                }
                myDic.Add(pools[i].tag, queue);
            }
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject GetFromPool(string index)
    {
        GameObject go = null;
        if (!myDic.ContainsKey(index))
        {
            Debug.Log($"풀에 해당 {index}의 프리팹이 없음.");
            return null;
        }
        if (myDic[index].Peek().activeSelf)
        {//설정한 size의 갯수가 초과되면 동작
            go = Instantiate(myDic[index].Peek());
            go.name = myDic[index].Peek().name;
            myDic[index].Enqueue(go);
            return go;
        }
        go = myDic[index].Dequeue();
        myDic[index].Enqueue(go);
        go.SetActive(true);
        return go;
    }

    public void DestroyAll(string index)
    {
        if (!myDic.ContainsKey(index))
        {
            Debug.Log($"풀에 해당 {index}의 프리팹이 없음.");
        }
        foreach(GameObject go in myDic[index])
        {
            go.SetActive(false);
        }
    }
}
