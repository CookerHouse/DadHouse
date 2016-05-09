using UnityEngine;
using System.Collections;

public class MyCard : MonoBehaviour {
    private bool openCardlist = false;
    public GameObject Cardlist;
    public GameObject Grid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenCardList()
    {
        openCardlist = !openCardlist;
        Cardlist.SetActive(openCardlist);
    }

    public void AddCard(int indexid)
    {
        //Instantiate(Resources.Load("Resource\"))
    }
}
