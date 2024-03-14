using System.Collections.Generic;
using CodeBase.Logic;
using CodeBase.UnityComponents.UI.JournalContent;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UnityComponents.UI
{
    public class Journal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IUIObject
    {
        private GameplayCanvas _gameplayCanvas;

        [Header("Journal Animation")]
        public float OpenOffsetY;
        private float _сlosePositionY;
        public float AnimationDuration;
        public Ease animEase;

        private FadingScreen _fadeScreen;

        private bool _isCursorAimedJournal;
        
        [Header("Journal Content")]
        public Button RightPage;
        public Button LeftPage;

        public List<GameObject> Bookmarks;
        public List<Page> Pages;
        private int _currentPage;

        public static bool IsJournalOpen { get; private set; }
        
        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && IsJournalOpen)
            {
                if (_isCursorAimedJournal == false)
                {
                    CloseJournal();
                }
            }
        }

        public void Inject(GameplayCanvas gameplayCanvas)
        {
            _gameplayCanvas = gameplayCanvas;

            _сlosePositionY = transform.position.y;
            _fadeScreen = _gameplayCanvas.FadeScreen;
            
            Pages[_currentPage].ActivatePage();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isCursorAimedJournal = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isCursorAimedJournal = false;
        }

        public void OpenJournal()
        {
            SetAnimation(_сlosePositionY + OpenOffsetY, true);
            _fadeScreen.Show();

            Debug.Log("JournalOpen");
        }

        public void CloseJournal()
        {
            SetAnimation(_сlosePositionY, false);
            _fadeScreen.Hide();

            Debug.Log("JournalClose");
        }

        private void SlidingJournalRight()
        {
            Pages[_currentPage].DeactivatePage();
            
            _currentPage++;
            if (_currentPage >= Pages.Count)
            {
                _currentPage = 0;
            }
            
            Pages[_currentPage].ActivatePage();
            if (Pages[_currentPage].PageSprite != null)
            {
                GetComponent<Image>().sprite = Pages[_currentPage].PageSprite;
            }
        }

        private void SlidingJournalLeft()
        {
            Pages[_currentPage].DeactivatePage();
            
            _currentPage--;
            if (_currentPage < 0)
            {
                _currentPage = Pages.Count - 1;
            }
            
            Pages[_currentPage].ActivatePage();
            if (Pages[_currentPage].PageSprite != null)
            {
                GetComponent<Image>().sprite = Pages[_currentPage].PageSprite;
            }
        }

        public void SlidingByBookmark(PageType pageType)
        {
            int pageCounter = 0;
            Pages[_currentPage].DeactivatePage();
            
            foreach (var page in Pages)
            {
                pageCounter++;
                if (page.PageType == pageType)
                {
                    page.ActivatePage();
                    
                    if (page.PageSprite != null)
                    {
                        GetComponent<Image>().sprite = page.PageSprite;
                    }
                    
                    _currentPage = pageCounter - 1;
                    break;
                }
            }
        }

        private void SetAnimation(float endAnimatioValue, bool isJournalOpen)
        {
            transform.DOMoveY(endAnimatioValue, AnimationDuration).SetEase(animEase);
            
            IsJournalOpen = isJournalOpen;

            _gameplayCanvas.OpenJournal.enabled = !isJournalOpen;
        }
    }
}