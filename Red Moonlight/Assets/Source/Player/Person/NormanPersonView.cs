using Data;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NormanPersonView : AItemContainerView<PersonView, NPCSO>
{
  public override void ShowDetails(NPCSO u)
  {
    DetailsText.text = $" Название: {u.NPCName} \nnОписание: {u.NPCDetails}";
    if (u.Image != null && DetailsImage != null)
    {
      DetailsImage.sprite = u.Image;
      DetailsImage.gameObject.SetActive(true);
    }
    else
    {
      DetailsImage.gameObject.SetActive(false);
    }
  }
}
