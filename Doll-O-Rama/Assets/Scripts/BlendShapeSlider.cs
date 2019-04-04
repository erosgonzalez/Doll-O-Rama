using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BlendShapeSlider : MonoBehaviour
{
    [Header("Do not include suffices")]
    public string blendShapeName;
    private Slider slider;

    private void Start()
    {
        blendShapeName = blendShapeName.Trim();
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(value => CharacterCustomization.Instance.changeBlendShapeValue(blendShapeName, value));
    }
}