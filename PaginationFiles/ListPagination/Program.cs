using System.Text;

Console.WriteLine("PageSize : ");
_ = UInt32.TryParse(Console.ReadLine(), out uint pagesize);
Console.WriteLine("TotalItems : ");
_ = UInt32.TryParse(Console.ReadLine(), out uint totalitems);
Pagination.Pagination pagination = new(pagesize, totalitems);

PrintOptions(pagination);

bool bContinue = true;
while (bContinue)
{
    StringBuilder sbValidOptions = new();

    for (int i = 1; i! <= pagination.TotalPages; i++)
    {
        sbValidOptions.Append("|" + "p" + i);
    }
    sbValidOptions.Append("|n|b|f|l|x");

    Console.WriteLine($"n, b, f, l, x or p<page>");
    string? input = Console.ReadLine();
    bContinue = (input != "x");

    if (input != null)
    {
        if (sbValidOptions.ToString().Contains(input))
        {

            if (input[..1] == "p" && input.Length > 1)
            {
                _ = UInt32.TryParse(input.AsSpan(1, 1), out UInt32 page);
                pagination.GoToPage(page);
            }

            if (input == "n" && !pagination.IsLastPage())
                pagination.GetNextPage();

            if (input == "b" && !pagination.IsFirstPage())
                pagination.GetPreviousPage();

            if (input == "f" && !pagination.IsFirstPage())
                pagination.GoToFirstPage();

            if (input == "l" && !pagination.IsLastPage())
                pagination.GoToLastPage();

            PrintOptions(pagination);
        }
        else
        {
            PrintOptions(pagination);
            Console.WriteLine($"Invalid input - {input}");
        }
    }
};

pagination.Dispose();

static void PrintOptions(Pagination.Pagination pagination)
{
    Console.WriteLine($"Current page: {pagination.GetPageNumberCaption()}");
    Console.WriteLine($"First Item: {pagination.FirstItemNumber}");
    Console.WriteLine($"Last Item: {pagination.GetLastItemOnThePage()}");
    Console.WriteLine($"Last Page: {pagination.IsLastPage()}");
    Console.WriteLine($"First Page: {pagination.IsFirstPage()}");
}