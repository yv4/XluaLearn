using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
public class SpawnUI : MonoBehaviour
{
    public GameObject UIPrefab;
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnObj();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [LuaCallCSharp]
    public void SpawnObj()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject uiPrefab = GameObject.Instantiate(UIPrefab);
            uiPrefab.transform.SetParent(Canvas.transform);
            uiPrefab.transform.localPosition = new Vector3(i * 50,0,0);
            uiPrefab.transform.localScale = Vector3.one;

        }
    } 
}
