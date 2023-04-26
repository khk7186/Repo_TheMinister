using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class TilemapAlphaTrigger : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public float duration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject obj in gameObjects)
            {
                bool notNull = obj.TryGetComponent<SpriteRenderer>(out var sprite);
                if (!notNull) return;
                Color tmp = sprite.color;
                tmp.a = 0.2f;
                sprite.DOColor(tmp, duration);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject obj in gameObjects)
            {
                bool notNull = obj.TryGetComponent<SpriteRenderer>(out var sprite);
                if (!notNull) return;
                Color tmp = sprite.color;
                tmp.a = 1f;
                sprite.DOColor(tmp, duration);
            }
        }
    }
}
