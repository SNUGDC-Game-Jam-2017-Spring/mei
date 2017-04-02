using UnityEngine;

public class CatPad: MonoBehaviour
{
    public SoundPlayer player;

    public bool grounded = false;

    void Start()
    {
        Debug.Assert(player != null);
    }

    float interval = 0;
    void Update()
    {
        interval -= Time.deltaTime;
        if (grounded && interval < 0) 
        {
            interval = Random.Range(1, 2);
            player.PlayClip(SoundState.Meow);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (((col.gameObject.layer & LayerMask.NameToLayer("platform")) != 0|| col.gameObject.name == "ground"))
        {
            grounded = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (((col.gameObject.layer & LayerMask.NameToLayer("platform")) != 0 || col.gameObject.name == "ground"))
        {
            grounded = false;
        }
    }
}