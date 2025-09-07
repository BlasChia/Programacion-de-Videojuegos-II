using UnityEngine;

public class ObjetoComida : ObjetoCelda
{
    public override void PlayerEntered()
    {
        Destroy(gameObject);

        //increase food
        Debug.Log("Food increased");
    }
}
