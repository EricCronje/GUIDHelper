Console.WriteLine("PageSize : ");
_ = UInt32.TryParse(Console.ReadLine(), out uint pagesize);
Console.WriteLine("TotalItems : ");
_ = UInt32.TryParse(Console.ReadLine(), out uint totalitems);
Pagination.Pagination pagination = new(pagesize, totalitems);

bool bTrue = true;
while (bTrue) 
{
    Console.WriteLine($"n, b or x");
    string? input = Console.ReadLine();
    bTrue = (input != "x");
    if (input == "n" && !pagination.IsLastPage())
        pagination.GetNextPage();
    
    if (input == "b" && !pagination.IsFirstPage())
        pagination.GetPreviousPage(); 
    
    if ((!pagination.IsLastPage() || !pagination.IsFirstPage()) || (pagination.IsLastPage() == pagination.IsFirstPage()))
    {
        Console.WriteLine($"Current page: {pagination.GetPageNumberCaption()}");
        Console.WriteLine($"First Item: {pagination.FirstItemNumber}");
        Console.WriteLine($"Last Item: {pagination.GetLastItemOnThePage()}");
        Console.WriteLine($"Last Page: {pagination.IsLastPage()}");
        Console.WriteLine($"First Page: {pagination.IsFirstPage()}");
    }
}; 

pagination.Dispose();