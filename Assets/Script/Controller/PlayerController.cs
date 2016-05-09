using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    public GameObject m_CellList;
    public GameObject m_Text;
    public GameObject m_CurPlayer;
    public List<GameObject> m_PlayerList;
    private float m_StepLen = 0.1f;
    private const float m_MaxLen = 1.0f;
    private float m_PlayerStep = 1.0f; //贝塞尔曲线结束值
    private Vector3 m_BeginPos = new Vector3();//起始位置
    private Vector3 m_EndPos = new Vector3();//结束位置
    private Vector3 m_NowPos = new Vector3();//当前位置
    private int m_PlayerCellStep = 0;//当前所在的Cell Index
    private int m_PlayerCellCount= 0;//目的地的Cell Index
    private int m_RandomStep1 = 0;//第一个骰子随机的步数
    private int m_RandomStep2 = 0;//第二个骰子随机的步数
    private int m_RandomStepCount = 0;//骰子的总步数
    private int m_PlayerIndex = -1;//玩家的索引值
    public GameObject m_Camera;//主摄像机
    private Vector3 m_vecPosTemp = new Vector3();
    private Vector3 m_vecRotTemp = new Vector3();
    private const float m_CameraLen = 60.0f;


    private void ControlCamera()
    {
        int camera_range = m_PlayerCellStep / 10;
        Debug.Log("camera_range = " + camera_range);
        switch (camera_range)
        {
            case 0:
                m_vecPosTemp = m_Camera.transform.position;
                m_vecPosTemp.x = m_PlayerList[m_PlayerIndex].transform.position.x;
                m_vecPosTemp.z = m_PlayerList[m_PlayerIndex].transform.position.z - m_CameraLen * 2;
                m_Camera.transform.position = m_vecPosTemp;
                m_vecRotTemp = m_Camera.transform.localEulerAngles;
                if (m_vecRotTemp.y > 270.0f)
                {
                    Debug.Log("m_vecRotTemp = " + m_vecRotTemp);
                    float fRotTemp = m_vecPosTemp.x;
                    //m_vecRotTemp.x = 0.0f;
                    m_vecRotTemp.y = 0.0f;
                    //m_vecPosTemp.x = fRotTemp;
                    m_Camera.transform.localEulerAngles = m_vecRotTemp;
                }
                //Debug.Log("m_vecRotTemp = " + m_vecRotTemp);
                break;
            case 1:
                m_vecPosTemp = m_Camera.transform.position;
                m_vecPosTemp.x = m_PlayerList[m_PlayerIndex].transform.position.x - m_CameraLen * 2;
                m_vecPosTemp.z = m_PlayerList[m_PlayerIndex].transform.position.z;
                m_Camera.transform.position = m_vecPosTemp;
                m_vecRotTemp = m_Camera.transform.localEulerAngles;
                if(m_vecRotTemp.y < 90.0f)
                {
                    Debug.Log("m_vecRotTemp = " + m_vecRotTemp);
                    float fRotTemp = m_vecPosTemp.x;
                    //m_vecRotTemp.x = 0.0f;
                    m_vecRotTemp.y = 90.0f;
                    //m_vecPosTemp.x = fRotTemp;
                    m_Camera.transform.localEulerAngles = m_vecRotTemp;
                }
                break;
            case 2:
                m_vecPosTemp = m_Camera.transform.position;
                m_vecPosTemp.x = m_PlayerList[m_PlayerIndex].transform.position.x;
                m_vecPosTemp.z = m_PlayerList[m_PlayerIndex].transform.position.z + m_CameraLen * 2;
                m_Camera.transform.position = m_vecPosTemp;
                m_vecRotTemp = m_Camera.transform.localEulerAngles;
                if (m_vecRotTemp.y < 180.0f && m_vecRotTemp.y >= 90.0f)
                {
                    Debug.Log("m_vecRotTemp = " + m_vecRotTemp);
                    float fRotTemp = m_vecPosTemp.x;
                    //m_vecRotTemp.x = 0.0f;
                    m_vecRotTemp.y = 180.0f;
                    //m_vecPosTemp.x = fRotTemp;
                    m_Camera.transform.localEulerAngles = m_vecRotTemp;
                }
                break;
            case 3:
                m_vecPosTemp = m_Camera.transform.position;
                m_vecPosTemp.x = m_PlayerList[m_PlayerIndex].transform.position.x + m_CameraLen * 2;
                m_vecPosTemp.z = m_PlayerList[m_PlayerIndex].transform.position.z ;
                m_Camera.transform.position = m_vecPosTemp;
                m_vecRotTemp = m_Camera.transform.localEulerAngles;
                if (m_vecRotTemp.y < 270.0f && m_vecRotTemp.y >= 180.0f)
                {
                    Debug.Log("m_vecRotTemp = " + m_vecRotTemp);
                    float fRotTemp = m_vecPosTemp.x;
                    //m_vecRotTemp.x = 0.0f;
                    m_vecRotTemp.y = 270.0f;
                    //m_vecPosTemp.x = fRotTemp;
                    m_Camera.transform.localEulerAngles = m_vecRotTemp;
                }
                break;

        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMove(); 
	}

    void UpdateMove()
    {
       if(m_RandomStepCount > 0)//随机数已经产生
        {
            if(m_PlayerStep > 1.0f)//当前cell已经移动完成
            {
                m_PlayerStep = 0.0f;
                m_RandomStepCount--;
                m_PlayerCellStep++;
                m_PlayerCellStep = MaxStep(m_PlayerCellStep);
                m_BeginPos = m_PlayerList[m_PlayerIndex].transform.position;
                m_EndPos = m_CellList.GetComponent<Cell>().GetCellPos(m_PlayerCellStep);
                //ControlCamera();
            }
            else//当前cell还没有移动完成
            {
                m_PlayerList[m_PlayerIndex].transform.position = MyMath.GetInstance().GetPtPath(m_BeginPos, m_EndPos, m_PlayerStep);
                m_PlayerStep += m_StepLen;
                //m_NowPos = MyMath.GetInstance().GetPtPath()
            }
        }
       else
        {
            PlayerDataManager.GetInstance().SetRandomOpen(true);
        }
    }

    private int MaxStep(int mstep)
    {
        //Debug.Log("Begin mstep = " + mstep);
        if (mstep >= 40 || mstep  <= 0)
        {
            mstep = Mathf.Abs(mstep - 40);
        }
        Debug.Log("End mstep = " + mstep);
        return mstep;
    }

    public void RandomStep()
    {
        ReadSqlite();
        PlayerDataManager.GetInstance().SetRandomOpen(false);
        MovePlayer(0);
        m_PlayerStep = 0.0f;
        m_RandomStep1 = UnityEngine.Random.Range(1, 7);
        m_RandomStep2 = UnityEngine.Random.Range(1, 7);
        PlayerDataManager.GetInstance().SetDiceNumber(m_RandomStep1, m_RandomStep2);
        m_RandomStepCount = m_RandomStep1 + m_RandomStep2;
        m_PlayerCellCount = m_PlayerCellCount + m_RandomStepCount;
        m_PlayerCellStep++;
        m_PlayerCellCount = MaxStep(m_PlayerCellCount);
        m_EndPos = m_CellList.GetComponent<Cell>().GetCellPos(m_PlayerCellStep); 
        //m_PlayerCellCount = m_PlayerCellCount + m_RandomStep;
        m_Text.GetComponent<Text>().text = "m_RandomStep is = " + Convert.ToString(m_RandomStepCount);
        
        //MovePlayer(0);
    }

    public void MovePlayer(int playerIndex)
    {
        for(int i = 0; i < m_PlayerList.Count; i++)
        {
            if(playerIndex == i)
            {
                m_PlayerIndex = playerIndex;
                m_BeginPos = m_PlayerList[i].transform.position;

                
                //MyMath.GetInstance
            }
        }
    }

    //test local db interface
    public void ReadSqlite()
    {
        MyApp.GetInstance().GetDataManager().GetEventItem(1);
    }


}
