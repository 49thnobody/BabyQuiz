using DG.Tweening;
using UnityEngine;

namespace GameLoop
{
    public class CellAnimator : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _cellSprite;

        [SerializeField]
        private SpriteRenderer _optionSprite;

        [SerializeField]
        private ParticleSystem _stars;

        public void AnimateAnswer(bool isCorrect)
        {
            if(isCorrect)
            {
                Bounce(_optionSprite.transform);
                _stars.Play();
            }
            else
            {
                EaseOnBounce(_optionSprite.transform);
            }
        }

        public void AnimateApearingDisapearing(bool apearing)
        {
            if(apearing)
            {
                Bounce(_cellSprite.transform);
            }
            else
            {
                _cellSprite.transform.DOScale(0f, 1f).onComplete = () => Destroy(gameObject);
            }
        }

        private void Bounce(Transform target)
        {
            float startingScale = target.localScale.x;

            DOTween.Sequence()
                .Append(target.DOScale(startingScale + .1f, .45f))
                .Append(target.DOScale(startingScale - .1f, .15f))
                .Append(target.DOScale(startingScale, .1f));
        }

        private void EaseOnBounce(Transform transform)
        {
            var startPosition = transform.localPosition;

            DOTween.Sequence()
                     .Append(transform.DOLocalMoveX(startPosition.x - Random.Range(0, .3f), .1f))
                     .Append(transform.DOLocalMoveX(startPosition.x + Random.Range(0, .3f), .1f))
                     .Append(transform.DOLocalMoveX(startPosition.x - Random.Range(0, .3f), .1f))
                     .Append(transform.DOLocalMoveX(startPosition.x, .1f));
        }
    }
}