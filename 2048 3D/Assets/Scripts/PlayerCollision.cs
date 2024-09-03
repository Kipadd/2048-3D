using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParticleEffect
{
    public ParticleSystem stars;
}

public class PlayerCollision : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private MeshRenderer _meshRenderer;
    public Material[] materials;
    public int currentMaterialIndex = 0;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        PlayerCollision otherPlayer = col.gameObject.GetComponent<PlayerCollision>();
        if (otherPlayer != null && otherPlayer.currentMaterialIndex == currentMaterialIndex)
        {
            _particleSystem.Play();
            currentMaterialIndex++;

            if (currentMaterialIndex < materials.Length)
            {
                _meshRenderer.material = materials[currentMaterialIndex];
            }
            else
            {
                _meshRenderer.material = materials[materials.Length - 1]; 
            }

            Destroy(col.gameObject);

            ScoreCounter.Instance.UpdateScore(currentMaterialIndex);
        }
    }
}
