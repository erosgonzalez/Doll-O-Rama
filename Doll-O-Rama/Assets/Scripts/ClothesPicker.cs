using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPicker : MonoBehaviour
{
    private List<GameObject> clothes;
    private int selectionIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        clothes = new List<GameObject>();

        foreach (Transform t in transform)
        {
            clothes.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        clothes[0].SetActive(true);
        clothes[1].SetActive(true);
    }

    public void selectClothes(int index)
    {
        if (clothes[index].activeSelf == true)
        {
            clothes[index].SetActive(false);
        }else{
            selectionIndex = index;
            clothes[selectionIndex].SetActive(true);
        }



       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
