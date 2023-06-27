namespace Player
{
    public class PlayerInformation
    {
        public int PlayerOutfitNumber = 0;
        public string PlayerName = "Player";
        public int PlayerLevel = 1;
        public int CurrencyAmount = 1;
        public int CurrentExperience = 0;
        private int _defaultExperienceLevel = 200;
        public int ExperienceRequired
        {
            get => GetExperienceRequired();
        }

        public void ChangePlayerName(string playerName)
        {
            PlayerName = playerName;
        }
        
        private int GetExperienceRequired()
        {
            return _defaultExperienceLevel * PlayerLevel;
        }
    }
}