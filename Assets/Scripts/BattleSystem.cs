using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST, NEXT }

public class BattleSystem : MonoBehaviour
{
public GameObject PCPrefab;
public GameObject ZombiePrefab;
public GameObject Deck;

Unit playerUnit;
Unit enemyUnit;
public BattleState state;

public Transform EnemyIconStation;
public TMPro.TMP_Text EnemyName;
public TMPro.TMP_Text PcName;

public TMPro.TMP_Text PCHP;

public TMPro.TMP_Text EnemyHP;
public BattleHud playerHud;
public BattleHud enemyHud;
public TMPro.TMP_Text DialogueText;





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

    void NEXT(){
        //GameObjec
    }

    //IEnumerator SetupBattle(){

    void SetupBattle(){
        GameObject Player = Instantiate(PCPrefab);
        playerUnit = Player.GetComponent<Unit>();
        
        GameObject Enemy = Instantiate(ZombiePrefab, EnemyIconStation);
        enemyUnit = Enemy.GetComponent<Unit>();
        playerHud.SetHud(playerUnit);
        enemyHud.SetHud(enemyUnit);

      // yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }
    IEnumerator PlayerTurn(){
        //playerUnit.checkHeat(HeatLevel);
        yield return new WaitForSeconds(.5f);
        DialogueText.text +=  "choose an action \n";
    }
    

    IEnumerator EnemyTurn(){
        DialogueText.text += enemyUnit.unitName + " Attacks! \n";
        yield return new WaitForSeconds(.5f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHud.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(.5f);
        enemyUnit.HeatLevel += 1;

        if (isDead){
            state = BattleState.LOST;
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    

    void EndBattle(){
        if(state == BattleState.WON){
            DialogueText.text += "You won";
        } else if(state == BattleState.LOST){
            DialogueText.text += "you lost";
        }
    }

    public void onAttackButton(){
        if (state != BattleState.PLAYERTURN){
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack(){
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHud.SetHP(enemyUnit.currentHP);
        DialogueText.text +=  "Unarmed Attack! \n";
        yield return new WaitForSeconds(.5f);

        if(isDead){
            state=BattleState.WON;
            EndBattle();
        }
        else{
            state=BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }}
        

    public void onAbsorbButton(){
        if (state != BattleState.PLAYERTURN){
            return;
        }
        StartCoroutine(absorbAttack());
    }

    public void onLowerHeatButton(){
        if (state != BattleState.PLAYERTURN){
            return;
        }
        StartCoroutine(LowerHeat());
    }

    IEnumerator absorbAttack(){
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage - 2);
        enemyHud.SetHP(enemyUnit.currentHP);
        playerUnit.Heal(5);
        playerUnit.HeatLevel +=1;
        DialogueText.text +=  "Absorb Attack! Heat has gone up... \n";
        yield return new WaitForSeconds(.5f);

        if(isDead){
            state=BattleState.WON;
            EndBattle();
        }
        else{
            state=BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }}

    IEnumerator LowerHeat(){
        playerUnit.HeatLevel -=2;
        playerUnit.TakeDamage(2);
        DialogueText.text +=  "You cool yourself down... But it makes you vulnerable! \n";
        yield return new WaitForSeconds(.5f);
        bool isDead = false;

        if(isDead){
            state=BattleState.WON;
            EndBattle();
        }
        else{
            state=BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }}

    

    

}