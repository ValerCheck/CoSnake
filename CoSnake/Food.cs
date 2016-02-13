namespace CoSnake
{
    public class Food
    {
        private FoodCategory _category;

        public FoodCategory Category
        {
            get { return _category; }
        }

        public Food(FoodCategory category)
        {
            _category = category;
        }
    }
}
