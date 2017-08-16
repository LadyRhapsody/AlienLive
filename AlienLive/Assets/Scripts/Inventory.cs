using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    private Text text;
    private RectTransform rect;
    private List<GameObject> inventory;

    public int slots;
    public int slotSize;
    public int slotPaddingLeft;
    public int slotPaddingTop;
    public int rows;
    public GameObject slotPrefab;
    private ScreenFader fader;

    // Use this for initialization
    void Awake()
    {
        text = GetComponentInChildren<Text>();
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }

    public void StartInventory(string typ)
    {
        switch (typ)
        {

            case "Barinventory":
                StartBarInventory();
                break;
            case "Player":
                StartPlayerInventory();
                break;

        }
    }

    private void StartPlayerInventory()
    {
        rect = GetComponent<RectTransform>();

        var rectHight = rows * (slotSize + slotPaddingTop) + (8 * slotPaddingTop) + 40;
        var rectWidth = (slots / rows) * (slotSize + slotPaddingLeft) + (20 * slotPaddingLeft);

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectWidth);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectHight);

        inventory = new List<GameObject>();

        int colums = slots / rows;
        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < colums; k++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform);

                float x = (2 * slotPaddingLeft) * (k + 1) + (slotSize * k) + slotPaddingLeft;
                float y = -slotPaddingTop * (i + 1) - (slotSize * i) - slotPaddingTop - 40;

                slotRect.localPosition = new Vector3(x, y);

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                slotRect.localScale = new Vector3(1, 1);

                inventory.Add(newSlot);
            }
        }
        text.text = "Spieler Inventar";

    }

    private void StartBarInventory()
    {
        rect = GetComponent<RectTransform>();

        var rectHight = rows * (slotSize + slotPaddingTop) + (10 * slotPaddingTop) + 40;
        var rectWidth = (slots / rows) * (slotSize + slotPaddingLeft) + (10 * slotPaddingLeft);

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectWidth);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectHight);

        inventory = new List<GameObject>();

        int colums = slots / rows;
        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < colums; k++)
            {
                GameObject newSlot = Instantiate(slotPrefab);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform);

                float x = (2 * slotPaddingLeft) * (k + 1) + (slotSize * k) + 2 * slotPaddingLeft;
                float y = -slotPaddingTop * (i + 1) - (slotSize * i) - slotPaddingTop - 50;

                slotRect.localPosition = new Vector3(x, y);

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                slotRect.localScale = new Vector3(1, 1);

                inventory.Add(newSlot);
            }
        }


        //text.text = "Bar Inventar";
        rect.localScale = new Vector3(2, 2);

        StartCoroutine(fader.FadeToBlack());

    }
}
