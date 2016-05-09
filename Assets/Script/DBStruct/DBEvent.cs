using System.Collections.Generic;
public class DBEvent
{
    public int Id { get; set; }
    public int Type { get; set; }
    public string Event { get; set; }
    public int Money { get; set; }
    public int Prison { get; set; }
    public int Step { get; set; }
    public int Begin { get; set; }
    public int Sell { get; set; }
    public int Buy { get; set; }
    public int Round { get; set; }
}


public class EventList
{
    List<DBEvent> m_eventList = new List<DBEvent>();

    public List<DBEvent> GetEventList()
    {
        return m_eventList;
    }

    public DBEvent GetEvent(int id)
    {
        for(int i = 0; i < m_eventList.Count; i++)
        {
            if(m_eventList[i].Id == id)
            {
                return m_eventList[i];
            }
        }
        return null;
    }

    public void AddEvent(DBEvent evn)
    {
        evn.Id = m_eventList.Count;
        m_eventList.Add(evn);
    }
}