using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public List<ForceBlock> _forceBlokcs = new List<ForceBlock>();

    public static BlockController _instance;

    public void Awake()
    {
        _instance = this;
    }

    public void BoomForce() 
    {
        foreach(ForceBlock _block in _forceBlokcs) 
        {
            _block.Boom();
        }
    }

    public void AddBlock(ForceBlock _block) 
    {
        _forceBlokcs.Add(_block);
    }
}
