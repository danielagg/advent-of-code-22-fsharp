namespace Day02

open System.IO

module Part1 =
    type Hand = Rock | Paper | Scissors

    type Round = {
        Opponent: Hand
        Me: Hand
    }

    let parseLine (line: string) =
        let values = line.Split(" ")

        let opponentHand =
            match values.[0] with
            | "A" -> Rock
            | "B" -> Paper
            | "C" -> Scissors
            | _ -> failwith "Incorrect character"

        let myHand =
            match values.[1] with
            | "X" -> Rock
            | "Y" -> Paper
            | "Z" -> Scissors
            | _ -> failwith "Incorrect character"

        { Opponent = opponentHand; Me = myHand }

    let scoreRound (round: Round) =
        let scoreForShape =
            match round.Me with
            | Rock -> 1
            | Paper -> 2
            | Scissors -> 3

        let scoreForGameResult =
            match (round.Me, round.Opponent) with
            | Rock, Scissors
            | Paper, Rock
            | Scissors, Paper -> 6
            | me, opp when me = opp -> 3
            | _ -> 0

        scoreForShape + scoreForGameResult

    let run () =
        let data = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "input.txt"))
        let rounds = data |> Array.map parseLine
        rounds |> Array.map scoreRound |> Array.sum

module Part2 =
    type Hand = Rock | Paper | Scissors
    type RoundResult = Lose | Draw | Win

     type Round = {
        Opponent: Hand
        RoundResult: RoundResult
    }

    let parseLine (line: string) =
        let values = line.Split(" ")

        let opponentHand =
            match values.[0] with
            | "A" -> Rock
            | "B" -> Paper
            | "C" -> Scissors
            | _ -> failwith "Incorrect character"

        let roundResult =
            match values.[1] with
            | "X" -> Lose
            | "Y" -> Draw
            | "Z" -> Win
            | _ -> failwith "Incorrect character"

        { Opponent = opponentHand; RoundResult = roundResult }

    let scoreRound (round: Round) =

        let myShape =
            match (round.RoundResult, round.Opponent) with
            | Lose, Rock -> Scissors
            | Draw, Rock -> Rock
            | Win, Rock -> Paper
            | Lose, Paper -> Rock
            | Draw, Paper -> Paper
            | Win, Paper -> Scissors
            | Lose, Scissors -> Paper
            | Draw, Scissors -> Scissors
            | Win, Scissors -> Rock

        let scoreForShape =
            match myShape with
            | Rock -> 1
            | Paper -> 2
            | Scissors -> 3

        let scoreForGameResult =
            match round.RoundResult with
            | Lose -> 0
            | Draw -> 3
            | Win -> 6

        scoreForShape + scoreForGameResult

    let run () =
        let data = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "input.txt"))
        let rounds = data |> Array.map parseLine
        rounds |> Array.map scoreRound |> Array.sum
