using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int currentGold;


    void Start()
    {
        currentGold = 0;
    }

    public void AddGold(int goldAmount)
    {
        currentGold += goldAmount;
        MenuManager.Instance.UpdateGoldAmountText(currentGold);
    }
}
