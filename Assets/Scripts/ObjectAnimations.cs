using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectAnimations : MonoBehaviour
{
    [SerializeField] private float rotationDuration;
    [SerializeField] private float floatingDuration;
    [SerializeField] private float endYValue;

    private void Start() => ObjectAnimation();

    private void ObjectAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0, 360, 0), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear));
        sequence.Join(transform.DOMoveY(transform.position.y + endYValue, floatingDuration)
            .SetEase(Ease.InOutSine));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
