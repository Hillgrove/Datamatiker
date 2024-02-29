using static DrawingTool;

// SHAPE A (10 stars in a single row)
//
// **********
//
Console.WriteLine("SHAPE A (10 stars in a single row)");
for (int i = 0; i < 10; i++)
{
    DrawOneSpace();
}
Console.WriteLine();

// SHAPE B (5 stars in a single row, separated by spaces)
//
// * * * * * 
//
Console.WriteLine("SHAPE B (5 stars in a single row, separated by spaces)");
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0) {  DrawOneStar(); }
    else { DrawOneSpace(); }
}
Console.WriteLine();


// SHAPE C  (10 rows of 10 stars each)
//
// **********
// **********
// **********
// **********
// **********
// **********
// **********
// **********
// **********
// **********
//
Console.WriteLine("SHAPE C  (10 rows of 10 stars each)");
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        DrawOneStar();
    }
    
    StartNewLine();
}
Console.WriteLine();

// SHAPE D (a triangle, I guess...)
//
// *
// **
// ***
// ****
// *****
// ******
// *******
// ********
// *********
// **********
//
Console.WriteLine("SHAPE D (a triangle, I guess...");
for (int i = 0;i < 10; i++)
{
    for(int j = 0;j < i; j++)
    {
        DrawOneStar();
    }

    StartNewLine();
}
Console.WriteLine();

// SHAPE E (X)
//
// *        *
//  *      * 
//   *    *   
//    *  *    
//     **     
//     **     
//    *  *    
//   *    *   
//  *      * 
// *        *
Console.WriteLine("SHAPE E (X)");
for (int i = 0; i < 10 ; i++)
{
    int spaceBefore = Math.Min(i, 9 - i); // output: 0, 1, 2, 3, 4, 4, 3, 2, 1, 0
    for (int j = 0; j < spaceBefore; j++)
    {
        DrawOneSpace();
    }
    
    DrawOneStar();

    for (int k = 0; k < 8 - (2 * spaceBefore); k++)
    {
        DrawOneSpace();
    }
    
    DrawOneStar();
    StartNewLine();
}