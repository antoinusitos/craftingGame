using UnityEngine;
using System.Collections;

public class PanelShop : MonoBehaviour {

    public GameObject theShop;

    public void Execute(int i)
    {
        if(theShop != null)
        {
            theShop.GetComponent<Shop>().Execute(i);
        }
    }
}
