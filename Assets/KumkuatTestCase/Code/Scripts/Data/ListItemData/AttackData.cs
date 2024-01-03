using System;

[Serializable]
public class AttackData : ListItemData
{
        #region Home-Team-Details

        public PlayerData HomePlayer;
        public PlayerData HomeSupport;
        public PlayerData[] HomeAssists;
        public int[] HomeScores;

        #endregion
        
        #region Away-Team-Details
        
        public PlayerData AwayPlayer;
        public PlayerData AwaySupport;
        public PlayerData[] AwayAssists;
        public int[] AwayScores;
        
        #endregion
}