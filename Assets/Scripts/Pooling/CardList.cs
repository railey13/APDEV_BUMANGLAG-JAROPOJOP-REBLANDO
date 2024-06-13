using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardList : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private List<Material> usedMaterials = new List<Material>();
    [SerializeField] private List<Material> inCardList = new List<Material>();

    private int index = 0;

    public int inCardListNum {
        get { return this.inCardList.Count;  }
    }
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
            this.materials.Clear();
        }
    }

    public void ReShuffle() {
        for(int i = 0; i < this.inCardList.Count; i++) {
            this.materials.Add(this.inCardList[i]);
        }
        this.inCardList.Clear();
        this.usedMaterials.Clear();

        this.gameObject.SetActive(true);

        index = 0;
    }

}
