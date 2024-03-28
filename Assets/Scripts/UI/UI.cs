using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void RestartGameBtn() => GameManager.instance.RestartScene();
    public void BackToMainMenu() => GameManager.instance.BackToMainMenu();

    public void Continue() => GameManager.instance.GamePause(false);
}
