using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
public GameObject PCPrefab;
public GameObject ZombiePrefab;

public Transform EnemyIconStation;


    // // Start is called before the first frame update
    // void Start()
    // {
    //     state = BattleState.START;
    //     SetupBattle();
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // void SetupBattle(){
    //     GameObject Player = Instantiate(PCPrefab, (-1, -1, -1));
    //     //playerGO.get
    //     instantiate(ZombiePrefab, EnemyIconStation);

    // }
}
