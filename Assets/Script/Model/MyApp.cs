using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyApp
{
    public const float TIME_SCALE_DEFAULT = 1.0f;
    public float current_timeScale = 1.0f;
    public static MyApp myApp;
    private static SQLiteDataManager dataManager;
    /// <summary>
    /// playerDataManager、cardDataManger等是与具体玩家相关的数据的管理器，在登录之后被初始化，在退出或重新登录的时候被清空
    /// </summary>
    public PlayerDataManager playerDataManager;
    public string userName;
    public string pwd;
    public string deviceID;

    public static MyApp GetInstance()
    {
        if (myApp == null)
        {
            myApp = new MyApp();
            dataManager = new SQLiteDataManager(Application.persistentDataPath + "/rich.sqlite");
        }
        return myApp;
    }

    /// <summary>
    /// 在登录之后，根据服务器端返回的消息初始化与具体玩家相关的一些数据。
    /// </summary>
    /// <param name="data4Player">Data4 player.</param>
    /// <param name="sceneSwitch">Scene switch.</param>
    //		public void InitData4Player (PlayerInfoWhenLogin data4Player, SceneSwitch sceneSwitch)
    //		{
    //				//playerDataManager初始化的方式还有问题，应该直接在这里new，当前写法是为了兼容旧代码
    //				//playerDataManager = PlayerDataManager.GetInstance ();
    //
    //
    //			
    //				//sceneSwitch.toHome ();
    //		}

    public void ClearData4Player()
    {
        playerDataManager = null;
    }

    public SQLiteDataManager GetDataManager()
    {
        return dataManager;
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
