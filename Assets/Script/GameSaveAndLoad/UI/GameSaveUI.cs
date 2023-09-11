using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    public class GameSaveUI : MonoBehaviour
    {
        public SaveBlockUI saveblock;
        public List<LoadBlockUI> loadBlocks;

        public RectTransform loadBlockHolder;

        public bool FirstPage = false;
        private void SetOff()
        {
            saveblock.gameObject.SetActive(false);
            foreach (var item in loadBlocks)
            {
                item.gameObject.SetActive(false);
            }
        }
        public void Setup(List<GameSave> gameSaves)
        {
            SetOff();
            int index = 0;
            foreach (var gameSave in gameSaves)
            {
                loadBlocks[index].Setup(gameSave);
                index++;
            }
            if (FirstPage) saveblock.gameObject.SetActive(true);
        }
        public void SetupFirst()
        {
            FirstPage = true;
        }
        public void DisablePage()
        {
            gameObject.SetActive(false);
        }
    }
}