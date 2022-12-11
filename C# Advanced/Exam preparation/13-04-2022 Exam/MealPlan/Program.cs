using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mealsEaten = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var caloriesPerDay = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var numberOfMeals = 0;

            var mealsQueue = new Queue<string>(mealsEaten);
            var caloriesStack = new Stack<int>(caloriesPerDay);

            while (mealsQueue.Any() && caloriesStack.Any())
            {
                var meal = mealsQueue.Peek();
                var calories = caloriesStack.Peek();
                var mealCalories = GetMealCalories(meal);
                var remainingCalories = calories - mealCalories;
                UpdateMeals(mealsQueue, ref numberOfMeals);
                if (remainingCalories > 0)
                {
                    caloriesStack = UpdateCalories(caloriesStack, remainingCalories);
                    continue;
                }

                caloriesStack.Pop();

                if (remainingCalories == 0) continue;

                if (!caloriesStack.Any()) break;

                var newCalories = caloriesStack.Peek() - Math.Abs(remainingCalories);
                caloriesStack = UpdateCalories(caloriesStack, newCalories);
            }

            var firstLineOutput = string.Empty;
            var secondLineOutput = string.Empty;

            if (!mealsQueue.Any())
            {
                firstLineOutput = $"John had {numberOfMeals} meals.";
                var caloriesString = string.Join(", ", caloriesStack);
                secondLineOutput = $"For the next few days, he can eat {caloriesString} calories.";
            }
            else
            {
                firstLineOutput = $"John ate enough, he had {numberOfMeals} meals.";
                var mealsString = string.Join(", ", mealsQueue);
                secondLineOutput = $"Meals left: {mealsString}.";
            }

            Console.WriteLine(firstLineOutput);
            Console.WriteLine(secondLineOutput);
        }

        private static Stack<int> UpdateCalories(Stack<int> caloriesStack, int newCalories)
        {
            var caloriesArray = caloriesStack.ToArray();
            caloriesArray[0] = newCalories;
            return new Stack<int>(caloriesArray.Reverse());
        }

        private static void UpdateMeals(Queue<string> mealsQueue, ref int numberOfMeals)
        {
            mealsQueue.Dequeue();
            numberOfMeals++;
        }

        private static int GetMealCalories(string meal)
        {
            meal = meal.ToLower();
            switch (meal)
            {
                case "salad": return 350;
                case "soup": return 490;
                case "pasta": return 680;
                default: return 790;
            }
        }
    }
}
