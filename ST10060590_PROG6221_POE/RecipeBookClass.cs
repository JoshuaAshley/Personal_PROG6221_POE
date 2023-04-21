//uses the DataValidation namespace to allow for the use of the classes and methods that are contained within
using DataValidation;

//namespace created to hold all the classes and methods of the Recipe Book
namespace RecipeBook
{
    //class of Ingredient to manage Ingredient variables
    public class Ingredient
    {
        //private variable declaration
        private string _ingredientName;

        //variable properties such as get set methods
        public string IngredientName { get { return _ingredientName; } set { _ingredientName = value; } }

        //private variable declaration
        private float _quantity;

        //variable properties such as get set methods
        public float Quantity { get { return _quantity; } set { _quantity = value; } }

        //private variable declaration
        private string _measurement;

        //variable properties such as get set methods
        public string Measurement { get { return _measurement; } set { _measurement = value; } }

        //parameterized constructor to initialize the variables to the values of the parameters
        public Ingredient(string ingredientName, float quantity, string measurement)
        {
            _ingredientName = ingredientName;
            _quantity = quantity;
            _measurement = measurement;
        }

        //Display method that writes a neat format of the ingredient details as a string
        public string DisplayIngredients()
        {
            //the bullet point special character will be handled with later in the code
            string output = "• ";
            output += _quantity + " " + _measurement + " of " + _ingredientName;
            return output;
        }
    }

    //class of Method to manage instructions variables
    public class Method
    {
        //private variable declaration
        private string _description;

        //variable properties such as get set methods
        public string Description { get { return _description; } set { _description = value; } }

        //parameterized constructor to initialize the variables to the values of the parameters
        public Method(string description)
        {
            _description = description;
        }

        //Display method that writes a neat format of the ingredient details as a string
        public string DisplayStep(int stepNumber)
        {
            //the bullet point special character will be handled with later in the code
            return "• Step " + stepNumber + ": " + _description;
        }
    }

    //class of Recipe to manage all the recipe variables and objects of other classes
    public class Recipe
    {
        //public variable declarations
        public string recipeName;
        public int numIngredients;
        public Ingredient[] ingredients;
        public int numMethodSteps;
        public Method[] steps;
        public float scaleUpAmount;
        public float scaleDownAmount;
        public Validation validation;

        //constructor used to set the variables to either null or certain values
        public Recipe()
        {
            //sets the console to allow for special symbols such as bullet points to make the output more user friendly
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //initializes the vlaidation class so that its methods can be used elsewhere
            validation = new Validation();

            //sets scaleAmount to a 1 for now
            scaleUpAmount = 1;

            scaleDownAmount = 1;

            //methods that must run for the application to work correclty
            DisplayWelcome();

            CreateRecipe();

            Menu();
        }

        //welcome message method
        public void DisplayWelcome()
        {
            Console.WriteLine("Welcome chef to Sanele's Cooking Book!\n" +
                "The book with all the recipes you need in the world!\n" +
                "=====================================================");
        }

        //method to populate the ingredients of the global array
        public void AddIngredients()
        {
            //nullable variable that checks if the input is a positive integer
            int? value = validation.GetValidInteger("Please enter the number of ingredients for " + recipeName + ": ");

            //if so then numIngredients becomes that value
            numIngredients = value.Value;

            //the array object is initialized with the length of the number of ingredients
            ingredients = new Ingredient[numIngredients];

            //for loop that runs through every in ingredient to populate the array object
            for (int i = 0; i < ingredients.Length; i++)
            {
                //input message
                Console.Write("Please enter the name of the ingredient " + (i + 1) + ": ");

                //input
                string ingredientName = Console.ReadLine().Trim();

                //while the input is blank
                while (string.IsNullOrWhiteSpace(ingredientName))
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;

                    //error messsage
                    Console.Write("Input cannot be null. Please try again: ");

                    //resets the text console color
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //re enter variable to try again
                    ingredientName = Console.ReadLine().Trim();
                }

                //input for quantity that validates if the input is a number/fraction then converts it to float
                float quantity = validation.ConvertFractionToFloat("Please enter the quantity of " + ingredientName + " in the form of a number or fraction (E.g. 1 1/3): ");

                //input message
                Console.Write("Please enter the measurement of " + ingredientName + " (E.g. tablespoon): ");

                //input
                string measurement = Console.ReadLine().Trim();

                //while the input is blank
                while (string.IsNullOrWhiteSpace(measurement))
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;

                    //error
                    Console.Write("Input cannot be null. Please try again: ");

                    //resets the text console color
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //re enrter variable to try again
                    measurement = Console.ReadLine().Trim();
                }

