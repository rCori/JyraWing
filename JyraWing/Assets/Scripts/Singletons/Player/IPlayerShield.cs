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

	bool shieldEnabled {
		get;
	}

	///<summary>
	///Return how much shield the player has as a percentage
	///</summary>
	float GetShieldPercentage();

	/// <summary>
	/// Return if shield is active.
	/// </summary>
	bool HasShield();

	/// <summary>
	/// Update shield based on a time change presented as a float argument.
	/// Requires the status of the player activating the shield(pressing the shield button) as a boolean argument
	/// </summary>
	void UpdateShield(float timeDifference);

	///<summary>
	/// Turn the shield on if the shieldPercentage allows it to be
	/// </summary>
	void ActivateShield();

	///<summary>
	/// Turn the shield off regardless of shieldPercentage value
	/// </summary>
	void DeactivateShield();

	///<summary>
	/// Enable the shield to be usable by the player
	/// </summary>
	void EnableShield();

	///<summary>
	/// Take the shield away from the player
	/// </summary>
	void DisableShield();
}
