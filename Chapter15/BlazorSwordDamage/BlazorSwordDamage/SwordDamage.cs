namespace BlazorSwordDamage
{
    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;
        public const decimal MAGIC_MULTIPLIER = 1.75M;

        private int _roll;

        /// <summary>
        /// The value of the current roll.
        /// </summary>
        public int Roll
        {
            get => _roll;
            set
            {
                _roll = value;
                CalculateDamage();
            }
        }

        private bool _flaming;

        /// <summary>
        /// Returns true if the calculated damage uses flaming bonus. False otherwise.
        /// </summary>
        public bool Flaming
        {
            get => _flaming;
            set
            {
                _flaming = value;
                CalculateDamage();
            }
        }

        private bool _magic;

        /// <summary>
        /// Returns true if the calculated damage uses magic multiplier. False otherwise.
        /// </summary>
        public bool Magic
        {
            get => _magic;
            set
            {
                _magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Returns the current calculated damage.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the DamageCalculatorWPF.SwordDamage class using a initial roll value.
        /// </summary>
        /// <param name="initialRoll"></param>
        public SwordDamage(int initialRoll)
        {
            Roll = initialRoll;
        }

        private void CalculateDamage()
        {
            new System.Random();
            decimal magicMultiplier = Magic ? MAGIC_MULTIPLIER : 1M;
            int flamingDamage = Flaming ? FLAME_DAMAGE : 0;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE + flamingDamage;
        }
    }
}
