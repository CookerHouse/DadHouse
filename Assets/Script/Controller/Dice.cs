using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dice : MonoBehaviour {
    public GameObject m_Dice1;
    public GameObject m_Dice2;
    public Sprite[] images;
    private Vector3 m_temp;
    public Vector3 m_speed;
    // Use this for initialization
    void Start () {
        m_temp = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerDataManager.GetInstance().GetRandomOpen())
        {
            int random1 = Random.Range(1, 7);
            int random2 = Random.Range(1, 7);
            RandomUpdateDiceTexture(random1, random2);
        }
        else
        {
            RandomUpdateDiceTexture(PlayerDataManager.GetInstance().GetDice1(), PlayerDataManager.GetInstance().GetDice2());
        }

        // UpdateSpeed();
    }

    public void MakeDice(int dice1, int dice2)
    {

    }

    public void UpdateDiceTexture(int dice1, int dice2)
    {
    }

    private void UpdateSpeed()
    {
        m_temp = m_Dice1.transform.position;
        m_temp.y -= m_speed.y;
        m_temp.x -= m_speed.x;
        m_temp.z -= m_speed.z;
        m_Dice1.transform.position = m_temp;
        m_temp = m_Dice2.transform.position;
        m_temp.y -= m_speed.y;
        m_temp.x -= m_speed.x;
        m_temp.z -= m_speed.z;
        m_Dice2.transform.position = m_temp;
    }

    public void RandomUpdateDiceTexture(int random1, int random2)
    {
       
        //m_Dice1.GetComponent<Image>().sprite = 
        //Debug.Log("m_Dice1.GetComponent<Image>().name = " + m_Dice1.GetComponent<Image>().name);
        if(random1 - 1 >= 0 && random2 - 1 >= 0)
        {
            m_Dice1.GetComponent<Image>().sprite = images[random1 - 1];
            m_Dice2.GetComponent<Image>().sprite = images[random2 - 1];
        }
        
    }
}
