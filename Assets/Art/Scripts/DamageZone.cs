using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * This is nice, but it will only damage the character when they enter the zone. If they stay there inside it, it won’t damage them anymore. We can fix that by changing the function name from OnTriggerEnter2D to OnTriggerStay2D. This function is called every frame the Rigidbody is inside the trigger instead of just once when it enter. 
     * 
     */

    void OnTriggerEnter2D(Collider2D other) {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null) {
            controller.ChangeHealth(-1);
        }
    }
}
