using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class AuthLogin : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField loginInput;
    public TMP_InputField passwordInput;

    [Header("Buttons")]
    public Button loginButton;
    public Button backButton;

    [Header("Error Message")]
    public TMP_Text errorText;

    private void Start()
    {
        
        loginButton.onClick.AddListener(() => OnLoginClicked());
        backButton.onClick.AddListener(OnBackClicked);

        
        if (errorText != null)
            errorText.gameObject.SetActive(false);
    }

    private async void OnLoginClicked()
    {
        string username = loginInput.text;
        string password = passwordInput.text;

        
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowError("Заполните все поля!");
            return;
        }

        
        bool isLoggedIn = await MySqlManager.LoginUser(username, password);
        
        if (isLoggedIn)
        {
           SceneManager.LoadScene("Dashboard");
        }
        else
        {
            ShowError("Неверный логин или пароль");
        }
    }

    private void OnBackClicked()
    {
        SceneManager.LoadScene("AuthChoice");
    }

    private void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
            errorText.gameObject.SetActive(true);
        }
    }
}
