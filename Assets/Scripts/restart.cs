using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour
{
    public GameObject gameOverUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void screen()
    {
        gameOverUi.SetActive(true);
    }
    // Update is called once per frame
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
