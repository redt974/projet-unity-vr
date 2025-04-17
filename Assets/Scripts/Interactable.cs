﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    public Color hoverColor = Color.yellow; 
    public Color highlightColor = Color.cyan;

    public UnityEvent OnHighlight = new UnityEvent();

    public void Hover(bool toggle)
    {
        renderer.material.color = toggle ? hoverColor : Color.white;
    }

    public void Highlight(bool toggle)
    {
        renderer.material.color = toggle ? highlightColor : Color.white;
        if(toggle)
        {
            OnHighlight?.Invoke();
        }
    }
}