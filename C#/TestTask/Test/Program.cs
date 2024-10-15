
using Test;

int[] start = { 8, 10, 4 };

int colorToBecome = 2;

SearchSolution searchSolution = new SearchSolution();

int result = searchSolution.MinMeetings(start, colorToBecome);

Console.WriteLine(result);
