namespace DelegateWithObjectsExample
{
    class Adrian
    {
        public GetSecretIngredient MySecretIngredientMethod => AddAdriansSecretIngredient;

        private string AddAdriansSecretIngredient(int amount) => $"{amount} ounces of cloves";
    }
}
