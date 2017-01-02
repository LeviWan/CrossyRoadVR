using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool instance;
    private static Dictionary<string, List<GameObject>> objectPool = new Dictionary<string, List<GameObject>>();
    void Awake()
    {
        instance = this;
    }

    public Object GetInObjectPool(string prefabName, Vector3 position, Quaternion quaternion)
    {
        string key = prefabName + "(Clone)";

        Object obj;
        if (objectPool.ContainsKey(key) && objectPool[key].Count > 0 )
        {
            List<GameObject> list=objectPool[key];
            obj = list[0] as Object;
            list.RemoveAt(0);
            //重新初始化相关状态
       
            (obj as GameObject).transform.position = position;
            (obj as GameObject).transform.rotation = quaternion;
            (obj as GameObject).SetActive(true);
        }
        else
        {
            obj = Instantiate(Resources.Load("Prefabs/"+prefabName), position, quaternion);
        }
        return obj;
    }
	void Update () {

	
	}

    public Object SaveInPool(GameObject go)
    {
        string key = go.gameObject.name;
        if (!objectPool.ContainsKey(key))
        {
            objectPool[key] = new List<GameObject>() {go };
        }
        else
        {
            objectPool[key].Add(go);
        }
        go.gameObject.SetActive(false);
        return go;
    }
}
