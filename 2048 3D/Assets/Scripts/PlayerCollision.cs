using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Partic
{
    public ParticleSystem stars;
}
public class PlayerCollision : MonoBehaviour
{
    public Partic partic;
    public Material[] materials;
    public int currentMaterialIndex = 0;

    private void Start()
    {
        partic.stars = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision col)
    {
        PlayerCollision playerCollision = col.gameObject.GetComponent<PlayerCollision>();
        if (playerCollision != null && playerCollision.currentMaterialIndex == currentMaterialIndex)
        { 
            partic.stars.Play();
            currentMaterialIndex++;
            GetComponent<MeshRenderer>().material = materials[currentMaterialIndex];
            Destroy(col.gameObject);
            ScoreCounter.instance.cS_str += (int)System.Math.Pow(2,currentMaterialIndex)/2;
            //ScoreCounter.instance.c2_str = (int)System.Math.Pow(2, currentMaterialIndex + 1);
            if(ScoreCounter.instance.c2_str <= (int)System.Math.Pow(2, currentMaterialIndex + 1))
            {
                ScoreCounter.instance.c2_str = (int)System.Math.Pow(2, currentMaterialIndex + 1);
            }
            
        }
        
    }
}
