using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TareasContainer : MonoBehaviour
{
    [SerializeField] Button moveLeftButton, moveRightButton;

    [Space]
    [SerializeField] int currentTareaIndex = 0;

    // ---

    float smoothVelocity;

    // ---

    private void Start()
    {
        if (moveLeftButton == null || moveRightButton == null) return;

        moveLeftButton.onClick.AddListener(MoveLeft);
        moveRightButton.onClick.AddListener(MoveRight);

        if (currentTareaIndex == 0)
            moveLeftButton?.gameObject.SetActive(false);
        else if (currentTareaIndex == transform.childCount)
            moveRightButton?.gameObject.SetActive(false);
    }

    private void Update()
    {
        RectTransform rectTransform = (RectTransform)transform;

        float smoothX = Mathf.SmoothDamp(rectTransform.anchoredPosition.x, -1920 * currentTareaIndex, ref smoothVelocity, 0.1f);

        rectTransform.anchoredPosition = new Vector2(smoothX, 0f);
    }

    public void MoveRight()
    {
        currentTareaIndex++;

        if (currentTareaIndex + 1 > transform.childCount - 1)
            moveRightButton.gameObject.SetActive(false);
        else
            moveRightButton.gameObject.SetActive(true);

        moveLeftButton.gameObject.SetActive(true);
    }

    public void MoveLeft()
    {
        currentTareaIndex--;

        if (currentTareaIndex - 1 < 0)
            moveLeftButton.gameObject.SetActive(false);
        else
            moveLeftButton.gameObject.SetActive(true);
        
        moveRightButton.gameObject.SetActive(true);
    }
}
