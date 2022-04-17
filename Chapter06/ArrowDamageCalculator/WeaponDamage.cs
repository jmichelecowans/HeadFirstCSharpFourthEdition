namespace ArrowDamageCalculator
{
    abstract class WeaponDamage
    {
        private int _roll;

        /// <summary>
        /// The value of the current roll.
        /// </summary>
        public virtual int Roll
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
        public virtual bool Flaming
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
        public virtual bool Magic
        {
            get => _magic;
            set
            {
                _magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Initializes a new instance of the ArrowDamageCalculator.WeaponDamage class using a initial roll value.
        /// </summary>
        /// <param name="startingRoll"></param>
        public WeaponDamage(int startingRoll) => Roll = startingRoll;

        /// <summary>
        /// Returns the current calculated damage.
        /// </summary>
        public virtual int Damage { get; protected set; }

        protected abstract void CalculateDamage();
    }
}
