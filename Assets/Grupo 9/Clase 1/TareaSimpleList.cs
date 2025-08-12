using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TareaSimpleList : MonoBehaviour
{
    [SerializeField] UIList uiList;

    // ---

    SimpleList<string> list = new SimpleList<string>();

    // ---

    public void AddItem(string item)
    {
        list.Add(item);
        uiList.UpdateList(list.ToArray());
    }

    public void RemoveItem(string item)
    {
        list.Remove(item);
        uiList.UpdateList(list.ToArray());
    }

    public void AddRange(string[] range)
    {
        list.AddRange(range);
        uiList.UpdateList(list.ToArray());
    }

    // ---

    public void AddRange(string rangeSeparatedByComma)
    {
        AddRange(rangeSeparatedByComma.Split(", "));
    }

    // ---

    public void AddItem(TMP_InputField input)
    {
        AddItem(input.text);
    }

    public void RemoveItem(TMP_InputField input)
    {
        RemoveItem(input.text);
    }

    public void AddRange(TMP_InputField input)
    {
        AddRange(input.text.Split(", "));
    }
}
