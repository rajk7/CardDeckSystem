using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DealerUI : MonoBehaviour
{
	private Dealer _dealer;

	public Text FaceValueText { get { return _faceValueText; } }
	[SerializeField]
	private Text _faceValueText;

	private void Awake()
	{
		_dealer = GameObject.Find("Dealer").GetComponent<Dealer>();
		_dealer.DealerUIInstance = this;
	}

	public void Shuffle()
	{
		if (_dealer.DealInProgress == 0)
		{
			StartCoroutine(_dealer.ShuffleCoroutine());
		}
	}

	public void Draw()
	{
		if (_dealer.DealInProgress == 0)
		{
			StartCoroutine(_dealer.DrawCoroutine());
		}
	}

	[SerializeField]
	private GameObject topCardButton;
	public void TopMostCard()
	{
		TopCardBackButton.SetActive(true);
		topCardButton.SetActive(false);

		if (_dealer.DealInProgress == 0)
		{
			StartCoroutine(_dealer.DrawTopCard());
		}
	}

	[SerializeField]
	private GameObject TopCardBackButton;
	public void BackTopMost()
	{
		TopCardBackButton.SetActive(false);
		topCardButton.SetActive(true);

		if (_dealer.DealInProgress == 0)
		{
			StartCoroutine(_dealer.DrawTopBack());
		}
	}

	[SerializeField]
	private CardDeck _cardDeck;
	public void StartAddButton()
	{
		_cardDeck.InstanatiateDeck("cards");
		//StartCoroutine(StackCardRangeOnSlot(0, _cardDeck.CardList.Count, _stackCardSlot));
	}

}