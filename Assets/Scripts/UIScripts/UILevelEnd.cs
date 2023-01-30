using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UILevelEnd : MonoBehaviour
{
    [SerializeField][TextArea(2, 4)] string[] endLevelTexts;
    [SerializeField] TextMeshProUGUI message_text, score_text;
    [SerializeField] Button nextLevel_button, tryAgain_button;

    public void CallLevelEndUI(bool isWon, string score)
    {
        message_text.text = isWon ? endLevelTexts[0] : endLevelTexts[1];

        score_text.text = score;

        nextLevel_button.gameObject.SetActive(isWon);
        tryAgain_button.gameObject.SetActive(!isWon);
    }
}
