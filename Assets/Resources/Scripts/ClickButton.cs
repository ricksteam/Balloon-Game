using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour, IPointerExitHandler
{
    //threshold to trigger button
    private float triggerTime = 3f;
    //current time hovered over button
    private float _currentTime = 0f;
    //start menu canvas
    public Canvas StartCanvas;
    //image of button
    public Image Progress;
    //difficulty settings menu
    public Canvas DifficultyCanvas;
    //bool to indicate if gaze is on the button
    public bool IsHovering = false;
    //gameobject that contains all of the menu buttons
    private GameObject _buttons;
    //array of all the menu buttons
    private Button[] _clickbuttons;
    public Camera Cam;

    void Start()
    {
        //collection of start menu buttons
        _buttons = GameObject.Find("Start Buttons");
        _clickbuttons = _buttons.GetComponentsInChildren<Button>();
        //show start menu canvas
        StartCanvas.gameObject.SetActive(true);
        //hide difficulty settings canvas
        DifficultyCanvas.gameObject.SetActive(false);
        StartCoroutine(ResetTime());
    }
    public void Update()
    {
        //change collection of buttons to the difficulty settings' buttons if the displayed menu changes
        if (DifficultyCanvas.isActiveAndEnabled)
        {
            _buttons = GameObject.Find("Difficulty Buttons");
            _clickbuttons = _buttons.GetComponentsInChildren<Button>();
            //Debug.Log(difficultyMultiplier);
        }
        //if the gaze is on the button, calculate fill amount
        if (IsHovering)
        {
            _currentTime += Time.deltaTime;
            _currentTime = Mathf.Clamp(_currentTime, 0f, triggerTime);
        }
        //otherwise reduce fill amount
        else
        {
            if (_currentTime >= 0)
            {
                _currentTime -= Time.deltaTime;
                _currentTime = Mathf.Clamp(_currentTime, 0f, triggerTime);
            }
            if (_currentTime < 0)
            {
                _currentTime = 0;
            }
        }
        //set fill amount to calculated amount
        Progress.fillAmount = _currentTime / triggerTime;
        if (Progress.fillAmount == 1)
        {
            //invoke the button click if completely filled
            gameObject.GetComponent<Button>().onClick.Invoke();
            _currentTime = 0;
        }
    }
    public void OnPointerExit(PointerEventData data)
    {
        IsHovering = false;
    }
    public void QuitGame()
    {
        //screen to black
        CameraClearFlags clear = CameraClearFlags.Color;
        Cam.clearFlags = clear;
        Cam.cullingMask = 0;
        //stop playing
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void LoadScene()
    {
        //screen to black
        CameraClearFlags clear = CameraClearFlags.Color;
        Cam.clearFlags = clear;

        Cam.cullingMask = 0;
        SceneManager.LoadScene("PlaneGame");

    }
    public void SelectLevel()
    {
        //hide start menu, show difficulty settings menu
        StartCanvas.gameObject.SetActive(false);
        DifficultyCanvas.gameObject.SetActive(true);
    }
    public void ReturnToStart()
    {
        //hide difficulty settings menu, show start menu
        StartCanvas.gameObject.SetActive(true);
        DifficultyCanvas.gameObject.SetActive(false);
    }

    IEnumerator ResetTime()
    {
        while (true)
        {
            IsHovering = false;
            yield return new WaitForSeconds(1f);
        }
    }
}
