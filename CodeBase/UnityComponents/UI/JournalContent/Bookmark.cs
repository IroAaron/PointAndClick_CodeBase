using UnityEngine;

namespace CodeBase.UnityComponents.UI.JournalContent
{
    public class Bookmark : MonoBehaviour
    {
        public PageType PageType;
        public Journal journal;

        public void GetBookmarkPageType()
        {
            journal.SlidingByBookmark(PageType);
        }
    }
}