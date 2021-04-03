using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

	public List<Material> skins = new List<Material>();
	public List<Material> shirts = new List<Material>();

	private Material[] newOnes = new Material[3];



    public void ChangeMaterials(Renderer r, string s)
    {
    	newOnes[0] = r.materials[0];


    	int c = (int)char.GetNumericValue(s[0]);
    	newOnes[1] = shirts[c];


    	
    	//r.materials[1] = shirts[c];

    	

    	c = (int)char.GetNumericValue(s[1]);

    	newOnes[2] = skins[c];
    	//r.materials[2] = skins[c];
    	


    	r.materials = newOnes;
    }
}
