using UnityEngine;
using System.Collections.Generic;

public static class GlobalVar
{
	public static float timeRate = 1.0f;
	public static float changeTimeDetla;

	public static float defenseLevel = 0;

	public static List<GameObject> g_team1List = new List<GameObject>();
	public static List<GameObject> g_team2List = new List<GameObject>();

	public static void calulateTimeDelta()
	{
		changeTimeDetla = timeRate * Time.deltaTime;
	}
}
