using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class MySqlManager : MonoBehaviour
{
   
   private const string SERVER_URL = "http://10.23.5.44/unityapi";  
  

    
    public static async Task<bool> RegisterUser(string username, string password)
    {
        string url = $"{SERVER_URL}/alo.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest req = UnityWebRequest.Post(url, form))
        {
            var operation = req.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Ответ сервера: " + req.downloadHandler.text);
                return req.downloadHandler.text.Contains("успешно");
            }
            else
            {
                Debug.LogError("Ошибка регистрации: " + req.error);
                return false;
            }
        }
    }

    
    public static async Task<bool> LoginUser(string username, string password)
    {
        string url = $"{SERVER_URL}/auth.php";  
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest req = UnityWebRequest.Post(url, form))
        {
            var operation = req.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Ответ сервера: " + req.downloadHandler.text);
                return req.downloadHandler.text.Contains("success");
            }
            else
            {
                Debug.LogError("Ошибка авторизации: " + req.error);
                return false;
            }
        }
    }

    
    public static async Task<bool> LoginAdmin(string username, string password)
    {
        string url = $"{SERVER_URL}/admin_login.php";  
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest req = UnityWebRequest.Post(url, form))
        {
            var operation = req.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Ответ сервера: " + req.downloadHandler.text);
                return req.downloadHandler.text.Contains("success");
            }
            else
            {
                Debug.LogError("Ошибка авторизации: " + req.error);
                return false;
            }
        }
    }
}
