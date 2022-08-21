namespace DelegateWithObjectsExample
{
    class Harper
    {
        private int _total = 20;

        public GetSecretIngredient HarpersSecretIngredientMethod => AddHarpersSecretIngredient;
        
        private string AddHarpersSecretIngredient(int amount)
        {
            if (amount > 0 && _total - amount < 0)
            {
                return $"I don't have {amount} cans of sardines!";
            }
            else
            {
                _total -= amount;
                return $"{amount} cans of sardines";
            }
        }
    }
}
