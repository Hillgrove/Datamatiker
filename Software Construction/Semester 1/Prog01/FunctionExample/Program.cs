double rect1x1 = 4.5;
double rect1y1 = 2.3;
double rect1x2 = 8.2;
double rect1y2 = 4.9;

double area1 = AreaOfRectangle(rect1x1, rect1y1, rect1x2, rect1y2);
Console.WriteLine($"Area of first rectangle is {area1:F2}");

double rect2x1 = -3.2;
double rect2y1 = 1.1;
double rect2x2 = 3.7;
double rect2y2 = 5.6;

double area2 = AreaOfRectangle(rect2x1, rect2y1, rect2x2, rect2y2);
Console.WriteLine($"Area of second rectangle is {area2:F2}");

double x1 = 3.3;
double y1 = 2.2;

double x2 = 7.5;
double y2 = 2.8;

double x3 = 11.1;
double y3 = 8.0;

double x4 = 6.8;
double y4 = 12.4;

double x5 = 3.5;
double y5 = 7.7;

Console.WriteLine($"Perimeter of pentagon (using PentagonPerimeter) is " +
                  $"{PentagonPerimeter(x1, y1, x2, y2, x3, y3, x4, y4, x5, y5):F2}");

double AreaOfRectangle(double x1, double y1, double x2, double y2)
{
    // Implement AreaOfRectangle, such that it returns the area
    // of a rectangle defined by (x1, y1) and (x2, y2)
    double lenA = Math.Abs(x2 - x1);
    double lenB = Math.Abs(y2 - y1);
    return lenA * lenB;
}

double PentagonPerimeter(double x1, double y1, 
                         double x2, double y2, 
                         double x3, double y3, 
                         double x4, double y4, 
                         double x5, double y5)
{
    return sideLength(x1, y1, x2, y2) + 
           sideLength(x2, y2, x3, y3) +
           sideLength(x3, y3, x4, y4) +
           sideLength(x4, y4, x5, y5) +
           sideLength(x5, y5, x1, y1);
}

double sideLength(double x1, double y1, double x2, double y2)
{
    return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
}