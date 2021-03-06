﻿using UnityEngine;

public class GUIStartScreenFunctions : MonoBehaviour
{
    private GameObject _creditsCanvas;
    private int _direction;
    private GameObject _titleCanvas;
    private bool _transitioning;
    private float _transitionSpeed;

    public void Start()
    {
        _titleCanvas = GameObject.Find("Canvas Title");
        _creditsCanvas = GameObject.Find("Canvas Credits");
        _direction = -1;
        _transitionSpeed = Game.Config.MenuTransitionSpeed;
    }

    public void Update()
    {
        if (_transitioning)
        {
            _titleCanvas.transform.Translate(_transitionSpeed*_direction, 0, 0);
            _creditsCanvas.transform.Translate(_transitionSpeed*_direction, 0, 0);

            if (_titleCanvas.transform.position.x > 0 || _creditsCanvas.transform.position.x < 0)
            {
                _transitioning = false;
                _direction *= -1;
            }
        }
    }

    public void StartGame()
    {
        Application.LoadLevel("Mapscreen");
    }

    public void ToggleCredits()
    {
        _transitioning = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}