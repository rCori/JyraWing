//Interface for an item in the game that can be paused or unpaused.

public interface PauseableItem  {

	//property signature of getting and setting paused state
	bool paused {
		get;
		set;
	}

	///<summary>
	/// Add to the list in the GameController of items that can be paused
	///Should be called as soon as the object is created.
	/// </summary>
	void RegisterToList();

	///<summary>
	/// Remove yourself from the pause list
	/// It will be the owners responsibility to call this
	/// otheriwse we will get a null pointer probably.
	///</summary>
	void RemoveFromList();
}
