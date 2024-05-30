namespace CalorieTest
{
        public class CalorieTest
        {
            [Test]
            public void TestTotalCalories()
            {
                // Arrange
                Ingredient sugar = new Ingredient("Rice", 100, "g", 400, "Carbohydrate");
                Ingredient butter = new Ingredient("Olive Oil", 50, "g", 200, "Fat");

                Recipe recipe = new Recipe("Test Recipe");
                recipe.AddIngredient(Rice);
                recipe.AddIngredient(Olive Oil);

                // Act
                int totalCalories = recipe.GetTotalCalories();

                // Assert
                Assert.AreEqual(600, totalCalories);
            }
        }
    }