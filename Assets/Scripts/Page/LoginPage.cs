using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPage : MonoBehaviour
{
    [SerializeField] private UIInput _account;
    [SerializeField] private UIInput _password;
    [SerializeField] private GameObject _loginBtn;

    void Awake()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("userAccoumt", "")))
        {
            _account.value = PlayerPrefs.GetString("userAccoumt", "");
        }
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("userPassword", "")))
        {
            _password.value = PlayerPrefs.GetString("userPassword", "");
        }

        UIEventListener.Get(_loginBtn).onClick += (go) =>
        {
            UserModel.Inst.Login(_account.value, _password.value, loginServerEnd);
        };
    }

    private void loginServerEnd(bool success)
    {
        if (!success)
            return;
        PlayerPrefs.SetString("userAccoumt", _account.value);
        PlayerPrefs.SetString("userPassword", _password.value);
        PlayerPrefs.Save();

        Destroy(gameObject);
        Main.Instants.LoginFinished();
    }
}
