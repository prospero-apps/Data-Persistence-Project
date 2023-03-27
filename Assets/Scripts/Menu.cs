using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_InputField UsernameInput;
      

    public void StartGame()
    {
        Manager.Instance.Username = UsernameInput.text;
        SceneManager.LoadScene(1);
    }
}
