using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MouseOver : MonoBehaviour
{
    public TMPro.TMP_Text Details;

    void update(){
    //    Details.enabled = false;
    }

    // Start is called before the first frame update
    void OnMouseOver()
    {
     Details.enabled = true;   
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        Details.enabled = false;
    }
}
