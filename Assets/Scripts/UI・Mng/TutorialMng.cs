using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialMng : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TextMeshPro tutorialString;
    void Start()
    {
        tutorialString.color = Color.cyan;
    }
    public void DisplayTutorial(string _text)
    {
        tutorialString.text = _text;
        animator.Play("TutorialDisplay");
    }
    public void DisappearTutorial()
    {
        animator.Play("TutorialDisappear");
    }
    public void SwitchTutorial(string _text)
    {
        DisappearTutorial();
        DisplayTutorial(_text);
    }
    public IEnumerator Tutorial01()
    {
        //TODO 長押しに変更
        SwitchTutorial("プレイヤーカードは死亡した。\nしかしあなたはまだプレイヤーであれる。");
        yield return new WaitForSeconds(3);
        SwitchTutorial("カーソルに攻撃を受けるとダメージを負う。");//あなたは自分のカーソルで、プレイヤーの動作を代替できる。\nそれはあなた自身であるからだ。\nあなた自身であるから、
        yield return new WaitForSeconds(6);
        SwitchTutorial("カードへのインタラクトは、右クリックで代替できる。\n\n採取ポイントに右クリック長押し:採取  キャラクターを右クリック:会話 ");
        yield return new WaitForSeconds(10);
        SwitchTutorial("武器も右クリックで操作できる。\n\n右クリック長押し:狙いを定める 右クリックを離す:発射");
        yield return new WaitForSeconds(15);
        SwitchTutorial("");



    }
}
