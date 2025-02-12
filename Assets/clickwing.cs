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

    public float minX = -400f;
    public float maxX = 400f;
    public float minY = -300f;
    public float maxY = 300f;

    private Image imageComponent;
    private AudioSource audioSource;
    private int currentImageIndex = 0;
    private RectTransform rectTransform;

    
    
    
    // Start is called before the first frame update
    void Start()
    {

        imageComponent = GetComponent<Image>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;
        rectTransform = GetComponent<RectTransform>();
       

    }

    public void SetVolume()
    {
        audioSource.volume = newVolume;
    }

    public void DestroyChickenWing()
    {
        Destroy(gameObject);
    }

    public void MoveToRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        rectTransform.anchoredPosition = new Vector2(randomX, randomY); 
    }


    public void OnPointerClick(PointerEventData eventData)
    {

        audioSource.Play();
        
        currentImageIndex = (currentImageIndex + 1) % 4;
       
        switch(currentImageIndex)
        {
            case 0:
                imageComponent.sprite = firstImage;
                MoveToRandomPosition();
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
