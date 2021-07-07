using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
public GameObject PCPrefab;
public GameObject ZombiePrefab;

Unit playerUnit;
Unit enemyUnit;
public BattleState state;

public Transform EnemyIconStation;
public TMPro.TMP_Text EnemyName;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupBattle(){
        GameObject Player = Instantiate(PCPrefab);
        playerUnit = Player.GetComponent<Unit>();
        
        GameObject Enemy = Instantiate(ZombiePrefab, EnemyIconStation);
        enemyUnit = Enemy.GetComponent<Unit>();

        EnemyName.text = enemyUnit.unitName;

        //enemyUnit.unitName;

    }
}
