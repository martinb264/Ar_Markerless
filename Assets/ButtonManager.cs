using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private RawImage buttonImage;
   

    private int itemId;
    private Sprite buttonTexture;

    public int ItemId
    {
        set => itemId = value;
    }
    public Sprite ButtonTexture 
    { 
        set
        {
            buttonTexture = value;
            buttonImage.texture = buttonTexture.texture;
        }
       
    }

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }
    private void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
           
            transform.localScale = Vector3.one * 2;

        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
    private void SelectObject()
    {
        DataHandler.Instance.setUnit(itemId);
    }
}
