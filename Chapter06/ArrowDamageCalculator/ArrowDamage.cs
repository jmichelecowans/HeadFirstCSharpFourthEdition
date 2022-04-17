namespace ArrowDamageCalculator
{
    class ArrowDamage : WeaponDamage
    {
        public const decimal BASE_MULTIPLIER = 0.35M;
        public const decimal FLAME_DAMAGE = 1.25M;
        public const decimal MAGIC_MULTIPLIER = 2.75M;

        /// <summary>
        /// Initializes a new instance of the ArrowDamageCalculator.ArrowDamage class using a initial roll value.
        /// </summary>
        /// <param name="startingRoll"></param>
        public ArrowDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            Damage = (int)System.Math.Ceiling(Flaming ? baseDamage + FLAME_DAMAGE : baseDamage);
        }
    }
}
