using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    private Text text;
    private MainBar bar = null;
    private Player player = null;



    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    public Inventory StartInventory(string typ)
    {
        switch (typ)
        {

            case "Barinventory":
                return StartBarInventory();
                
            case "Player":
                return StartPlayerInventory();
                

        }

        return null;
    }

    private Inventory StartPlayerInventory()
    {

        List<Image> inventory = new List<Image>();
        for(int i = 1; i < 15; i++)
        {

        }

        return this;

    }

    private Inventory StartBarInventory()
    {
        List<Image> inventory = new List<Image>();
        for (int i = 1; i < 20; i++)
        {

        }

        return this;
    }
}
