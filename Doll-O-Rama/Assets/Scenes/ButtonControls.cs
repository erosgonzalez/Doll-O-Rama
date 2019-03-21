using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonControls : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void NewButton()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadButton()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(3);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ConfirmButton()
    {
        SceneManager.LoadScene(1);
    }

    public GameObject panelBack, panelGenderSelect;
    public void onConfirmButton()
    {
        panelBack.gameObject.SetActive(false);
        panelGenderSelect.gameObject.SetActive(false);
    }

    //public void onRotateLeftDown(PointerEventData eventData)
    //{
    //    rotateLeft = true;
    //}
    //public void onRotateLeftUp(PointerEventData eventData)
    //{
    //    rotateLeft = false;
    //}

    //public void onRotateRightDown(PointerEventData eventData)
    //{
    //    rotateRight = true;
    //}
    //public void onRotateRightUp(PointerEventData eventData)
    //{
    //    rotateRight = false;
    //}
    //float rotateSpeed = 20;
    //public void onRotate()
    //{
    //    float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;

    //    transform.RotateAround(Vector3.up, -rotX);
    //}
}
