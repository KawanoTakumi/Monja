using System.Collections.Generic;
using UnityEngine;

public class Inventry : MonoBehaviour
{
    public static Inventry instance;
    InventryUI inventryUI;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        inventryUI = GetComponent<InventryUI>();
        inventryUI.UpdateUI();
    }

    public List<Dictionary> items = new List<Dictionary>();

    public void Add(Dictionary item)
    {
        items.Add(item);
        inventryUI.UpdateUI();
    }

    public void Remove(Dictionary item)
    {
        items.Remove(item);
        inventryUI.UpdateUI();
    }
}