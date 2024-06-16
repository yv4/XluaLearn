 using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XLuaManager : MonoSingleton<XLuaManager>
{
    private bool isGameStarted = false;
    private LuaEnv env = null;
    private string luascriptsFold = "LuaScripts/Game";
    protected override void Awake()
    {
        base.Awake();
        this.InitLuaEnv();
    }

    public byte[] LuaScriptLoader(ref string filepath)
    {
        string scriptPath = string.Empty;
        filepath = filepath.Replace(".", "/") + ".lua";
#if UNITY_EDITOR
        scriptPath = Path.Combine(Application.dataPath, luascriptsFold);
        scriptPath = Path.Combine(scriptPath, filepath);

        byte[] data = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(scriptPath));
       
        return data;
#endif
        return null;
    }


    private void InitLuaEnv()
    {
        this.env = new LuaEnv();
        this.env.AddLoader(this.LuaScriptLoader);
        this.isGameStarted = false;
    }

    public void EnterGame()
    {
        this.isGameStarted = true;
        //进入游戏逻辑 跑lua代码
        this.env.DoString("require(\"Main\")");
        this.env.DoString("main.init()");
    }

    public void Update()
    {
        if(this.isGameStarted)
        {
            this.env.DoString("main.update()");
        }
    }

    public void FixedUpdate()
    {
        if (this.isGameStarted)
        {
            this.env.DoString("main.fixedUpdate()");
        }
    }

}