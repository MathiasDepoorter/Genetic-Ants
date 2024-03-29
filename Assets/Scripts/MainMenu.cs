using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionMenu;
    public GameManager Manager;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenParam()
    {
        OptionMenu.SetActive(true);
    }

    public void CloseParam()
    {
        OptionMenu.SetActive(false);
    }

    public void saveParameter()
    {
        InputField nbAnts = GameObject.Find("nbAnts").GetComponent<InputField>();
        Toggle isGenerated = GameObject.Find("isGeneratedObstacle").GetComponent<Toggle>();
        Slider trailDecay = GameObject.Find("trailDecay").GetComponent<Slider>();
        Slider trailAddSpeed = GameObject.Find("trailAddSpeed").GetComponent<Slider>();

        Manager.nbAnts = int.Parse(nbAnts.text);
        Manager.isGenerated = isGenerated.isOn;
        Manager.trailDecay = trailDecay.value;
        Manager.trailAddSpeed = trailAddSpeed.value;

        Debug.Log(Manager.nbAnts);
        Debug.Log(Manager.isGenerated);
        Debug.Log(Manager.trailDecay);
        Debug.Log(Manager.trailAddSpeed);
        CloseParam();
    }
}
