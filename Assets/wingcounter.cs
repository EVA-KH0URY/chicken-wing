using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class wingcounter : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI countText;

   

    // Start is called before the first frame update
    void Start()
    {
        clickwing wingScript = FindObjectOfType<clickwing>();
        if (wingScript != null)
        {
            wingScript.onFourthImage.AddListener(IncrementCounter);
        }
    }

    void IncrementCounter()
    {
        count++;
        UpdateCountDisplay();
        Debug.Log("chicken wings eaten: " + count);

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
