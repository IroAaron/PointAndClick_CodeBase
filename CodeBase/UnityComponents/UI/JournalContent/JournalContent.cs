using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UnityComponents.UI.JournalContent
{
    public abstract class JournalContent : MonoBehaviour
    {
        public string Name;

        public void ActivateThis()
        {
            gameObject.SetActive(true);
        }

        public void DeactivateThis()
        {
            gameObject.SetActive(false);
        }

        public void Appearance()
        {
            gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
        }

        public void Disappearance()
        {
            gameObject.GetComponent<Image>().color = new Color(1,1,1,0);
        }

        public void ChangeSprite(Sprite sprite)
        {
            GetComponent<Image>().sprite = sprite;
        }
    }
}