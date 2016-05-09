using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SQLiteDataInit : MonoBehaviour
{
    public string fromFileName;
    public string toFileName;
    private string fromFilePath;
    private string persistentFilePath;

    void Awake()
    {
        InitSQLiteData();
    }

    // Use this for initialization
    void Start()
    {
        //MyApp.GetInstance().GetDataManager().initDbData();
        //MyApp.GetInstance().GetDataManager().GetEventItem(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitSQLiteData()
    {
        Debug.Log("-------------InitSQLiteData----------------------");
        // a product persistant database path.
        persistentFilePath = Application.persistentDataPath + "/" + toFileName;
        Debug.Log("InitSQLiteData persistentFilePath = " + persistentFilePath);
        if (File.Exists(persistentFilePath))
        {
            Debug.Log("Delete last local db");
            File.Delete(persistentFilePath);
        }
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        fromFilePath = "file://" + Application.streamingAssetsPath + "/" + fromFileName;
        StartCoroutine("CopyFile");
#elif UNITY_WEBPLAYER
						fromFilePath = "StreamingAssets/" + fromFileName;
						StartCoroutine ("CopyFile");
#elif UNITY_IPHONE
						fromFilePath = Application.dataPath + "/Raw/" + fromFileName;
						CopyFile2IPhone ();
#elif UNITY_ANDROID
						fromFilePath = Application.streamingAssetsPath + "/" + fromFileName;
						StartCoroutine ("CopyFile");
#endif
    }

    void CopyFile2IPhone()
    {
        UnityEngine.Debug.Log("persistentFilePath:" + persistentFilePath);
        using (FileStream fs = new FileStream(fromFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);
            File.WriteAllBytes(persistentFilePath, bytes);
        }
        UnityEngine.Debug.Log("file copy done");
    }

    IEnumerator CopyFile()
    {
        UnityEngine.Debug.Log("persistentFilePath:" + persistentFilePath);
        WWW www1 = new WWW(fromFilePath);
        yield return www1;
        try
        {
            File.WriteAllBytes(persistentFilePath, www1.bytes);
        }
        catch (Exception e)
        {
            Debug.Log("Error = " + e.ToString());
        }


    }

}
