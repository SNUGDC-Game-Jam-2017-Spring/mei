using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollider : MonoBehaviour
{
    void Update()
    {
        var rb = GetComponent<Rigidbody2D>();
        var yAxisVelocity = rb.velocity.y;

        if (yAxisVelocity > 0)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("cat"), LayerMask.NameToLayer("platForm"), true);
            CatJumper.standing = yAxisVelocity;
        }
        else if (yAxisVelocity == 0)
        {
            CatJumper.standing = 0;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("cat"), LayerMask.NameToLayer("platForm"), false);
            CatJumper.standing = -yAxisVelocity;
        }

    }
}
