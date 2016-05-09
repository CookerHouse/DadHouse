using UnityEngine;
using System.Collections;

public class EventManager{
    private static EventManager m_EventData = null;
    private TreasureList m_TreasureList = new TreasureList();
    private EventList m_EventList = new EventList();

    public static EventManager GetInstance()
    {
        if (m_EventData == null)
        {
            m_EventData = new EventManager();
        }
        return m_EventData;
    }


    public void AddEvent(int Type, string Event,int Money,int Prison, int Step, int Begin, int Sell, int Buy, int Round)
    {
        DBEvent dbevent = new DBEvent();
        dbevent.Id = -1;
        dbevent.Type = Type;
        dbevent.Event = Event;
        dbevent.Money = Money;
        dbevent.Prison = Prison;
        dbevent.Step = Step;
        dbevent.Begin = Begin;
        dbevent.Sell = Sell;
        dbevent.Buy = Buy;
        dbevent.Round = Round;
        m_EventList.AddEvent(dbevent);
    }

    public void AddTreasure(int Type, string Event, int Money, int Prison, int Step, int Begin, int Sell, int Buy, int Round)
    {
        DBTreasure dbtreasure = new DBTreasure();
        dbtreasure.Id = -1;
        dbtreasure.Type = Type;
        dbtreasure.Event = Event;
        dbtreasure.Money = Money;
        dbtreasure.Prison = Prison;
        dbtreasure.Step = Step;
        dbtreasure.Begin = Begin;
        dbtreasure.Sell = Sell;
        dbtreasure.Buy = Buy;
        dbtreasure.Round = Round;
        m_TreasureList.AddTreasure(dbtreasure);
    }

    public DBEvent GetRandomEvent()
    {
        int randomindex = UnityEngine.Random.Range(0, m_EventList.GetEventList().Count);
        return m_EventList.GetEventList()[randomindex];
    }

    public DBTreasure GetRandomTreasure()
    {
        int randomindex = UnityEngine.Random.Range(0, m_TreasureList.GetEventList().Count);
        return m_TreasureList.GetEventList()[randomindex];
    }
}
