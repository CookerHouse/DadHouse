using System.Collections.Generic;
public class DBTreasure
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


public class TreasureList
{
    List<DBTreasure> m_treasureList = new List<DBTreasure>();

    public List<DBTreasure> GetEventList()
    {
        return m_treasureList;
    }

    public DBTreasure GetTreasure(int id)
    {
        for (int i = 0; i < m_treasureList.Count; i++)
        {
            if (m_treasureList[i].Id == id)
            {
                return m_treasureList[i];
            }
        }
        return null;
    }

    public void AddTreasure(DBTreasure evn)
    {
        evn.Id = m_treasureList.Count;
        m_treasureList.Add(evn);
    }
}