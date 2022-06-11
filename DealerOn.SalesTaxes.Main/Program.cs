using DealerOn.SalesTaxes.Business;
using DealerOn.SalesTaxes.Business.OrderActions;
using DealerOn.SalesTaxes.Domain.Models;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US", false);


ExtractProductsFromInput e = new();
Printer p = new();
// Input 1
var input1 = e.ExtractProductData(new InputModel()
{
    PurchasedProducts = new List<string>()
    {
        "1 Book at 12.49",
        "1 Book at 12.49",
        "1 Music CD at 14.99",
        "1 Chocolate bar at 0.85"
    }
});
Console.WriteLine(" --- OUTPUT 1 ---");
p.Print(input1);
Console.WriteLine();

// Input 2
var input2 = e.ExtractProductData(new InputModel()
{
    PurchasedProducts = new List<string>()
    {
        "1 Imported box of chocolates at 10.00",
        "1 Imported bottle of perfume at 47.50"
    }
});
Console.WriteLine(" --- OUTPUT 2 ---");
p.Print(input2);
Console.WriteLine();

// Input 3
var input3 = e.ExtractProductData(new InputModel()
{
    PurchasedProducts = new List<string>()
    {
        "1 Imported bottle of perfume at 27.99",
        "1 Bottle of perfume at 18.99",
        "1 Packet of headache pills at 9.75",
        "1 Imported box of chocolates at 11.25",
        "1 Imported box of chocolates at 11.25"
    }
});
Console.WriteLine(" --- OUTPUT 3 ---");
p.Print(input3);
Console.WriteLine();

Console.WriteLine("  --- Write your own Input, each line/product purchased is an input line, so type it (e.g.: '1 Imported chocolate at 6.99') and press Enter! If you are done with your inputs, press Enter again");
Console.WriteLine(" Input Format: ");
Console.WriteLine(" <quantity> <product name> at <price> ");
Console.WriteLine(" When all your purchases are complete, and you wish to close the program, input 'end', and then press the Enter key again");
while(true)
{
    var listOfInputs = new List<string>();
    while (true)
    {
        string newInputs = Console.ReadLine();
        if (string.IsNullOrEmpty(newInputs))
            break;
        listOfInputs.Add(newInputs);
    }
    if (listOfInputs.Any().Equals("done"))
        break;
    else
    {
        var getReceipt = e.ExtractProductData(new InputModel() { PurchasedProducts = listOfInputs });
        p.Print(getReceipt);
    }
}