using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{

    #region PublicFields
    public UIManager UIManager;

    [Header("Login UI")]
    public Button SignInOrRegisterButton;
    public Button SignInOrRegisterPanelButton;
    public InputField EmailInput;
    public InputField PasswordInput;

    public Text MessageText;
    public Text PanelHeaderTitle;
    public Text SignInOrRegisterText;
    public Text SignInOrRegisterPanelText;

    [HideInInspector]
    public bool isRegisterPanel;
    [HideInInspector]
    public bool isSignInPanel;
    #endregion PublicFields

    #region Methods

    public void Initialize()
    {
        SignInOrRegisterButton.onClick.AddListener(() => SignInOrRegister());
        SignInOrRegisterPanelButton.onClick.AddListener(() => SignInOrRegisterPanel());
        ShowSignInPanel();
    }
    // Text values changed for RegisterPanel
    private void ShowRegisterPanel()
    {
        PanelHeaderTitle.text = "Register";
        SignInOrRegisterPanelText.text = "Login";
        SignInOrRegisterText.text = "Register";
        isSignInPanel = true;
        isRegisterPanel = false;
    }
    // Text values changed for SignInPanel
    private void ShowSignInPanel()
    {
        PanelHeaderTitle.text = "Sign in";
        SignInOrRegisterPanelText.text = "Don't have an account?";
        SignInOrRegisterText.text = "Sign in";
        isSignInPanel = false;
        isRegisterPanel = true;

    }
    private void SignInOrRegisterPanel()
    {
        if (!UIManager.GameManager.LoggedIn)
        {
            if (isSignInPanel)
            {
                ShowSignInPanel();

            }
            else if (isRegisterPanel)
            {
                ShowRegisterPanel();

            }
        }
    }
    private void SignInOrRegister()
    {
        if (!UIManager.GameManager.LoggedIn)
        {
            if (isSignInPanel)
            {
                UIManager.PlayFabManager.Register();

            }
            else if (isRegisterPanel)
            {
                UIManager.PlayFabManager.Login();
            }
        }
    }
    #endregion Methods

}
