using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickGoToRandomSprite : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject Misdirection;
    public GameObject Enemy;

    public void onCalled(){
        int called = Random.Range(1, 3);
        switch (called){
            case 1:
            Enemy = Zombie;
            break;
            case 2: 
            Enemy = Misdirection;
            break;
            case 3:
            Enemy = Zombie;
            break;
            default:
            Enemy = Misdirection;
            break;

        }

    
    }
}
