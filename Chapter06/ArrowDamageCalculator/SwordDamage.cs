namespace ArrowDamageCalculator
{
    class SwordDamage : WeaponDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;
        public const decimal MAGIC_MULTIPLIER = 1.75M;

        /// <summary>
        /// Initializes a new instance of the ArrowDamageCalculator.SwordDamage class using a initial roll value.
        /// </summary>
        /// <param name="startingRoll"></param>
        public SwordDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            new System.Random();
            decimal magicMultiplier = Magic ? MAGIC_MULTIPLIER : 1M;
            int flamingDamage = Flaming ? FLAME_DAMAGE : 0;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE + flamingDamage;
        }
    }
}
