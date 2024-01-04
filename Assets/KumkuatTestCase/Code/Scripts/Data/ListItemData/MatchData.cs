using System;

[Serializable]
public class MatchData : ListItemData
{
        public TeamData HomeTeam;
        public TeamData AwayTeam;
        public string MatchTime = "22:00";
        public string MatchDate = "03/01";
        public Enums.MatchType MatchType = Enums.MatchType.League;
        public AttackData[] AttackList;
}