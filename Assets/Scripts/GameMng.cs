using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyObject;
    [SerializeField] BattleMng battleMng;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnemyAppear()//仮。チュートリアルバトルなので
    {
        enemyObject.SetActive(true);
        battleMng.AddEnemys(enemyObject);
    }
    public void EnemyActivate()
    {
        enemyObject.GetComponent<EnemyCard>().StartBurrage();
    }
    
}
