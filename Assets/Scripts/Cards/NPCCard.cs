using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MyDictionary<TKey, TValue>
{
    [SerializeField] private TKey _key;
    [SerializeField] private TValue _value;

    public TKey Key => _key;
    public TValue Value => _value;
}
public class NPCCard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject talkObj;
    float nowChildCount;
    [Serializable]
    public struct talkElement
    {
        public string talkName;
        public bool isEndless;
    }
    [SerializeField] Sprite defaultGraphic, blinkGraphic;
    private string talkThema = "";
    public Action talkedEventDelegate = null;//!個別スクリプト(Event)側でこれへの代入を忘れないこと！
    public Action talkedEventDelegate_withoutPlayer = null;//!こっちも
    //TODO? 正直個別スクリプトを共通スクリプトからの継承にして関数をオーバーライドするほうが綺麗かも そのうちね……
    private int talkIndex = 1;
    void Start()
    {
        nowChildCount = transform.childCount;
        GetComponent<Renderer>().material.shader = Shader.Find("Sprites/Default");
        talkObj = GameObject.Find("Parent_of_InactiveObjects").transform.Find("TalkManager").gameObject;
        talkObj.GetComponent<TalkMng>().defaultGraphic = defaultGraphic;
        talkObj.GetComponent<TalkMng>().blinkGraphic = blinkGraphic;
    }
    void OnTransformChildrenChanged()//上にカードが乗ったら
    {
        if (transform.childCount > nowChildCount)
        {
            if (GetComponent<CardBase>().childCard.GetComponent<CardBase>().cardID == "player")
            {
                talkedEventDelegate();
                talkObj.GetComponent<TalkMng>().StartTalk(talkThema + "_" + talkIndex.ToString(), this);//"Guid_noramal1_1" "Guid_choice3_1"など
                if (talkObj.GetComponent<TalkMng>().IsTalkDataExist(talkThema + "_" + (talkIndex + 1).ToString()))
                    talkIndex++;
            }
        }
        else if (transform.childCount < nowChildCount)
        {
            //Debug.Log(name + "childrenの減少を検知");
        }
        nowChildCount = transform.childCount;//nowChildCountは一連の判定・処理が終わってから更新
    }
    private void OnMouseOver()
    {
        if (GetComponent<CardBase>().objBaseTransform.GetComponent<CardMng>().cardsClickable)
        {
            if (Input.GetMouseButtonDown(1) && StaticData.IsPlayerLiving == false)
            {
                talkedEventDelegate_withoutPlayer();
                talkObj.GetComponent<TalkMng>().StartTalk(talkThema + "_" + talkIndex.ToString(), this);//"Guid_noramal1_1" "Guid_choice3_1"など
                if (talkObj.GetComponent<TalkMng>().IsTalkDataExist(talkThema + "_" + (talkIndex + 1).ToString()))
                    talkIndex++;
            }

        }
    }
    public void ChangeTalkThema(string talkThemaName)
    {
        talkThema = talkThemaName;
        talkIndex = 1;
    }
}
