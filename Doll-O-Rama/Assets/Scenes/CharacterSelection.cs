using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private List<GameObject> models;
    private int selectionIndex = 0;
    private float speed = 50f;

    private bool rotateLeft = false, rotateRight = false;

    private void Start()
    {
        models = new List<GameObject>();
        foreach(Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        models[selectionIndex].SetActive(true);
    }

    public void Select(int index)
    {
        if (index < 0 || index >= models.Count || index == selectionIndex)
        {
            return;
        }

        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);

    }

    private void Update()
    {
        if (rotateRight)
            transform.Rotate(Vector3.up * speed * Time.deltaTime);

        if (rotateLeft)
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
    }
}
