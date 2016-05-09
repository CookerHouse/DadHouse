using UnityEngine;
using System.Collections;

public class PlayerDataManager{

    private static PlayerDataManager m_PlayerData = null;
    private int m_Step { set; get; }
    private int m_MyStep { set; get; }

    private bool m_bOpenRandomDice { set; get; }

    private int m_Dice1 { set; get; }

    private int m_Dice2 { set; get; }

    const int MAXSTEP = 40;

    public GameObject m_Money;

    public static PlayerDataManager GetInstance()
    {
        if(m_PlayerData == null)
        {
            m_PlayerData = new PlayerDataManager();
        }
        return m_PlayerData;
    }

    public void SetStep(int step)
    {
        m_Step = step;
    }

    public int GetStep()
    {
        return m_Step;
    }

    public bool GetRandomOpen()
    {
        return m_bOpenRandomDice;
    }

    public void SetRandomOpen(bool open)
    {
        m_bOpenRandomDice = open;
    }

    public void SetDiceNumber(int dice1, int dice2)
    {
        m_Dice1 = dice1;
        m_Dice2 = dice2;
    }

    public int GetDice1()
    {
        return m_Dice1;
    }

    public int GetDice2()
    {
        return m_Dice2;
    }
}
