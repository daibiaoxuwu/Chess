using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour {
	// Use this for initialization
	public void CombineMeshes () {

        Quaternion oldrot = transform.rotation;
        Vector3 oldpos = transform.position;
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        Mesh finalMesh = new Mesh();

        CombineInstance[] combineInstances = new CombineInstance[filters.Length];
        for(int a=0;a<filters.Length;++a){
            if (filters[a].transform == transform) continue;
            combineInstances[a].subMeshIndex = 0;
            combineInstances[a].mesh = filters[a].sharedMesh;
            combineInstances[a].transform = filters[a].transform.localToWorldMatrix;

        }
        finalMesh.CombineMeshes(combineInstances);
        GetComponent<MeshFilter>().sharedMesh = finalMesh;
		Debug.Log("combine" + filters.Length);

        transform.rotation = oldrot;
        transform.position = oldpos;

        for(int a=0;a<transform.childCount;a++){
            transform.GetChild(a).gameObject.SetActive(true);
        }
    }
}
