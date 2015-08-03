using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
public class ShuffleBag{

	//private Random random = new Random();
	private List<int> data;
	
	private int currentItem;
	private int currentPosition = -1;
	
	private int Capacity { get { return data.Capacity; } }
	public int Size { get { return data.Count; } }
	
	public ShuffleBag(int initCapacity)
	{
		data = new List<int>(initCapacity);
	}

	public void Add(int item, int amount)
	{
		for (int i = 0; i < amount; i++)
			data.Add(item);
		
		currentPosition = Size - 1;
	}


	public int Next()
	{
		if (currentPosition < 1)
		{
			currentPosition = Size - 1;
			currentItem = data[0];
			
			return currentItem;
		}
		
		int pos = Random.Range(0, currentPosition);
		
		currentItem = data[pos];
		data[pos] = data[currentPosition];
		data[currentPosition] = currentItem;
		currentPosition--;
		
		return currentItem;
	}
}
