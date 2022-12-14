var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var gameRounds = inputFile.Split(Environment.NewLine);

// A for Rock, B for Paper, and C for Scissors
// X for Rock, Y for Paper, and Z for Scissors.
// Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.

// (1 for Rock, 2 for Paper, and 3 for Scissors)
// plus the score for the outcome of the round
// (0 if you lost, 3 if the round was a draw, and 6 if you won).

// win combinations
//     o+m
// R+P 1+2 = 3
// P+S 2+3 = 5
// S+R 3+1 = 4

// loose combinations
//     o+m
// R+S 1+3 = 4
// P+R 2+1 = 3
// S+P 3+2 = 5

// task 1

var task1Result = 0;

foreach (var round in gameRounds)
{
    task1Result += CalculateRoundResult(round[0], round[2]);
}

Console.WriteLine($"Task 1 is {task1Result}"); // 13565

// task 2
// X means you need to lose, Y means you need to end the round in a draw,
// and Z means you need to win. 

var task2Result = 0;

foreach (var round in gameRounds)
{
    var desiredResult = round[2];

    var opponentScore = MatchMoveToScore(round[0]);
    var myScore = 0; // draw by default

    switch (desiredResult)
    {
        case 'Z':
            // win
            // our score contains opponent score + 1 except the case when opponent score is 3,
            // it means that Scissors (3) must be beaten by Rock (1)
            myScore = opponentScore == 3 ? 1 : opponentScore + 1;
            myScore += 6;
            break;
        case 'X':
            // loose
            // vice versa: opponent score - 1 except the case when Rock (1) is beaten by Scissors (3)
            myScore = opponentScore == 1 ? 3 : opponentScore - 1;
            break;
        case 'Y':
            // draw
            myScore = opponentScore;
            myScore += 3;
            break;
    }

    task2Result += myScore;
}

Console.WriteLine($"Task 2 is {task2Result}"); // 12424

int CalculateRoundResult(char opponentMove, char myMove)
{
    var opponentScore = MatchMoveToScore(opponentMove);
    var myScore = MatchMoveToScore(myMove);

    var resultScore = myScore;

    var scores = new int[] { opponentScore, myScore };

    if (scores is [2, 3] || scores is [1, 2] || scores is [3, 1])
    {
        // victory!
        resultScore += 6;
    }

    if (myScore == opponentScore)
    {
        // draw
        resultScore += 3;
    }

    return resultScore;
}

int MatchMoveToScore(char move) =>
    move switch
    {
        'A' or 'X' => 1,
        'B' or 'Y' => 2,
        'C' or 'Z' => 3,
    }; ;