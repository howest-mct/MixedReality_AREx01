
using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
   
   public UIDocument mainScreen;

   private Button button;
   
   private void OnEnable()
   {
      button = mainScreen.rootVisualElement.Q<Button>("GoButton");
      button.clickable.clicked += this.Go;
   }

   private void OnDisable()
   {
      button.clickable.clicked -= this.Go;
   }

   private void Go()
   {
      GameManager.Go();
   }
   
}
