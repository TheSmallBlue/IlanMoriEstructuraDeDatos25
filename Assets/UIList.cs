using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIList : MonoBehaviour
{
    [SerializeField] Transform listItem;

    // ---

    private void Awake()
    {
        listItem.gameObject.SetActive(false);
    }

    public void UpdateList(string[] items)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < items.Length; i++)
        {
            // Si ya tenemos un transform preparado para este objeto, le cambiamos el valor y lo activamos.
            // Así no tenemos que instanciar objetos al pedo
            if (i < transform.childCount)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                transform.GetChild(i).GetComponentInChildren<TMP_Text>().text = items[i];
            }
            else
            {
                GameObject newItem = Instantiate(listItem.gameObject, transform);
                newItem.GetComponentInChildren<TMP_Text>().text = items[i];
            }
        }

    }
}
