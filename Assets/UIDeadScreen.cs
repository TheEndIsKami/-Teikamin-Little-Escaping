using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIDeadScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        
    }
    private void Update()
    {
        text.text = "There are "+ PlayerStats.instance.currentRunSoulGet.ToString()
           + " souls gathered from you following your collapse";
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
