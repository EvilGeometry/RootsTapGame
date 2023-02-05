using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTapButton : MonoBehaviour
{
    Button tapButton;

    [SerializeField]
    private int tapsToAchieve;

    [SerializeField]
    private int currentTaps = 0;

    // Start is called before the first frame update
    void Start()
    {
        tapButton = GetComponent<Button>();
    }

    /// <summary>
    /// Method called from the button OnClick event.
    /// </summary>
    public void Tapping()
    {
        currentTaps++;
        if(currentTaps >= tapsToAchieve)
        {
            tapButton.interactable = false;
        }
    }
}
