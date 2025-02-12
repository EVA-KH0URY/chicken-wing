using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class wingcounter : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI countText;

    public Animator animator;
    public AudioSource audioSource;
    public AudioClip explosionSound;
    public GameObject hungryGuy;
    public GameObject animatedSprite;

   

    // Start is called before the first frame update
    void Start()
    {
        clickwing wingScript = FindObjectOfType<clickwing>();
        if (wingScript != null)
        {
            wingScript.onFourthImage.AddListener(IncrementCounter);
        }
        if (animatedSprite != null)
        {  
            animatedSprite.SetActive(false);
        }
    }

    void IncrementCounter()
    {
        count++;
        UpdateCountDisplay();
        Debug.Log("chicken wings eaten: " + count);

        if (count == 25) 
        {
            TriggerExplosionEvents();
        }
    }


   public void TriggerExplosionEvents()
    {

        if (animatedSprite != null)
        {
            animatedSprite.SetActive(true);
            Destroy(animatedSprite, 0.5f);
        }

       

        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        if (hungryGuy != null)
        {
            hungryGuy.SetActive(false);
        }

        clickwing wingScript = FindObjectOfType<clickwing>();
        if (wingScript != null)
        {
            wingScript.DestroyChickenWing();
        }
    }

    IEnumerator HideAfterAnimation()
    {
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animationLength);

        if (animatedSprite != null)
        {
            animatedSprite.SetActive(false);
        }
    }

    void UpdateCountDisplay()
    { 
        if (countText != null)
        {
            countText.text = "chicken wings eaten: " + count;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
