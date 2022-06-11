# DealerOn Coding Test

**Candidate**: Mateus Palácio
**Chosen language**: C#

## Architecture

The solution has 4 projects, these being Main, Domain, Business and Tests. Each project has its function, with Domain being the “base” layer.

### Main

In this project the code is executed, using the 3 base inputs from the test description, and adding the possibility of the user adding another input. It contains only the Program.cs class. The input is an object that contains a list of strings, this assumption was made following the given test input in the test description.

### Domain

In this project, all models are present. In case of an API, where DTOs are also used, they would be contained here, same with interfaces for services and repositories.

3 Models can be found here, InputModel which contains the list of strings that the user gives, Product which means a product on the list of inputs(after the conversion on ExtractProductsFromInput.cs) and also Receipt which is the total order which is going to be formatted for the user,

### Business

This project would be like the “Service” layer in an API, and here we do our calculations for each product, taxes and also actions like converting the string inputs into objects, and printing the receipts. It contains classes such as:

#### `CalculateTotalOrderPrice.cs`
In this class, it will receive a list of products and calculate the total price of the order.

#### `ExtractProductsFromInput.cs`
Basically a “main” class of this project, it converts strings into C# objects with a format defined in the Domain layer. It will check the inputs, throw exceptions if they don’t follow certain rules, call other classes to calculate taxes and totals, and create a receipt for the input.

#### `CalculateTaxesForProduct.cs`
This class is used for calculating the value of taxes for each product. It takes into consideration the business rules for taxes for foods, books and medicine, and also imported goods.

#### `TaxExemption.cs`
Here it is defined a list of terms related to tax exemption, such as book, books, chocolate, pills, medicine.

#### `Printer.cs`
Helper class to convert the receipt into an output that follows the suggested format.

### Tests

This contains 2 example unit tests for the application.
