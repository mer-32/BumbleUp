using System;
using Content.CodeBase.Infrastructure.Services;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Components
{
    public abstract class BaseMovement : MonoBehaviour
    {
        protected IPlatformsFactory platformsFactory;
        protected IInputService inputService;

        protected float jumpForwardCount = 0;
        protected Vector3 nextPos;

        protected Sequence jumpTweener;

        public Action Falled { get; set; }

        [Inject]
        private void Construct(IInputService inputService, IPlatformsFactory platformsFactory)
        {
            this.inputService = inputService;
            this.platformsFactory = platformsFactory;
        }

        public virtual void Init()
        {
            nextPos = transform.position;
        }

        protected virtual void Jump(Vector3 endPos, float power = 3f, float duration = 0.8f, Action jumpComplete = null)
        {
            jumpTweener?.Kill();
            jumpTweener = transform.DOJump(endPos, power, 1, duration)
                .OnComplete(() => jumpComplete?.Invoke());
        }

        protected virtual void OnDestroy() => jumpTweener?.Kill();

        protected virtual void Fall() => Falled?.Invoke();
    }
}