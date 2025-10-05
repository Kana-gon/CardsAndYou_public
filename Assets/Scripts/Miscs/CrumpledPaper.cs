using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrumpledPaper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject dropCard;
    [SerializeField] private Animator animator;
    void OnMouseEnter()
    {
        animator.Play("clamp_open");
    }
    void GenerateCard()
    {
        var _dropCard = Instantiate(dropCard, GameObject.Find("Cards").transform);
        _dropCard.transform.position = transform.position;
        Destroy(gameObject);
    }
    public void MovePaper(Vector3 target, float duration)
    {
        transform.DOMove(target, duration).SetEase(Ease.OutQuart);
    }
}
