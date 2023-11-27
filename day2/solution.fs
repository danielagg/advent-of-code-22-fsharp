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

        let myHand =
            match values.[1] with
            | "X" -> Rock
            | "Y" -> Paper
            | "Z" -> Scissors

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
    let run () =
        1
