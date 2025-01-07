namespace MageDefence
{
    public static class DamageUtils
    {
        public static float CalculateEffectiveDamage(float damage, float armor)
        {
            return damage * (1 - armor);
        }
    }
}