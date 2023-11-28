namespace Day03

open System.IO

module Part1 =
    let getDuplicatedCharacters (line: string) =
        let middleIndex = line.Length / 2

        let part1 = List.ofSeq line.[0..middleIndex-1]
        let part2 = List.ofSeq line.[middleIndex..]

        let commonCharacters =
            Set.intersect (Set.ofList(part1)) (Set.ofList(part2))

        match Set.toList commonCharacters with
        | [] -> None
        | [commonChar] -> Some commonChar
        | _ -> failwith "More than one duplicated characters"

    let scoreCharacter (character: char) =
        match character with
        | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 1
        | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 27
        | _ -> failwith "Unexpected character"

    let run () =
        let data = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "input.txt"))
        let duplicatedCharacters = data |> Array.map getDuplicatedCharacters |> Array.choose id
        let scoresArray = duplicatedCharacters |> Array.map scoreCharacter
        scoresArray |> Array.sum

// module Part2 =
//     type Hand = Rock | Paper | Scissors
//     type RoundResult = Lose | Draw | Win

//      type Round = {
//         Opponent: Hand
//         RoundResult: RoundResult
//     }

//     let parseLine (line: string) =
//         let values = line.Split(" ")

//         let opponentHand =
//             match values.[0] with
//             | "A" -> Rock
//             | "B" -> Paper
//             | "C" -> Scissors

//         let roundResult =
//             match values.[1] with
//             | "X" -> Lose
//             | "Y" -> Draw
//             | "Z" -> Win

//         { Opponent = opponentHand; RoundResult = roundResult }

//     let scoreRound (round: Round) =

//         let myShape =
//             match (round.RoundResult, round.Opponent) with
//             | Lose, Rock -> Scissors
//             | Draw, Rock -> Rock
//             | Win, Rock -> Paper
//             | Lose, Paper -> Rock
//             | Draw, Paper -> Paper
//             | Win, Paper -> Scissors
//             | Lose, Scissors -> Paper
//             | Draw, Scissors -> Scissors
//             | Win, Scissors -> Rock

//         let scoreForShape =
//             match myShape with
//             | Rock -> 1
//             | Paper -> 2
//             | Scissors -> 3

//         let scoreForGameResult =
//             match round.RoundResult with
//             | Lose -> 0
//             | Draw -> 3
//             | Win -> 6

//         scoreForShape + scoreForGameResult

//     let run () =
//         let data = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "input.txt"))
//         let rounds = data |> Array.map parseLine
//         rounds |> Array.map scoreRound |> Array.sum
