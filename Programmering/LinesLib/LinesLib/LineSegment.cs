
using System;

namespace LinesLib
{
    public class LineSegment
    {
        public readonly int Start;
        public readonly int End;

        public LineSegment(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException($"End {end} needs to be bigger than or equal to Start {start}");
            }
            
            this.Start = start;
            this.End = end;
        }

        public override string ToString()
        {
            return $"Linesegment: {Start} - {End}";
        }

        public bool Contains(int point)
        {
            return point >= Start && point <= End ;
        }

        public bool Contains(LineSegment segment)
        {
            return this.Contains(segment.Start) && this.Contains(segment.End);
        }
    }
}
