using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioSource Foot;
    [SerializeField] AudioSource jump;
    public bool w;
    bool canJump;
    bool ww = false;
    Animator anim;
    
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        if (w != ww)
        {
            PlaySFX(w,1);
        }
    }
    public void PlaySFX(bool c,int n)
    {
        if (n == 1)
        {
            if (c)
            {
                Foot.Play();
            }
            ww = w;
        }else if (n == 2)
        {
            jump.Play();
        }
    }
}
