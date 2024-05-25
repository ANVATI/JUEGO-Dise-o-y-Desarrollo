using System.Collections;
using UnityEngine;

public class PlayerDamageEffect : MonoBehaviour
{
    public Material damageMaterial;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ApplyDamageEffect()
    {
        StartCoroutine(DamageEffectCoroutine());
    }

    IEnumerator DamageEffectCoroutine()
    {
        spriteRenderer.material = damageMaterial;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.material = null;
    }
}
