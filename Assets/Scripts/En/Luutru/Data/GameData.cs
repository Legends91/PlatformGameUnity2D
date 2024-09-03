using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int deathCount;
    public Vector3 targetPosition;
    public SerializableDictionary<string, bool> coinsCollected;
    public AttributesData playerAttributesData;

    public GameData() 
    {
        this.deathCount = 0;

        coinsCollected = new SerializableDictionary<string, bool>();
      //  playerAttributesData = new AttributesData();
    }

    public int GetPercentageComplete() 
    {
        int totalCollected = 0;
        foreach (bool collected in coinsCollected.Values) 
        {
            if (collected) 
            {
                totalCollected++;
            }
        }

        int percentageCompleted = -1;
        if (coinsCollected.Count != 0) 
        {
            percentageCompleted = (totalCollected * 100 / coinsCollected.Count);
        }
        return percentageCompleted;
    }
}
