using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField] TMP_InputField Reg_Username;  
    [SerializeField] TMP_InputField Reg_Password;  
    [SerializeField] TMP_Text errorText;  

    public async void OnRegisterPressed()
    {
        
        if (string.IsNullOrEmpty(Reg_Username.text) || Reg_Username.text.Length < 5)
        {
            ShowError("Введите логин (минимум 5 символов)");
            return;
        }

        if (string.IsNullOrEmpty(Reg_Password.text) || Reg_Password.text.Length < 5)
        {
            ShowError("Введите пароль (минимум 5 символов)");
            return;
        }

        
        bool success = await MySqlManager.RegisterUser(Reg_Username.text, Reg_Password.text);
        if (success)
        {
            Debug.Log("Успешная регистрация");
            
        }
        else
        {
            ShowError("Ошибка при регистрации");
        }
    }

    
    private void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
            errorText.gameObject.SetActive(true);  
        }
    }

    public void OnBackPressed()
    {
        SceneManager.LoadScene("AuthChoice");  
    }
}
