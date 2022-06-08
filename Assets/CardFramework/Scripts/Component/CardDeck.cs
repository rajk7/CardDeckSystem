using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardDeck : MonoBehaviour 
{
	[SerializeField]
	private GameObject _cardPrefab;	
	
	public readonly List<Card> CardList =  new List<Card>();							

	public void InstanatiateDeck(string cardBundlePath)
	{
		AssetBundle cardBundle = BundleSingleton.Instance.LoadBundle(DirectoryUtility.ExternalAssets() + cardBundlePath);
		string[] nameArray = cardBundle.GetAllAssetNames();
				
		for (int i = 0; i < nameArray.Length; ++i)
		{
			GameObject cardInstance = (GameObject)Instantiate(_cardPrefab);
			Card card = cardInstance.GetComponent<Card>();
			card.gameObject.name = Path.GetFileNameWithoutExtension(nameArray[ i ]);
			card.TexturePath = nameArray[ i ];
			card.SourceAssetBundlePath = cardBundlePath;
			card.transform.position = new Vector3(0, 10, 0);
			card.FaceValue = StringToFaceValue(card.gameObject.name);
			CardList.Add(card);
		}
	}
	
	private int StringToFaceValue(string input)
	{
		for (int i = 2; i < 11; ++i)
		{
			if (input.Contains(i.ToString()))
			{
				return i;
			}
		}
		if (input.Contains("jack") ||
		    input.Contains("queen") ||
		    input.Contains("king"))
		{
			return 10;
		}
		if (input.Contains("ace"))
		{
			return 11;
		}
		return 0;
	}

	public Text AddedCard;
	public Card AddRandomCard(List<Card> listToRandomize)
	{
		int randomNum = Random.Range(0, listToRandomize.Count);
		//print(randomNum);
		Card printRandom = listToRandomize[randomNum];
		CardList.Add(printRandom);
		Debug.Log("Added Card :-" + printRandom);
		AddedCard.text = printRandom.ToString();

		//print(printRandom);
		return printRandom;
	}

	public void AddCardButton()
	{
		AddRandomCard(CardList);
	}

	public Text RemovedCard;
	public Card RemoveRandomCard(List<Card> listToRandomize)
	{
		int randomNum = Random.Range(0, listToRandomize.Count);
		//print(randomNum);
		Card printRandom = listToRandomize[randomNum];
		CardList.Remove(printRandom);
		Debug.Log("removed :-" + printRandom);
		RemovedCard.text = printRandom.ToString();
		//print(printRandom);
		return printRandom;
	}

	public void RemoveCardButton()
	{
		RemoveRandomCard(CardList);
	}
}
