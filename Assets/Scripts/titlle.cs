using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titlle : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(GoToMain);
    }

    // Update is called once per frame
    void GoToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
