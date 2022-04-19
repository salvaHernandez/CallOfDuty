using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponInfo_UI : MonoBehaviour
{

    public TMP_Text currentBullets;
    public TMP_Text totalBullets;


    private void OnEnable()
    {
//        EventManager.current.updateBulletsEvent.Addlistener(UpdateBullets);
    }

    private void OnDisable()
    {

    }


    public void UpdateBullets(int newCurrentBullets, int newTotalBullets) 
    {
        currentBullets.text = newCurrentBullets.ToString();
        totalBullets.text = newTotalBullets.ToString();
    }

}
