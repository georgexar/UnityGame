using System.Linq;
using UnityEngine;

public class KingsDeathInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText = "Pick up King's Crown";

    [SerializeField] private GameObject returnFromBossPortal;

    private bool isInteractable = true;
    public string InteractionText => interactText;
    public bool IsInteractable => isInteractable;
    public bool TalkToPlayer => false;

    [SerializeField] private GameObject kingsCrown;
    
    


    public void Interact()
    {
        if (isInteractable)
        {
            if (GameManager.Instance.Player==null)return;
            
            kingsCrown.SetActive(false);

            Transform crown = GameManager.Instance.Player.playerObject
                .GetComponentsInChildren<Transform>(true) 
                .FirstOrDefault(t => t.name == "PlayerCrown");

           
            if (crown != null)
            {
                crown.gameObject.SetActive(true);
            }

            returnFromBossPortal.SetActive(true);

            isInteractable =false;

        }
    }
}
