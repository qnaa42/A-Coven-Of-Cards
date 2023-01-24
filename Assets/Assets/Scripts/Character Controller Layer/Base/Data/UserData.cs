namespace Assets.Scripts.Character_Controller_Layer.Base.Data
{
    public class UserData
    {
        public int id;

        public string playerName = "Default";

        //This is where all the data will go, from each player depended systems like character controller and such
        
        //Movement
        public float movementSpeed;
        public float stableMovementSharpness;
        public float orientationSharpness;
        
        //Charging
        public float chargeSpeed;
        public float maxChargeTime;
        public float stoppedTime;
        public float chargeCooldown;
        public bool canDoubleCharge;
        
        
        
        
        public int score;
        public int health;
        public int clones;
    }
}
