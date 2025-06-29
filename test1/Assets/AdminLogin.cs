using UnityEngine;
using TMPro;  
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class AdminLoginManager : MonoBehaviour
{
    [SerializeField] TMP_InputField loginUsername;   
    [SerializeField] TMP_InputField loginPassword;   
    [SerializeField] TMP_Text errorText; 

    [SerializeField] Button loginButton; 
    [SerializeField] Button backButton;  

    private void Start()
    {
        
        loginButton.onClick.AddListener(OnLoginPressed);
        backButton.onClick.AddListener(OnBackPressed);

        
        if (errorText != null)
        {
            errorText.gameObject.SetActive(false);
        }
    }

    
    public async void OnLoginPressed()
    {
        
        if (loginUsername == null || loginPassword == null || errorText == null)
        {
            Debug.LogError("Не все объекты правильно привязаны в инспекторе.");
            return;
        }

        if (string.IsNullOrWhiteSpace(loginUsername.text) || loginUsername.text.Length < 5)
        {
            ShowError("Введите логин (минимум 5 символов)");
            return;
        }

        if (string.IsNullOrWhiteSpace(loginPassword.text) || loginPassword.text.Length < 5)
        {
            ShowError("Введите пароль (минимум 5 символов)");
            return;
        }

        
        bool success = await MySqlManager.LoginAdmin(loginUsername.text, loginPassword.text);

        
        if (success)
        {
            
            Debug.Log("Успешный вход администратора");
            SceneManager.LoadScene("AdminDashboard");  
        }
        else
        {
            
            ShowError("Ошибка: такого администратора не существует");
        }
    }

    
    public void OnBackPressed()
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
