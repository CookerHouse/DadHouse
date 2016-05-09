using UnityEngine;
using System.Collections;
using ConfigConst;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToStart()
    {
        SetUIInfo(GameUIConfig.Start);
    }

    public void ToLobby()
    {
        SetUIInfo(GameUIConfig.Lobby);
    }

    private void SetUIInfo(int toUI)
    {
        SceneManager.LoadScene(GetSceneNameById(toUI));
    }
    
    string GetSceneNameById(int id)
    {
        string result = "start";
        switch(id)
        {
            case GameUIConfig.Start:
                result = "start";
                break;
            case GameUIConfig.Lobby:
                result = "rich2";
                break;
        }
        return result;
    }
}
