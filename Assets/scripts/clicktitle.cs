using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clicktitle : MonoBehaviour, IPointerClickHandler
{

    public Sprite firstImage;
    public Sprite secondImage;

    private Image imageComponent;

    private bool isFirstImage = true;

    
    
    
    // Start is called before the first frame update
    void Start()
    {

        imageComponent = GetComponent<Image>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isFirstImage)
            imageComponent.sprite = secondImage;

        else imageComponent.sprite = firstImage;

        isFirstImage = !isFirstImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
