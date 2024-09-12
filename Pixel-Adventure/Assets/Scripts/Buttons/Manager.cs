using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private bool access = false;
    private string login;
    private string log2 = "123";
    private string password;
    private string pass2 = "1234";

    public void EnterLogin(string input)
    {
        login = input;
    }

    public void EnterPassword(string input)
    {
        password = input;
    }

    public void Access()
    {
        if (login == log2 && password == pass2) { access = true; }
        if (access)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
