using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject replayBtn;
    public Text countText;
    public Text infoText;

    void Start()
    {
        infoText.text = GameParams.text;
        countText.text = "Count: " + GameParams.count.ToString();
    }
    
    void Update()
    {
        infoText.text = GameParams.text;
        countText.text = "Count: "+GameParams.count.ToString();
        Debug.Log("####::" + GameParams.text);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
