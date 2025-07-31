using System;
using UnityEngine;

namespace Cobra.GUI
{
    public class PageMenu : BaseMenuPiece
    {
        [field:SerializeField, Min(0), Tooltip("Highest Priority is Initial Page")] public int Priority { get; private set; }
        
        public override void Initialize(MenuControllerDefault controller)
        {
            base.Initialize(controller);
            controller.OnPageChange += OnSwitchPage;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            parentMenuController.OnPageChange -= OnSwitchPage;
        }

        private void OnSwitchPage(PageMenu newPage)
        {
            if (newPage == this)
            {
                OnOpen();
            }
            else
            {
                OnClose();
            }
        }

        public void Open()
        {
            parentMenuController.GoTo(this);
        }

        private void OnOpen()
        {
            gameObject.SetActive(true);
        }

        private void OnClose()
        {
            gameObject.SetActive(false);
        }
    }
}