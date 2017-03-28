using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.IO;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour {

    public Text displayText;
    public GameObject canvas;
    private List<string> messageList; 
    private List<GameObject> imageList;

    private int currentScene;
    private int sceneCount;
    private GameObject currentImage;

    [System.Serializable]
    public struct MessageWrapper {
        public string messageWrapper;
    }
    
    [System.Serializable]
    public struct EndingMessage {
        public string[] messages;
    }

	// Use this for initialization
	void Start () {
        currentScene = 0;
        sceneCount = 3;
        messageList = LoadMesagesFromJson(sceneCount);
        imageList = LoadOrderedGameObjectsFromResources("CreditsImages", "EndImage",sceneCount);
        currentScene = AdvanceScene(currentScene, sceneCount);
	}
	
	// Update is called once per frame
	void Update () {
	    if(ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown()) {
            if(currentScene < sceneCount) {
                currentScene = AdvanceScene(currentScene, sceneCount);
            } else {
                SceneManager.LoadScene("titleScene");
            }
        }
	}

    private List<string> LoadMesagesFromJson(int count) {
        List<string> returnMessageList = new List<string>();

        FileStream saveFile = File.Open (Application.dataPath + "/EndingMessages.json", System.IO.FileMode.Open);
		StreamReader reader = new StreamReader (saveFile);
		EndingMessage loadedMessages = JsonUtility.FromJson<EndingMessage> (reader.ReadToEnd ());
        saveFile.Close();
        foreach(string loadedMessage in loadedMessages.messages) {
            returnMessageList.Add(loadedMessage);
        }
        return returnMessageList;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Image"></typeparam>
    /// <param name=""></param>
    /// <param name="director"></param>
    /// <param name="imageName"></param>
    private List<GameObject> LoadOrderedGameObjectsFromResources(string directory, string imageName, int count) {
        List<GameObject> gameObjectList = new List<GameObject>();
        for(int i = 0; i<count; i++) {
            GameObject nextObject = (GameObject)Resources.Load(directory + "\\" + imageName + i.ToString()) as GameObject;
            gameObjectList.Add(nextObject);
        }
        return gameObjectList;
    }

    private int AdvanceScene(int current, int end) {
        Assert.IsFalse(current == end);
        
        AdvanceImage(current, imageList);
        AdvanceText(displayText, current, messageList);
        current++;
        return current;
    }

    private void AdvanceImage(int current, List<GameObject> objectList) {
        if(current != 0) {
            Destroy(currentImage);
        }
        currentImage = Instantiate(objectList[current]);
        currentImage.transform.SetParent(canvas.transform, false);
    }

    private void AdvanceText(Text display, int current, List<string> messageList) {
        Assert.IsTrue(current < messageList.Count);
        display.text = messageList[current];
    }
}
