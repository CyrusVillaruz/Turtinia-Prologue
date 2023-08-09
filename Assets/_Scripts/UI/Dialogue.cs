using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image continueImage;
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        continueImage.enabled = false;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                continueImage.enabled = true;
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        continueImage.enabled = true;
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            continueImage.enabled = false;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                SceneController.instance.LoadLevel();
            }
        }
    }
}
