using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    private List<Material> usedMaterials = new List<Material>();
    private List<Material> inCardList = new List<Material>();

    private int index = 0;
    public Material CardSelector() {
        int i = Random.Range(0, materials.Count);
        Material matHolder = materials[i];

        this.usedMaterials.Add(matHolder);
        this.inCardList.Add(matHolder);

        this.materials.Remove(matHolder);

        index++;

        return matHolder; 
    }

    public int Order() {
        return index;
    }

    private void Update() {
        if(this.index == 52) {
            this.gameObject.SetActive(false);
        }
    }

    public void ReShuffle() {

    }

}
