using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour {
    public List<GameObject> m_CellList = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetCellObj(int index)
    {
        for(int i = 0; i < m_CellList.Count; i++)
        {
            if(i == index)
            {
                return m_CellList[i];
            }
        }

        return null;
    }

    public Vector3 GetCellPos(int index)
    {
        for (int i = 0; i < m_CellList.Count; i++)
        {
            if (i == index)
            {
                return m_CellList[i].transform.position;
            }
        }
        Debug.Log("index = " + index);
        return new Vector3(-10000,-10000,-10000);
    }
}
