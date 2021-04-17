using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TimeScore : MonoBehaviour
{
	private int timeScore = 0;
	private int maxScore = 60;
	private int totalTime = 60;
	private Coroutine timeTracker;

	public int TimScore => timeScore;

	private void OnEnable()
	{
		BombsAndGoblinsTracker.Instance.CollectedAllGoblins += OnCollectedAllGoblins;
	}

	private void OnDisable()
	{
		BombsAndGoblinsTracker.Instance.CollectedAllGoblins -= OnCollectedAllGoblins;
	}

	private void Start()
	{
		timeScore = maxScore;
		timeTracker = StartCoroutine(RemoveScorePerSecond());
	}
	private IEnumerator RemoveScorePerSecond()
	{
		for (int i = 0; i < totalTime; i++)
		{
			timeScore -= 1;
			yield return new WaitForSeconds(1);
		}
	}

	private void OnCollectedAllGoblins()
	{
		StopCoroutine(timeTracker);

		Score.Instance.Add(Mathf.Clamp(timeScore, 0, maxScore));
	}

}
