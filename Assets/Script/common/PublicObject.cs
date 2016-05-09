using UnityEngine;
using System.Collections;

public class PublicObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.GetInstance().AddEvent(0, "东大街上遭遇小偷光顾损失500元", -500, 0, 0, 0, 0, 0, 0);
        EventManager.GetInstance().AddEvent(1, "因喝酒驾驶汽车被西大街交警盘查发现入牢", 0, 1, 0, 0, 0, 0, 3);
        EventManager.GetInstance().AddEvent(2, "北大街上遇到免费摩的多走了3步", 0, 0, 3, 0, 0, 0, 0);
        EventManager.GetInstance().AddEvent(3, "坐上了环线车迅速回到了起点", 0, 0, 0, 1, 0, 0, 0);
        EventManager.GetInstance().AddEvent(4, "因未按时信用卡还款银行强行拍卖土地一块", 0, 0, 0, 0, 1, 0, 0);
        EventManager.GetInstance().AddEvent(4, "支持政府拆迁政府优惠提供土地一处", 0, 0, 0, 0, 0, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
