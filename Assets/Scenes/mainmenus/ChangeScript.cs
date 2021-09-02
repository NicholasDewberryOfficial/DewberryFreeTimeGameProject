using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class ChangeScript : MonoBehaviour
{
    public GameObject battleScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OpenBattleScene(){
        SceneManager.LoadScene("BattleScene");
        
    }
}
