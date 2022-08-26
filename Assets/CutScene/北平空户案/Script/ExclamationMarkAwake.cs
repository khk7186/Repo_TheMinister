using System.Collections;
using UnityEngine;

namespace Assets.CutScene.北平空户案.Script
{
    public class ExclamationMarkAwake : MonoBehaviour
    {

        public float yChange = 0;

        private void Awake()
        {
            Transform player;
            player = FindObjectOfType<Player>().transform;
            var target = ExclamationMark.SpawnExclamationMark(player, yChange);
            Destroy(target, 0.5f);
        }
    }
}