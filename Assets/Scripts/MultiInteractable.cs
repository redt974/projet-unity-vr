﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiInteractable : MonoBehaviour
{
    [SerializeField] private List<Renderer> listRenderer;
    [SerializeField] private List<Rigidbody> listRigidbodies;
    public Color hoverColor = Color.yellow;
    public Color highlightColor = Color.cyan;

    // public GameObject HoverObj;

    public UnityEvent OnHighlight = new UnityEvent();

    public void Hover(bool toggle)
    {
        // HoverObj.SetActive(toggle);
        if (listRenderer.Count > 0)
        {
            for (int i = 0; i < listRenderer.Count; i++)
            {
                listRenderer[i].material.color = toggle ? hoverColor : Color.white;
            }
        }
        listRenderer[0].material.color = toggle ? hoverColor : Color.white;
    }

    public void Highlight(bool toggle)
    {
        if (listRenderer.Count > 0)
        {
            for (int i = 0; i < listRenderer.Count; i++)
            {
                listRenderer[i].material.color = toggle ? highlightColor : Color.white;
            }
        }
        if (toggle)
        {
            OnHighlight?.Invoke();
        }
    }

        public void SetKinematic(bool value)
    {
        foreach (var rb in listRigidbodies)
        {
            if (rb != null) rb.isKinematic = value;
        }
    }

    public void ApplyVelocity(Vector3 velocity, float multiplier)
    {
        foreach (var rb in listRigidbodies)
        {
            if (rb != null) rb.linearVelocity = velocity * multiplier;
        }
    }

    public void MoveTo(Vector3 position)
    {
        // Applique à tous les Rigidbody une nouvelle position (optionnel, sinon déplacer seulement le parent)
        foreach (var rb in listRigidbodies)
        {
            if (rb != null)
            {
                rb.MovePosition(position);
            }
        }
    }
}