using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterCustomization : Singleton<CharacterCustomization>
{
    public GameObject target;
    public string suffixMax = "Max", suffixMin = "Min";

    private CharacterCustomization()
    {

    }
    private SkinnedMeshRenderer skmr;
    private Mesh mesh;
    private Dictionary<string, BlendShape> blendShapeDB = new Dictionary<string, BlendShape>();

    private void Start()
    {
        Initialize();
    }

    public void changeBlendShapeValue(string blendShapeName, float value)
    {
        if(!blendShapeDB.ContainsKey(blendShapeName))
        {
            Debug.LogError("BlendShape "+ blendShapeName + " does not exist!");
            return;
        }

        value = Mathf.Clamp(value, -100, 100);

        BlendShape blendShape = blendShapeDB[blendShapeName];

        if(value >= 0)
        {
            if(blendShape.positiveIndex == -1)
            {
                return;
            }
            skmr.SetBlendShapeWeight(blendShape.positiveIndex, value);

            if (blendShape.negativeIndex == -1)
            {
                return;
            }
            skmr.SetBlendShapeWeight(blendShape.negativeIndex, 0);
        }
        else
        {
            if (blendShape.negativeIndex == -1)
            {
                return;
            }
            skmr.SetBlendShapeWeight(blendShape.negativeIndex, -value);

            if (blendShape.positiveIndex == -1)
            {
                return;
            }
            skmr.SetBlendShapeWeight(blendShape.positiveIndex, 0);
        }
    }

    private void Initialize()
    {
        skmr = GetSkinnedMeshRenderer();
        mesh = skmr.sharedMesh;

        ParsedBlendShapesToDictionary();
    }

    private SkinnedMeshRenderer GetSkinnedMeshRenderer()
    {
        SkinnedMeshRenderer _skmr = target.GetComponentInChildren<SkinnedMeshRenderer>();

        return _skmr;
    }

    private void ParsedBlendShapesToDictionary()
    {
        List<string> blendShapeNames = Enumerable.Range(0, mesh.blendShapeCount).Select(x => mesh.GetBlendShapeName(x)).ToList();

        for (int i=0; blendShapeNames.Count > 0; )
        {
            string altSuffix, noSuffix;
            noSuffix = blendShapeNames[i].TrimEnd(suffixMax.ToCharArray()).TrimEnd(suffixMin.ToCharArray()).Trim();

            string positiveName = string.Empty, negativeName = string.Empty;
            bool exists = false;

            int positiveIndex = -1, negativeIndex = -1;

            if(blendShapeNames[i].EndsWith(suffixMax))
            {
                altSuffix = noSuffix + " " + suffixMin;

                positiveName = blendShapeNames[i];
                negativeName = altSuffix;

                if(blendShapeNames.Contains(altSuffix))
                {
                    exists = true;
                }

                positiveIndex = mesh.GetBlendShapeIndex(positiveName);
                if(exists)
                {
                    negativeIndex = mesh.GetBlendShapeIndex(altSuffix);
                }
            }
            else if(blendShapeNames[i].EndsWith(suffixMin))
            {
                altSuffix = noSuffix + " " + suffixMax;

                negativeName = blendShapeNames[i];
                positiveName = altSuffix;

                if (blendShapeNames.Contains(altSuffix))
                {
                    exists = true;
                }

                negativeIndex = mesh.GetBlendShapeIndex(negativeName);
                if (exists)
                {
                    positiveIndex = mesh.GetBlendShapeIndex(altSuffix);
                }
            }
            else
            {
                positiveIndex = mesh.GetBlendShapeIndex(blendShapeNames[i]);
            }

            blendShapeDB.Add(noSuffix,new BlendShape(positiveIndex, negativeIndex));

            if(positiveName != string.Empty)
            {
                blendShapeNames.Remove(positiveName);
            }
            if (negativeName != string.Empty)
            {
                blendShapeNames.Remove(negativeName);
            }
        }
    }
}
