using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Sirenix.OdinInspector;

public class CutScene : MonoBehaviour
{
    [SerializeField] GameObject playerCard;
    [SerializeField] GameMng gameMng;
    [SerializeField] BattleMng battleMng;
    [SerializeField] TutorialMng tutorialMng;

    /// <summary>
    /// 関数名で指定された関数を呼び出す
    /// </summary>
    /// <param name="cutSceneName">呼び出す関数の名前</param>
    public void LaunchEvent(string cutSceneName)// from ChatGPT 
    {
        Debug.Log("cutscene Launched.");
        MethodInfo method = GetType().GetMethod(
            cutSceneName,
            BindingFlags.Instance | BindingFlags.NonPublic);

        if (method != null)
        {
            method.Invoke(this, null);
        }
        else
        {
            Debug.LogWarning($"{cutSceneName} が見つかりません");
        }

    }
    [Button("プレイヤー死亡イベント")]
    private void playerDie()
    {
        Debug.Log("Player Died.");
        playerCard.transform.SetParent(playerCard.GetComponent<CardBase>().objBaseTransform);//TODO イベントシーン作成
        Invoke(nameof(DestroyplayerCard), 0.1f);
        StaticData.IsPlayerLiving = false;
        gameMng.EnemyAppear();
    }
    private void DestroyplayerCard()//TODO デリゲートとインボーク使っていい感じに
    {
        if (playerCard.GetComponent<CardBase>().GetChildCard() != null)
            playerCard.GetComponent<CardBase>().GetChildCard().transform.SetParent(playerCard.GetComponent<CardBase>().objBaseTransform);
        Destroy(playerCard);
    }
    [Button("敵01起動イベント")]
    private void enemyActivate()
    {
        gameMng.EnemyActivate();
    }
    [Button("戦闘開始演出")]
    private void battleStart()//戦闘開始まで連続で
    {
        battleMng.BattleStart();
        StartCoroutine(tutorialMng.Tutorial01());
        enemyActivate();
    }
    private void tutorial_appearDebris()//?TODO?appear系まとめられないかなあ 書くのが楽になるだけで処理は変わらない、むしろ余計な段階を踏むのでまとめる必要はないかも知れない
    {
        GameObject.Find("Cards").transform.Find("CollectPointCard_Debris").gameObject.SetActive(true);
    }
    private void tutorial_appearMining()
    {
        GameObject.Find("Cards").transform.Find("CollectPointCard_Mining").gameObject.SetActive(true);
    }
    private void tutorial_appearCraftCard_Default()
    {
        GameObject.Find("Cards").transform.Find("CraftCard_Default").gameObject.SetActive(true);
    }
}
