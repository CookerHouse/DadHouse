using UnityEngine;
using System.Collections.Generic;

public class SQLiteDataManager
{
    private string persistentFilePath;

    //所有数据库数据的缓存列表
    //private List<StoryConfig> storyList = new List<StoryConfig> ();
    //private List<HeroState> heroList = new List<HeroState> ();
    private List<DBEvent> eventList = new List<DBEvent>();
    private List<DBTreasure> treasureList = new List<DBTreasure>();

    public SQLiteDataManager(string persistentFilePath)
    {
        Debug.Log("=>>>>>>>>>>>>>");
        this.persistentFilePath = persistentFilePath;
        DBDataUtil.getInstance().setPerSistentPath(persistentFilePath);
        Debug.Log("persistentFilePath---=" + persistentFilePath);
        initDbData();
    }

    /// <summary>
    /// 初始化所有Db数据到缓存中
    /// </summary>
    public void initDbData()
    {
        eventList = DBDataUtil.getInstance().GetAllDataFromDB<DBEvent>(new DBEvent(), "Event");
        treasureList = DBDataUtil.getInstance().GetAllDataFromDB<DBTreasure>(new DBTreasure(), "Treasure");
        //storyList = DBDataUtil.getInstance().GetAllDataFromDB<StoryConfig> (new StoryConfig());//
        //heroList = DBDataUtil.getInstance().GetAllDataFromDB<HeroState> (new HeroState());
    }

    public DBEvent GetEventItem(int id)
    {
        Debug.Log("eventList.Count = " + eventList.Count);
        for (int i = 0; i < eventList.Count; i++)
        {
            if (eventList[i].Id == id)
            {
                Debug.Log("eventList[i] = " + eventList[i].Event);
                return eventList[i];
            }
        }
        return null;
    }

    public DBTreasure GetTreasure(int id)
    {
        for (int i = 0; i < treasureList.Count; i++)
        {
            if (treasureList[i].Id == id)
            {
                Debug.Log("eventList[i] = " + treasureList[i].Event);
                return treasureList[i];
            }
        }
        return null;
    }

    //查询剧情的对应本地数据
    //public string GetStoryItem(int id)
    //{
    //	for(int i = 0; i < storyList.Count; i++)
    //	{
    //		if(storyList[i].ploatAtomSymbol == id) {
    //		return storyList[i].content;
    //		}
    //	}

    //	return null;
    //}

    //public HeroState GetHeroData(int id)
    //{
    //	for(int i = 0; i < heroList.Count; i++)
    //	{
    //		if(heroList[i].ID == id) 
    //		{
    //			return heroList[i];
    //		}
    //	}
    //	return null;
    //}
}
