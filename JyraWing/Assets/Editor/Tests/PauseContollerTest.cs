using System;
using NUnit.Framework;
using UnityEngine;


public class PauseContollerTest {
	//Test that the pause flag is set when PauseAllItems is called
	[Test]
	public void IsPausedFlag_IsSet(){
		//Arrange
		PauseController pauseController = new PauseController ();
		//Act
		PauseableItem item = NSubstitute.Substitute.For<PauseableItem>();
		pauseController.RegisterPausableItem (item);
		pauseController.PauseAllItems ();
		//Assert
		bool IsScenePaused = pauseController.IsPaused;
		Assert.That (IsScenePaused);
	}

}