                //populates the array at the for loop counter with the recently inputted variables
                ingredients[i] = new Ingredient(ingredientName, quantity, measurement);

                //sets the text console color to a correct message indication color
                Console.ForegroundColor = ConsoleColor.Green;

                //successful message
                Console.WriteLine("Ingreient captured successfully");

                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        //method to populate the instructions of the globl array
        public void AddInstructions()
        {
            //nullable variable that checks if the input is a positive integer
            int? value = validation.GetValidInteger("Please enter the number of instructions for " + recipeName + ": ");

            //if so then numMethodSteps becomes that value
            numMethodSteps = value.Value;

            //the array object is initialized with the length of the number of steps
            steps = new Method[numMethodSteps];

            //for loop that runs through every in step to populate the array object
            for (int i = 0; i < steps.Length; i++)
            {
                //input message
                Console.Write("Please enter the description for step " + (i + 1) + " of the method: ");

                //input
                string description = Console.ReadLine().Trim();

                //while the input is blank
                while (string.IsNullOrWhiteSpace(description))
                {
                    //sets the text console color to an error message indication color
                    Console.ForegroundColor = ConsoleColor.Red;

                    //error
                    Console.Write("Input cannot be null. Please try again: ");

                    //resets the text console color
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //re enter the variable to try again
                    description = Console.ReadLine().Trim();
                }

                //populates the array at the for loop counter with the recently inputted variables
                steps[i] = new Method(description);

                //sets the text console color to a correct message indication color
                Console.ForegroundColor = ConsoleColor.Green;

                //successful message
                Console.WriteLine("Method captured successfully");

                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        //method to all display the ingredients within the recipe
        public void DisplayIngredients()
        {
            string output = "INGREDIENTS\n" +
                "========================================\n";

            //loops through the full array and writes the formatted string of the Ingredients method to create a neat output
            for (int i = 0; i < ingredients.Length; i++)
            {
                output += ingredients[i].DisplayIngredients() + "\n";
            }

            Console.WriteLine(output);
        }

        //method to all display the instruction steps within the recipe
        public void DisplayInstructions()
        {
            string output = "INSTRUCTIONS\n" +
                "========================================\n";

            //loops through the full array and writes the formatted string of the Method method to create a neat output
            for (int i = 0; i < steps.Length; i++)
            {
                output += steps[i].DisplayStep(i + 1) + "\n";
            }

            Console.WriteLine(output);
        }

        //method to display the entire recipe including the ingredients and steps
        public void DisplayRecipe()
        {
            string output = "RECIPE FOR " + recipeName + "\n" +
                "----------------------------------------\n";

            output += "INGREDIENTS\n" +
                "========================================\n";

            //loops through the full array and writes the formatted string of the Ingredients method to create a neat output
            for (int i = 0; i < ingredients.Length; i++)
            {
                output += ingredients[i].DisplayIngredients() + "\n";
            }

            output += "----------------------------------------\n";

            output += "INSTRUCTIONS\n" +
                "========================================\n";

            //loops through the full array and writes the formatted string of the Method method to create a neat output
            for (int i = 0; i < steps.Length; i++)
            {
                output += steps[i].DisplayStep(i + 1) + "\n";
            }

            output += "----------------------------------------\n";

            Console.WriteLine(output);

        }

        //Method to create the full recipe from start to finish
        public void CreateRecipe()
        {
            //some start up output for some user understanding
            Console.WriteLine("To create a recipe, you will need to input your ingredients and method steps.\n");
            Console.Write("Firstly you will need to name your recipe: ");

            //input
            recipeName = Console.ReadLine().Trim();

            //while the input is blank
            while (string.IsNullOrWhiteSpace(recipeName))
            {
                //sets the text console color to an error message indication color
                Console.ForegroundColor = ConsoleColor.Red;

                //error
                Console.Write("Input cannot be null. Please try again: ");

                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;

                //re enter variable to try again
                recipeName = Console.ReadLine().Trim();
            }

            //just neatening up output structure with these lines of code
            Console.WriteLine();

            //some more output to help the user navigate and understand the process
            Console.Write("Now it is time to add the ingredients.\n");

            Console.WriteLine();

            //run the method to populate the ingredients
            AddIngredients();

            Console.WriteLine();

            //some more output to help the user navigate and understand the process
            Console.Write("Now it is time to add the instructions.\n");

            Console.WriteLine();

            //run the method to populate the instructions
            AddInstructions();

            Console.WriteLine();
        }

        //method to display a main menu screen to help the user navigate the application
        public void MenuOptions()
        {
            Console.WriteLine("MAIN MENU:\n" +
                "----------------------------------------\n" +
                "(1) View the full recipe.\n" +
                "(2) View the ingredients.\n" +
                "(3) View the insrtructions.\n" +
                "(4) Scale the ingredients.\n" +
                "(5) Return to the initial ingredients\n" +
                "(6) Reset the recipe.\n" +
                "(7) Create a new recipe.\n" +
                "(Other) Exit the application.");
        }

        //menu method to add the functionality of the main menu to navigate the user around the application
        public void Menu()
        {
            //nullable variable to control where the user navigates to within the application
            int? menuOption = 1;

            //while the menuOption is within the specified set of numbers
            //note that menuOption was set to 1 initially to allow the menu to run once the recipe was created
            //The user can then decided if they would like to exit the application or not
            while (menuOption > 0 && menuOption < 7)
            {
                //display the method to help the user
                MenuOptions();

                //neatening up the console output
                Console.WriteLine();

                //input for where the user wants to navigate to
                menuOption = validation.GetValidInteger("Select an option: ");

                //if variable is 1
                if (menuOption == 1)
                {
                    //display the recipe in full
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Blue;

                    DisplayRecipe();

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine();
                }
                //else if variable is 2
                else if (menuOption == 2)
                {
                    //display only the set of ingredients
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Blue;

                    DisplayIngredients();

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine();
                }
                //else if variable is 3
                else if (menuOption == 3)
                {
                    //display only the set of instruction steps   
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Blue;

                    DisplayInstructions();

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine();
                }
                //else if variable is 4
                else if (menuOption == 4)
                {
                    //allow the user to sale their ingredients
                    Console.WriteLine();
                    ScaleIngredients();
                    Console.WriteLine();
                }
                //else if variable is 5
                else if (menuOption == 5)
                {
                    //set the ingredients back to the initial values
                    Console.WriteLine();

                    ReturnInitialIngredients();

                    Console.WriteLine();
                }
                //else if variable is  6
                else if (menuOption == 6)
                {
                    //reset the arrays to 0
                    Console.WriteLine();

                    ResetRecipe();

                    Console.WriteLine();
                }
                //else if variable is 7
                else if (menuOption == 7)
                {
                    //allow the user to create a new recipe
                    Console.WriteLine();

                    CreateRecipe();

                    Console.WriteLine();

                    //here the method has used recursion to rerun the entire program if the user wishes to create a new recipe
                    //problem with recursion is if the user adds too many recipes without exiting the appliaction, the application will eventually crash from stack overflow
                    //fortunately the application's nature will eventually change to the point where recursion will not be needed to continue the application
                    Menu();
                }
                else
                {
                    //else variable is equal to a value that does not meet the while loop conditions, thus ending the loop and stopping the application
                    menuOption = -1;
                }
            }
        }

        //method to scale each ingredient in the array
        //the method takes in an amount which will be the amount each ingredient must be scaled by
        public void ScaleUp(float amount)
        {
            //loops through every element in the array
            for (int i = 0; i < ingredients.Length; i++)
            {
                //the ingredient's quantity at the counter of the for loop becomes the ingredient's quantity at the counter multiplied by the scale amount
                ingredients[i].Quantity = ingredients[i].Quantity * amount;
            }
        }

        //method to scale each ingredient in the array back to the original values
        //the method takes in an amount which will be the amount each ingredient must be scaled down by
        //this amount will typically be the current scale amount that was just used to scale up the ingredients
        //if thats not the case, the amount will be 1 which is what it was set to in the constructor
        public void ScaleDown(float amount)
        {
            //loops through every element in the array
            for (int i = 0; i < ingredients.Length; i++)
            {
                //does the exact same calculation as what occured in the ScaleUp method, by with the opposite math symbol to undo the effects of the previous method
                ingredients[i].Quantity = ingredients[i].Quantity / amount;
            }
        }

        //method to get the user to change the values of the ingredients
        public void ScaleIngredients()
        {
            //nullable variable
            int? option;

            //input message that gives the user a choice between 3 different scale types
            Console.WriteLine("Select an amount to scale up by:\n" +
                "(1) Half.\n" +
                "(2) Double.\n" +
                "(3) Triple.");

            Console.WriteLine();

            //input with validation of positive integer
            option = validation.GetValidInteger("Select an option: ");


            //if variable is 1
            if (option == 1)
            {
                //scale amount is half with the float symbol
                scaleUpAmount = 0.5f;

                scaleDownAmount *= 0.5f;
            }
            //else if variable is 2
            else if (option == 2)
            {
                //scale amount is double
                scaleUpAmount = 2;

                scaleDownAmount *= 2;
            }
            //else if variable is 3
            else if (option == 3)
            {
                //scale amount is triple
                scaleUpAmount = 3;

                scaleDownAmount *= 3;
            }

            //if the scaleamount is between the condition set
            if (option > 0 && option < 4)
            {
                //scale the amount with the scale amount
                ScaleUp(scaleUpAmount);

                //sets the text console color to a correct message indication color
                Console.ForegroundColor = ConsoleColor.Green;

                //give the user an indication that the change was made and it was successful
                Console.WriteLine("Ingredients changed successfully.");

                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                //sets the text console color to an error message indication color
                Console.ForegroundColor = ConsoleColor.Red;

                //error message
                Console.WriteLine("Not a valid scale amount.");

                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        //method to set the ingredient values back to the original values
        public void ReturnInitialIngredients()
        {
            //if the scale amount currently is at 1, meaning that the scaling has not changed
            if (scaleDownAmount == 1)
            {
                //let the user know that the value of the ingredients is exactly the same as the original
                Console.WriteLine("Ingredients are currently the same as the inital set.");
            }
            else
            {
                //else scale down the ingredient values with the current scale amount which will be the same amount that was used to upscale the ingredients
                //as seen, this method will do the opposite effect to the scale up method, meaning the ingredients will return to their original values
                ScaleDown(scaleDownAmount);

                //sets the text console color to a correct message indication color
                Console.ForegroundColor = ConsoleColor.Green;

                //give the user an indication that the change was made and it was successful
                Console.WriteLine("Ingredients changed successfully.");

                //resets the text console color
                Console.ForegroundColor = ConsoleColor.Gray;

                //now that the ingredients have returned to the original values, reset the scale down amount to 1 so that when this option is chosen again, the scale amount won't scale down the original items again, which is not intended
                scaleDownAmount = 1;
            }
        }

        //method to reset the recipe ingredients and steps
        public void ResetRecipe()
        {
            //initialize the global arrays again but this time set the lengths to 0 to reset the values within them
            //these lengths will not cause problems as the lengths will be initialized again when a new recipe is created
            ingredients = new Ingredient[0];

            steps = new Method[0];

            //sets the text console color to a correct message indication color
            Console.ForegroundColor = ConsoleColor.Green;

            //give the user an indication that the change was made and it was successful
            Console.WriteLine("Recipe Reset successfully.");

            //resets the text console color
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}