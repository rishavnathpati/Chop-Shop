using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    
    [SerializeField] private Player player;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _animator.SetBool(IsWalking, player.IsWalking());

    }
}
