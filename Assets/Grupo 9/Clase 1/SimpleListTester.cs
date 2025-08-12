using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleListTester : MonoBehaviour
{
    [SerializeField] string[] initialListItems;

    // ---

    SimpleList<string> listToTest = new SimpleList<string>();

    // ---

    private void Awake()
    {
        listToTest.AddRange(initialListItems);

        PrintListItems();
    }

    public void AddItem(string item)
    {
        listToTest.Add(item);
        PrintListItems();
    }

    public void RemoveItem(string item)
    {
        listToTest.Remove(item);
        PrintListItems();
    }

    public void AddRange(string[] range)
    {
        listToTest.AddRange(range);
        PrintListItems();
    }

    public void PrintListItems()
    {
        Debug.Log(string.Join(", ", listToTest));
    }
}
