using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UnityComponents.UI.JournalContent
{
    public enum PageType
    {
        Note,
        Photo,
        Card
    }
    public class Page : MonoBehaviour
    {
        public PageType PageType;
        public GameObject BookmarksGroup;
        public Sprite PageSprite;
        public List<JournalContent> JournalContent;

        public void ActivatePage()
        {
            gameObject.SetActive(true);
            BookmarksGroup.SetActive(true);
            
            foreach (var content in JournalContent)
            {
                content.Appearance();
            }
        }

        public void DeactivatePage()
        {
            gameObject.SetActive(false);
            BookmarksGroup.SetActive(false);
            
            foreach (var content in JournalContent)
            {
                content.Disappearance();
            }
        }
    }
}