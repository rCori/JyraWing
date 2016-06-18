using UnityEngine;
using System.Collections;

public interface IPlayerShield {

	/// <summary>
	/// interface is responsible for the position of the sprite
	/// </summary>
	Vector3 spritePosition {
		get;
		set;
	}

	///<summary>
	///Return how much shield the player has as a percentage
	///</summary>
	float GetShieldPercentage();

	/// <summary>
	/// Return if shield is active. Requires the status of the player activating the shield(pressing the shield
	/// button) as a boolean argument
	/// </summary>
	bool HasShield(bool button);

	/// <summary>
	/// Update shield based on a time change presented as a float argument.
	/// Requires the status of the player activating the shield(pressing the shield button) as a boolean argument
	/// </summary>
	void UpdateShield(float timeDifference, bool button);

}
