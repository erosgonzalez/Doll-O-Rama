using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBones : MonoBehaviour
{
    public SkinnedMeshRenderer modelMesh;
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, Transform> bones = new Dictionary<string, Transform>();

        foreach (Transform bone in modelMesh.bones){
            bones[bone.gameObject.name] = bone;
        }

        SkinnedMeshRenderer renderer = gameObject.GetComponent<SkinnedMeshRenderer>();

        Transform[] newBones = new Transform[renderer.bones.Length];

        for (int i = 0; i < renderer.bones.Length; ++i)
        {
            GameObject bone = renderer.bones[i].gameObject;

            if(!bones.TryGetValue(bone.name, out newBones[i]))
            {
                Debug.Log("Unable to map bone \"" + bone.name + "\" to target skeleton.");
                break;
            }
        }

        renderer.bones = newBones;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
