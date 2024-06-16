using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLaunch : PrefabSingleton<GameLaunch>
{
    private void Awake()
    {
        this.gameObject.AddComponent<XLuaManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(this.GameStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CheckHotUpdate()
    {
        yield return null;
    }

    private IEnumerator GameStart()
    {
        yield return this.StartCoroutine(this.CheckHotUpdate());
        //进入游戏 lua虚拟机 进入lua的逻辑
        //需要添加自定义lua代码装载器  
        XLuaManager.Instance.EnterGame();
    }


}
