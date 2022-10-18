using System.Collections;
using UnityEngine;

namespace Assets.CutScene.北平空户案.Script
{
    public class ExclamationMarkSpawner : MonoBehaviour
    {
        public ExclamationMarkSbject pref;
        public float yChange = 5;
        public Transform TargetCharacter;
        public bool MainCharacter = false;
        public bool Red = false;
        public bool SpawnOnEnable= false;
        public bool DestroyAfterUse = false;
        public void Spawn()
        {
            if (MainCharacter)
            {
                TargetCharacter = FindObjectOfType<Player>().transform;
            }
            if (TargetCharacter == null)
            {
                TargetCharacter = GetComponentInParent<Transform>();
            }
            var target =Instantiate(pref,TargetCharacter);
            target.transform.localPosition = new Vector3(0f, yChange, 0f);
            if (Red) target.ActiveRed();
            if (DestroyAfterUse) target.destroyOnHide = true;
            target.gameObject.SetActive(true);
        }
        private void OnEnable()
        {
            if (SpawnOnEnable) Spawn();
        }
    }
}