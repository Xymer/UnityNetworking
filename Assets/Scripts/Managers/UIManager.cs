using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    public InputField passwordField;
    private RectTransform passwordTransform;
    private Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log($"Instance already exists, destroying{this.gameObject.name}");
            Destroy(this);
        }
        passwordTransform = (RectTransform)passwordField.transform;
    }
    private void OnGUI()
    {
       // passwordField.text = GUI.PasswordField(passwordTransform.rect, passwordField.text, '*');
    }
    public void ConnectToServer()
    {
        startMenu.SetActive(false);
        usernameField.interactable = false;
        Camera.main.enabled = false;
        Client.instance.ConnectToServer();
    }
}
