using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class clickwing : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onFourthImage = new UnityEvent();
    

    public Sprite firstImage;
    public Sprite secondImage;
    public Sprite thirdImage;
    public Sprite fourthImage;
    public AudioClip clickSound;

    public float newVolume;

    private Image imageComponent;
    private AudioSource audioSource;
    private int currentImageIndex = 0;

    
    
    
    // Start is called before the first frame update
    void Start()
    {

        imageComponent = GetComponent<Image>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;

       

    }

    public void SetVolume()
    {
        audioSource.volume = newVolume;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        audioSource.Play();
        
        currentImageIndex = (currentImageIndex + 1) % 4;
       
        switch(currentImageIndex)
        {
            case 0:
                imageComponent.sprite = firstImage;
                break;
            case 1:
                imageComponent.sprite = secondImage;
                break;
            case 2:
                imageComponent.sprite = thirdImage;
                break;
            case 3:
                imageComponent.sprite = fourthImage;
                onFourthImage.Invoke();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
