using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    public int SpiritType;
    private Animator spiritAnim;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Awake()
    {
        spiritAnim = GetComponent<Animator>();
        SpiritType = Random.Range(1, 4);
        spiritAnim.SetInteger("SpiritType", SpiritType);
    }
}
