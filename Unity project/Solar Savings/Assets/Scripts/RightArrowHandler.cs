using UnityEngine;

public class RightArrowHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.GetComponent<Animator>().SetTrigger("RightArrow");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.GetComponent<Animator>().SetTrigger("LeftArrow");
        }

    }
}
