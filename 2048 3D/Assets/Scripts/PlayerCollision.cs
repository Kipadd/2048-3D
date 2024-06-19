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
    public MeshRenderer _meshRenderer;
    public Material[] materials;
    public int currentMaterialIndex = 0;

    private void Start()
    {
        partic.stars = GetComponent<ParticleSystem>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        PlayerCollision playerCollision = col.gameObject.GetComponent<PlayerCollision>();
        if (playerCollision != null && playerCollision.currentMaterialIndex == currentMaterialIndex)
        {
            partic.stars.Play();
            currentMaterialIndex++;

            // ѕерев≥рка, чи currentMaterialIndex в межах масиву materials
            if (currentMaterialIndex < materials.Length)
            {
                _meshRenderer.material = materials[currentMaterialIndex];
            }
            else
            {
                // якщо ≥ндекс виходить за меж≥ масиву, можна зробити щось ≥нше (наприклад, встановити останн≥й матер≥ал)
                _meshRenderer.material = materials[materials.Length - 1];
                // јбо залишити поточний матер≥ал без зм≥н
            }

            Destroy(col.gameObject);
            ScoreCounter.instance.currentScoreNumber += (int)System.Math.Pow(2, currentMaterialIndex) / 2;
            if (ScoreCounter.instance.current2048Number <= (int)System.Math.Pow(2, currentMaterialIndex + 1))
            {
                ScoreCounter.instance.current2048Number = (int)System.Math.Pow(2, currentMaterialIndex + 1);
            }
        }
    }
}
