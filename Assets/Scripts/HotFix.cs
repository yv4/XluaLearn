using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

public class HotFix : MonoBehaviour
{
    public SpawnUI SpawnUI;
    private LuaEnv luaEnv;
    private string luascriptsFold = "LuaScripts/Game";

    // Start is called before the first frame update\
    private void Awake()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(LoadHotFixCorotine());
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(MyLoader);
            luaEnv.DoString("require(\"Main\")");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            SpawnUI.SpawnObj();
        }    
    }

    private byte[] MyLoader(ref string filePath)
    {
        string scriptPath = string.Empty;
        filePath = filePath.Replace(".", "/") + ".lua";
#if UNITY_EDITOR
        scriptPath = Path.Combine(Application.dataPath, luascriptsFold);
        scriptPath = Path.Combine(scriptPath, filePath);
        byte[] data = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(scriptPath));
        return data;
#endif
        return null;
    }

    private void OnDisable()
    {
        luaEnv.DoString("require(\"MainDispose\")");

    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }

    IEnumerator LoadHotFixCorotine()
    {
        Debug.Log("LoadHotFixCorotine");
        string scriptPath = Path.Combine(Application.dataPath, luascriptsFold);
        UnityWebRequest request = UnityWebRequest.Get(@"file:///D:\UnityLearn/XluaLern\XLuaTest/XluaLearn\HotFix/Main.lua");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        Debug.Log("Read HotFix:" + str);
        scriptPath = Path.Combine(scriptPath, "Main.lua");
        File.WriteAllText(scriptPath,str);
        Debug.Log("LoadHotFixCorotineFinish");
        StartCoroutine(LoadHotFixDisposeCorotine());
    }

    IEnumerator LoadHotFixDisposeCorotine()
    {
        Debug.Log("LoadHotFixDisposeCorotine");
        string scriptPath = Path.Combine(Application.dataPath, luascriptsFold);
        UnityWebRequest request = UnityWebRequest.Get(@"file:///D:\UnityLearn/XluaLern\XLuaTest/XluaLearn\HotFix/MainDispose.lua");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        Debug.Log("Read HotFix:" + str);
        scriptPath = Path.Combine(scriptPath, "MainDispose.lua");
        File.WriteAllText(scriptPath, str);
        Debug.Log("LoadHotFixDisposeCorotineFinish");
    

    }
}
