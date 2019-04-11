using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextNarrative : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI Narrativedisplay;
   
    [SerializeField]
    [TextArea(3, 10)]
    private string[] Narrative;
    [SerializeField]
    private string[] negativeNarrative;
    [SerializeField]
    private GameObject goodButton;
    [SerializeField]
    private GameObject badButton;

    private int index;
    public float typingSpeed;
    
    public void BeginNarrative()
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        if (Narrativedisplay.text == Narrative[index])
        {
            goodButton.SetActive(true);
            badButton.SetActive(true);
        }


    }
    IEnumerator Type()
    {
        
        
            foreach (char letter in Narrative[index].ToCharArray())
            {
                Narrativedisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);

            }
        
        
    }
    public void NextNarrative()
    {
        goodButton.SetActive(false);
        badButton.SetActive(false);

        if (index < Narrative.Length - 1)
        {
            index++;
            Narrativedisplay.text = string.Empty;
            StartCoroutine(Type());
        }
        else
        {
            Narrativedisplay.text = string.Empty;
        }
    }
}
