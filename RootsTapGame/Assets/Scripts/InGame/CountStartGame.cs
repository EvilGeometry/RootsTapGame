using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountStartGame : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countUI;

    public void StartCount()
    {
        StartCoroutine(CountBeforeStartGame());
    }

    IEnumerator CountBeforeStartGame()
    {
        int count = 3;
        while(count > 0)
        {
            countUI.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countUI.gameObject.SetActive(false);

        GameController.Instance.CurrentStatusGame = StatusGame.Play;
    }
}
