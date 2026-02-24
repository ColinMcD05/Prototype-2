using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    private float macGuffinHeld = 0;
    [SerializeField] private float macGuffinsNeeded;

    private void OnTriggerEnter(Collider other)
    {
        //Once the player collides with the Macguffin, delete Macguffin and update held macguffin counter
        if (other.CompareTag("MacGuffin"))
        {
            Debug.Log("MacGuffin Collected.");
            macGuffinHeld++;
            Destroy(other.gameObject);
        }
        //Once the player collides with the end game volume and has enough macguffin's, win the game.
        if (other.CompareTag("EndGameVolume") && (macGuffinHeld == macGuffinsNeeded))
        {
            Debug.Log("You win!");
        }else if (other.CompareTag("EndGameVolume")&& (macGuffinHeld != macGuffinsNeeded))
        {
            Debug.Log("Not Enough macguffins");
        }

    //use later to win the game.
    }
    private void winGame()
    {

    }
}
